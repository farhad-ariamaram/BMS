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

namespace EmployeeRequest.Pages.Employee.Job
{
    public class EditModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public EditModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblEmployeeRequestUserJob TblEmployeeRequestUserJob { get; set; }

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

            TblEmployeeRequestUserJob = await _context.TblEmployeeRequestUserJobs
                    .Include(t => t.FldEmployeeRequestEmployee)
                    .Include(t => t.FldEmployeeRequestJobs).FirstOrDefaultAsync(m => m.FldEmployeeRequestUserJobId == id);

            if (TblEmployeeRequestUserJob == null)
            {
                return NotFound();
            }
            ViewData["FldEmployeeRequestJobsId"] = new SelectList(_context.TblEmployeeRequestJobs, "FldEmployeeRequestJobsId", "FldEmployeeRequestJobsJobTitle");
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

            _context.Attach(TblEmployeeRequestUserJob).State = EntityState.Modified;

            TblEmployeeRequestEmployeeEditLog t = new TblEmployeeRequestEmployeeEditLog()
            {
                FldEmployeeRequestEmployeeEditLogDate = DateTime.Now,
                FldEmployeeRequestUserId = Int64.Parse(uid),
                FldEmployeeRequestEmployeeId = TblEmployeeRequestUserJob.FldEmployeeRequestEmployeeId,
                FldEmployeeRequestEmployeeEditLogSection = "Job-Edit"
            };

            _context.TblEmployeeRequestEmployeeEditLogs.Add(t);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblEmployeeRequestUserJobExists(TblEmployeeRequestUserJob.FldEmployeeRequestUserJobId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("Index", new { id = TblEmployeeRequestUserJob.FldEmployeeRequestEmployeeId });
        }

        private bool TblEmployeeRequestUserJobExists(long id)
        {
            return _context.TblEmployeeRequestUserJobs.Any(e => e.FldEmployeeRequestUserJobId == id);
        }
    }
}
