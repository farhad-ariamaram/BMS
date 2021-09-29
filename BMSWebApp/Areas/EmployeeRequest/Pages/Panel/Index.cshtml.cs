using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRequest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequest.Pages.Panel
{
    /// <summary>
    /// This is panel page of web application 
    /// </summary>

    public class IndexModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public IndexModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        public DateTime LastUpdate { get; set; }
        public DateTime LastRegister { get; set; }

        public int MenPercent { get; set; }
        public int WomenPercent { get; set; }

        public IActionResult OnGet(string status)
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }

            if (status != null)
            {
                ViewData["status"] = status;
            }

            int AllMen = _context.TblEmployeeRequestPrimaryInformations.Where(a => a.FldEmployeeRequestPrimaryInformationGender == "آقا").Count();
            int AllWomen = _context.TblEmployeeRequestPrimaryInformations.Where(a => a.FldEmployeeRequestPrimaryInformationGender == "خانم").Count();

            MenPercent = (AllMen * 100) / (AllMen + AllWomen);
            WomenPercent = (AllWomen * 100) / (AllMen + AllWomen);
            if ((MenPercent + WomenPercent) < 100)
            {
                if (MenPercent > WomenPercent)
                {
                    MenPercent += 1;
                }
                else
                {
                    WomenPercent += 1;
                }
            }

            LastUpdate = _context.Logs.OrderByDescending(a => a.DateTime).FirstOrDefault().DateTime;
            LastRegister = _context.TblEmployeeRequestPageTimeLogs.OrderByDescending(a => a.FldEmployeeRequestPageTimeLogStartTime).FirstOrDefault().FldEmployeeRequestPageTimeLogStartTime.Value;

            ViewData["AllRegisteredUsers"] = _context.TblEmployeeRequestEmployees.Count();
            ViewData["MenRegisteredUsers"] = _context.TblEmployeeRequestPrimaryInformations.Where(a => a.FldEmployeeRequestPrimaryInformationGender == "آقا").Count();
            ViewData["WomenRegisteredUsers"] = _context.TblEmployeeRequestPrimaryInformations.Where(a => a.FldEmployeeRequestPrimaryInformationGender == "خانم").Count();
            ViewData["AcceptedRegisteredUsers"] = _context.TblEmployeeRequestEmployees.Where(a => a.FldEmployeeRequestFinalAcceptionId == 1).Count();

            ViewData["AllRequestedJobs"] = _context.TblEmployeeRequestEmployeeRequests.Count();
            ViewData["AcceptedJobs"] = _context.TblEmployeeRequestEmployeeRequests.Where(a => a.FldEmployeeRequestEmployeeRequestIsAccept == true).Count();
            ViewData["WaitingJobs"] = _context.TblEmployeeRequestEmployeeRequests.Where(a => a.FldEmployeeRequestEmployeeRequestIsAccept == false && a.FldEmployeeRequestUserAccepterId == null).Count();
            ViewData["TransferedJobs"] = _context.TblEmployeeRequestEmployeeRequests.Where(a => a.FldEmployeeRequestEmployeeRequestIsTransfered == true).Count();

            return Page();
        }

        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("../Index");
        }

        public async Task<IActionResult> OnGetLog()
        {
            var u = await _context.Logs.AsNoTracking().FirstOrDefaultAsync();
            u.Flag = true;
            var currentDate = u.DateTime;
            _context.Update(u);
            await _context.SaveChangesAsync();

            await Task.Delay(10000);
            u = await _context.Logs.AsNoTracking().FirstOrDefaultAsync();

            if(currentDate == u.DateTime)
            {
                return RedirectToPage("./Index", new { status = "FAIL" });
            }

            return RedirectToPage("./Index",new { status = u.Response });
        }
    }
}