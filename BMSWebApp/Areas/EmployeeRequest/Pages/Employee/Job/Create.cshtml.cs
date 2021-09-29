using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using EmployeeRequest.Models;

namespace EmployeeRequest.Pages.Employee.Job
{
    public class CreateModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public CreateModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(string id)
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../../Index");
            }

            ViewData["EmployeeId"] = id;
            ViewData["FldEmployeeRequestJobsId"] = new SelectList(_context.TblEmployeeRequestJobs, "FldEmployeeRequestJobsId", "FldEmployeeRequestJobsJobTitle");

            return Page();
        }

        [BindProperty]
        public TblEmployeeRequestUserJob TblEmployeeRequestUserJob { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../../Index");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            long lastid = _context.TblEmployeeRequestUserJobs.OrderByDescending(a => a.FldEmployeeRequestUserJobId).FirstOrDefault().FldEmployeeRequestUserJobId;
            TblEmployeeRequestUserJob.FldEmployeeRequestUserJobId = lastid + 1;
            _context.TblEmployeeRequestUserJobs.Add(TblEmployeeRequestUserJob);

            _context.TblEmployeeRequestUserJobs.Add(TblEmployeeRequestUserJob);

            TblEmployeeRequestEmployeeEditLog t = new TblEmployeeRequestEmployeeEditLog()
            {
                FldEmployeeRequestEmployeeEditLogDate = DateTime.Now,
                FldEmployeeRequestUserId = Int64.Parse(uid),
                FldEmployeeRequestEmployeeId = TblEmployeeRequestUserJob.FldEmployeeRequestEmployeeId,
                FldEmployeeRequestEmployeeEditLogSection = "Job-Create"
            };
            _context.TblEmployeeRequestEmployeeEditLogs.Add(t);

            await _context.SaveChangesAsync();

            return RedirectToPage("Index", new { id = TblEmployeeRequestUserJob.FldEmployeeRequestEmployeeId });
        }
    }
}
