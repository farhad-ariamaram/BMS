using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using EmployeeRequest.Models;

namespace EmployeeRequest.Pages.Employee.WorkExperience
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

            ViewData["FldLeaveJobId"] = new SelectList(_context.TblLeaveJobs, "FldLeaveJobId", "FldLeaveJobTitle");
            return Page();
        }

        [BindProperty]
        public TblWorkExperience TblWorkExperience { get; set; }

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

            long lastid = _context.TblWorkExperiences.OrderByDescending(a => a.FldWorkExperienceId).FirstOrDefault().FldWorkExperienceId;
            TblWorkExperience.FldWorkExperienceId = lastid + 1;
            _context.TblWorkExperiences.Add(TblWorkExperience);

            _context.TblWorkExperiences.Add(TblWorkExperience);

            TblEmployeeRequestEmployeeEditLog t = new TblEmployeeRequestEmployeeEditLog()
            {
                FldEmployeeRequestEmployeeEditLogDate = DateTime.Now,
                FldEmployeeRequestUserId = Int64.Parse(uid),
                FldEmployeeRequestEmployeeId = TblWorkExperience.UserId,
                FldEmployeeRequestEmployeeEditLogSection = "Experience-Create"
            };
            _context.TblEmployeeRequestEmployeeEditLogs.Add(t);

            await _context.SaveChangesAsync();

            return RedirectToPage("Index", new { id = TblWorkExperience.UserId });
        }
    }
}
