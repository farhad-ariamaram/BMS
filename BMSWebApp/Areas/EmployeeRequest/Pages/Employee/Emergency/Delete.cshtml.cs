using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeRequest.Models;
using Microsoft.AspNetCore.Http;

namespace EmployeeRequest.Pages.Employee.Emergency
{
    public class DeleteModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public DeleteModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblEmployeeRequestEmergencyCall TblEmployeeRequestEmergencyCall { get; set; }

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

            TblEmployeeRequestEmergencyCall = await _context.TblEmployeeRequestEmergencyCalls
                .Include(t => t.FldEmployeeRequestEmployee).FirstOrDefaultAsync(m => m.FldEmployeeRequestEmergencyCallId == id);

            if (TblEmployeeRequestEmergencyCall == null)
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

            TblEmployeeRequestEmergencyCall = await _context.TblEmployeeRequestEmergencyCalls.FindAsync(id);

            if (TblEmployeeRequestEmergencyCall != null)
            {
                _context.TblEmployeeRequestEmergencyCalls.Remove(TblEmployeeRequestEmergencyCall);
                TblEmployeeRequestEmployeeEditLog t = new TblEmployeeRequestEmployeeEditLog()
                {
                    FldEmployeeRequestEmployeeEditLogDate = DateTime.Now,
                    FldEmployeeRequestUserId = Int64.Parse(uid),
                    FldEmployeeRequestEmployeeId = TblEmployeeRequestEmergencyCall.FldEmployeeRequestEmployeeId,
                    FldEmployeeRequestEmployeeEditLogSection = "Emergency-Delete"
                };

                _context.TblEmployeeRequestEmployeeEditLogs.Add(t);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index", new { id = TblEmployeeRequestEmergencyCall.FldEmployeeRequestEmployeeId });
        }
    }
}
