using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeRequest.Models;
using Microsoft.AspNetCore.Http;

namespace EmployeeRequest.Pages.EmployeeRequest
{
    public class CreateModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public CreateModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }
            ViewData["FldEmployeeRequestUserApplicantId"] = new SelectList(_context.TblEmployeeRequestUsers, "FldEmployeeRequestUserId", "FldEmployeeRequestUserName");
            ViewData["FldEmployeeRequestUserSubmitterId"] = new SelectList(_context.TblEmployeeRequestUsers, "FldEmployeeRequestUserId", "FldEmployeeRequestUserName");
            ViewData["FldEmployeeRequestJobTitleFromId"] = new SelectList(_context.TblEmployeeRequestJobTitleFroms, "TblEmployeeRequestJobTitleFromId", "TblEmployeeRequestJobTitleFromTitle");
            return Page();
        }

        [BindProperty]
        public TblEmployeeRequestEmployeeRequest TblEmployeeRequestEmployeeRequest { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["FldEmployeeRequestUserApplicantId"] = new SelectList(_context.TblEmployeeRequestUsers, "FldEmployeeRequestUserId", "FldEmployeeRequestUserUsername");
                ViewData["FldEmployeeRequestUserSubmitterId"] = new SelectList(_context.TblEmployeeRequestUsers, "FldEmployeeRequestUserId", "FldEmployeeRequestUserUsername");
                ViewData["FldEmployeeRequestJobTitleFromId"] = new SelectList(_context.TblEmployeeRequestJobTitleFroms, "TblEmployeeRequestJobTitleFromId", "TblEmployeeRequestJobTitleFromTitle");
                return Page();
            }

            if (!string.IsNullOrEmpty(Request.Form["taminjobdropdown"].ToString()))
            {
                TblEmployeeRequestEmployeeRequest.FldEmployeeRequestJobTaminId = int.Parse(Request.Form["taminjobdropdown"].ToString());
            }
            if (!string.IsNullOrEmpty(Request.Form["onetjobdropdown"].ToString()))
            {
                TblEmployeeRequestEmployeeRequest.FldEmployeeRequestJobOnetId = int.Parse(Request.Form["onetjobdropdown"].ToString());
            }
            TblEmployeeRequestEmployeeRequest.FldEmployeeRequestJobsId = int.Parse(Request.Form["jobdropdown"].ToString());
            _context.TblEmployeeRequestEmployeeRequests.Add(TblEmployeeRequestEmployeeRequest);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnGetJobsAsync(string jobName)
        {
            return new JsonResult(_context.TblJobTamins.Where(a => a.FldTaminJobName.Contains(jobName) || a.FldTaminJobName.Contains(jobName.Replace("ی", "ي").Replace("ک", "ك"))).Select(a => new { a.FldTaminJobId, a.FldTaminJobName }).ToList());
        }

        public async Task<IActionResult> OnGetJobsoAsync(string jobName)
        {
            return new JsonResult(_context.TblJobs.Where(a => a.FldJobName.Contains(jobName) || a.FldJobName.Contains(jobName.Replace("ی", "ي").Replace("ک", "ك"))).Select(a => new { a.FldJobId, a.FldJobName }).ToList());
        }

        public async Task<IActionResult> OnGetJobseAsync(string jobName)
        {
            return new JsonResult(_context.PayJobs.Where(a => a.JobsName.Contains(jobName) || a.JobsName.Contains(jobName.Replace("ی", "ي").Replace("ک", "ك"))).Select(a => new { a.JobsId, a.JobsName }).ToList());
        }

    }
}
