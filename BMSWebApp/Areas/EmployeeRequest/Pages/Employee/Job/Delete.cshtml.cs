using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using EmployeeRequest.Models;

namespace EmployeeRequest.Pages.Employee.Job
{
    public class DeleteModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public DeleteModel(EmployeeRequestDBContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
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

            TblEmployeeRequestUserJob = await _context.TblEmployeeRequestUserJobs.FindAsync(id);

            if (TblEmployeeRequestUserJob != null)
            {
                _context.TblEmployeeRequestUserJobs.Remove(TblEmployeeRequestUserJob);

                TblEmployeeRequestEmployeeEditLog t = new TblEmployeeRequestEmployeeEditLog()
                {
                    FldEmployeeRequestEmployeeEditLogDate = DateTime.Now,
                    FldEmployeeRequestUserId = Int64.Parse(uid),
                    FldEmployeeRequestEmployeeId = TblEmployeeRequestUserJob.FldEmployeeRequestEmployeeId,
                    FldEmployeeRequestEmployeeEditLogSection = "Job-Delete"
                };

                _context.TblEmployeeRequestEmployeeEditLogs.Add(t);

                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index", new { id = TblEmployeeRequestUserJob.FldEmployeeRequestEmployeeId });
        }
    }
}
