using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using EmployeeRequest.Models;
using EmployeeRequest.Utilities;

namespace EmployeeRequest.Pages.Employee.WorkExperience
{
    public class EditModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public EditModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblWorkExperience TblWorkExperience { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../../Index");
            }

            if (id == null)
            {
                return NotFound();
            }

            TblWorkExperience = await _context.TblWorkExperiences
                    .Include(t => t.FldLeaveJob)
                    .Include(t => t.FldTaminJob)
                    .Include(t => t.User).FirstOrDefaultAsync(m => m.FldWorkExperienceId == id);

            if (TblWorkExperience == null)
            {
                return NotFound();
            }
            ViewData["FldLeaveJobId"] = new SelectList(_context.TblLeaveJobs, "FldLeaveJobId", "FldLeaveJobTitle");
            ViewData["FldTaminJobId"] = new SelectList(_context.TblJobTamins.Where(a=>a.FldTaminJobId== TblWorkExperience.FldTaminJobId), "FldTaminJobId", "FldTaminJobName");
            ViewData["startdate"] = TblWorkExperience.FldStartDate.toPersianDate();
            ViewData["enddate"] = TblWorkExperience.FldEndDate.toPersianDate();

            return Page();
        }

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

            _context.Attach(TblWorkExperience).State = EntityState.Modified;

            TblEmployeeRequestEmployeeEditLog t = new TblEmployeeRequestEmployeeEditLog()
            {
                FldEmployeeRequestEmployeeEditLogDate = DateTime.Now,
                FldEmployeeRequestUserId = Int64.Parse(uid),
                FldEmployeeRequestEmployeeId = TblWorkExperience.UserId,
                FldEmployeeRequestEmployeeEditLogSection = "Experience-Edit"
            };

            _context.TblEmployeeRequestEmployeeEditLogs.Add(t);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblWorkExperienceExists(TblWorkExperience.FldWorkExperienceId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("Index", new { id = TblWorkExperience.UserId });
        }

        private bool TblWorkExperienceExists(long id)
        {
            return _context.TblWorkExperiences.Any(e => e.FldWorkExperienceId == id);
        }
    }
}
