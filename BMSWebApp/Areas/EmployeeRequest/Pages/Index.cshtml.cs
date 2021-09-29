using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EmployeeRequest.Utilities;
using EmployeeRequest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace EmployeeRequest.Pages
{
    /// <summary>
    /// This is login page of web application 
    /// and all things start from here 
    /// </summary>

    public class IndexModel : PageModel
    {
        EmployeeRequestDBContext _db;

        public IndexModel(EmployeeRequestDBContext db)
        {
            _db = db;
        }

        [BindProperty]
        public LoginModel loginModel { get; set; }

        public IActionResult OnGet()
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid != null)
            {
                return RedirectToPage("Panel/Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string key = Consts._CONST_KEY;
            string tk = ApiLogin.rndTransferKey();
            string token = ApiLogin.EncryptString(tk, key);
            string p1 = ApiLogin.EncryptString(Request.Form["loginModel.Username"], key); ;
            string p2 = ApiLogin.EncryptString(Request.Form["loginModel.Password"], key);
            string p3 = token;

            var theWebRequest = HttpWebRequest.Create("http://192.168.10.250/ExLogin.aspx/LI");
            theWebRequest.Method = "POST";
            theWebRequest.ContentType = "application/json; charset=utf-8";
            theWebRequest.Headers.Add(HttpRequestHeader.Pragma, "no-cache");

            using (var writer = theWebRequest.GetRequestStream())
            {
                string send = null;
                send = "{\"p0\":\"1\",\"p1\":\"" + p1 + "\",\"p2\":\"" + p2 + "\",\"p3\":\"" + p3 + "\"}";

                var data = Encoding.UTF8.GetBytes(send);

                writer.Write(data, 0, data.Length);
            }

            var theWebResponse = (HttpWebResponse)theWebRequest.GetResponse();
            var theResponseStream = new StreamReader(theWebResponse.GetResponseStream());

            string result = theResponseStream.ReadToEnd();

            try
            {
                result = "{" + result.Substring(28).Replace("}}", "}");
            }
            catch (Exception)
            {
                ModelState.AddModelError("WrongUP", "نام کاربری یا کلمه عبور اشتباه است");
                return Page();
            }

            var splashInfo = JsonConvert.DeserializeObject<clsExLogin>(result);

            string backTk = ApiLogin.DecryptString(splashInfo.Status, key);
            if (tk == ApiLogin.Reverse(backTk))
            {
                splashInfo.id = ApiLogin.DecryptString(splashInfo.id, key);
                splashInfo.name = ApiLogin.DecryptString(splashInfo.name, key);
                splashInfo.Status = ApiLogin.DecryptString(splashInfo.Status, key);

                bool withError = false;

                if (!_db.TblEmployeeRequestUsers.Where(a => a.FldEmployeeRequestUserId == int.Parse(splashInfo.id)).Any())
                {
                    try
                    {
                        TblEmployeeRequestUser t = new TblEmployeeRequestUser();

                        t.FldEmployeeRequestUserId = Int64.Parse(splashInfo.id);
                        t.FldEmployeeRequestUserUsername = Request.Form["loginModel.Username"];
                        t.FldEmployeeRequestUserPassword = ApiLogin.sha512(Consts._CONST_SALT + Request.Form["loginModel.Password"] + Consts._CONST_SALT);
                        t.FldEmployeeRequestUserName = splashInfo.name;


                        await _db.TblEmployeeRequestUsers.AddAsync(t);
                        await _db.SaveChangesAsync();
                    }
                    catch { withError = true; }
                }
                //var user = _db.TblEmployeeRequestUsers.Where(a => a.FldEmployeeRequestUserId == int.Parse(splashInfo.id)).FirstOrDefault();

                //if (user != null)
                //{
                //    //check name
                //    if (!user.FldEmployeeRequestUserName.Equals(splashInfo.name))
                //    {
                //        user.FldEmployeeRequestUserName = splashInfo.name;
                //    }

                //    //check pass
                //    if (!user.FldEmployeeRequestUserPassword.Equals(ApiLogin.sha512(Request.Form["loginModel.Password"] + Consts._CONST_SALT)))
                //    {
                //        user.FldEmployeeRequestUserPassword = ApiLogin.sha512(Request.Form["loginModel.Password"] + Consts._CONST_SALT);
                //    }

                //    _db.TblEmployeeRequestUsers.Update(user);
                //    _db.SaveChanges();

                //    string uid = splashInfo.id;
                //    HttpContext.Session.SetString("uid", uid);
                //    return RedirectToPage("Panel/Index");

                //}
                //else
                //{
                //TblEmployeeRequestUser t = new TblEmployeeRequestUser();

                //t.FldEmployeeRequestUserId = Int64.Parse(splashInfo.id);
                //t.FldEmployeeRequestUserUsername = Request.Form["loginModel.Username"];
                //t.FldEmployeeRequestUserPassword = ApiLogin.sha512(Request.Form["loginModel.Password"] + Consts._CONST_SALT);
                //t.FldEmployeeRequestUserName = splashInfo.name;

                //_db.TblEmployeeRequestUsers.Add(t);
                //_db.SaveChanges();

                if (!withError)
                {
                    string uid = splashInfo.id;
                    HttpContext.Session.SetString("uid", uid);

                    var setting = _db.TblEmployeeRequestUserSettings.Where(a => a.FldEmployeeRequestUserId == Int64.Parse(uid));
                    if (!setting.Any())
                    {
                        await _db.TblEmployeeRequestUserSettings.AddAsync(new TblEmployeeRequestUserSetting
                        {
                            FldEmployeeRequestUserId = Int64.Parse(uid),
                            FldEmployeeRequestUserSettingIsCollaps = true,
                            FldEmployeeRequestUserSettingIsShowGreen = true,
                            FldEmployeeRequestUserSettingIsShowRed = true
                        });

                        await _db.SaveChangesAsync();
                    }

                    return RedirectToPage("Panel/Index");
                }
                else
                {
                    ModelState.AddModelError("WrongUP", "در سیستم خطایی رخ داده است ! لطفا در زمان دیگری وارد شوید!");
                    return Page();
                }
            }
            else
            {
                ModelState.AddModelError("WrongUP", "نام کاربری یا کلمه عبور اشتباه است");
                return Page();
            }

            //var checkUser = _db.TblEmployeeRequestUsers
            //        .Where(a => a.FldEmployeeRequestUserUsername.Equals(loginModel.Username))
            //        .Where(a => a.FldEmployeeRequestUserPassword.Equals(loginModel.Password));

            //if (!checkUser.Any())
            //{
            //    ModelState.AddModelError("WrongUP", "نام کاربری یا کلمه عبور اشتباه است");
            //    return Page();
            //}

            //string uid = checkUser.FirstOrDefault().FldEmployeeRequestUserId.ToString();
            //HttpContext.Session.SetString("uid", uid);

            //return RedirectToPage("Panel/Index");
        }
    }

    public class LoginModel
    {
        [DisplayName("نام کاربری")]
        [Required(ErrorMessage = "نام کاربری را وارد کنید")]
        public string Username { get; set; }

        [DisplayName("کلمه عبور")]
        [Required(ErrorMessage = "کلمه عبور را وارد کنید")]
        public string Password { get; set; }
    }

    public class clsExLogin
    {
        public string Status;
        public string id;
        public string name;
    }
}