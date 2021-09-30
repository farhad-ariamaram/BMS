using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BMSWebApp.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BMSWebApp.Pages
{
    public class LoginModel : PageModel
    {

        [BindProperty]
        [Required(ErrorMessage ="کد امنیتی را وارد کنید")]
        public string CaptchaCode { get; set; }

        public int RandomNo { get; set; }

        public void OnGet()
        {
            RandomNo = new Random().Next(1,15);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (!Captcha.ValidateCaptchaCode(CaptchaCode, HttpContext))
                {
                    RandomNo = new Random().Next(1, 15);
                    ModelState.AddModelError("WrongCaptcha","کد امنیتی اشتباه است");
                    return Page();
                }
                return RedirectToPage("Login", new { ok = "ok" });
            }
            RandomNo = new Random(1).Next(1, 10);
            return Page();
        }

    }

    public class CaptchaResult
    {
        public string CaptchaCode { get; set; }
        public byte[] CaptchaByteData { get; set; }
        public string CaptchBase64Data => Convert.ToBase64String(CaptchaByteData);
        public DateTime Timestamp { get; set; }
    }
}
