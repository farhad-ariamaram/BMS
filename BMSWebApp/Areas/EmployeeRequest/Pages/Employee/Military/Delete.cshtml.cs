using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using EmployeeRequest.Models;

namespace EmployeeRequest.Pages.Employee.Military
{
    public class DeleteModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public DeleteModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblEmployeeRequestUserMilitary TblEmployeeRequestUserMilitary { get; set; }

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

            TblEmployeeRequestUserMilitary = await _context.TblEmployeeRequestUserMilitaries
                    .Include(t => t.FldEmployeeRequestEmployee)
                    .Include(t => t.FldEmployeeRequestMilitary)
                    .Include(t => t.FldEmployeeRequestMilitaryOrganization).FirstOrDefaultAsync(m => m.FldEmployeeRequestUserMilitaryId == id);

            if (TblEmployeeRequestUserMilitary == null)
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

            TblEmployeeRequestUserMilitary = await _context.TblEmployeeRequestUserMilitaries.FindAsync(id);

            if (TblEmployeeRequestUserMilitary != null)
            {
                _context.TblEmployeeRequestUserMilitaries.Remove(TblEmployeeRequestUserMilitary);

                TblEmployeeRequestEmployeeEditLog t = new TblEmployeeRequestEmployeeEditLog()
                {
                    FldEmployeeRequestEmployeeEditLogDate = DateTime.Now,
                    FldEmployeeRequestUserId = Int64.Parse(uid),
                    FldEmployeeRequestEmployeeId = TblEmployeeRequestUserMilitary.FldEmployeeRequestEmployeeId,
                    FldEmployeeRequestEmployeeEditLogSection = "Military-Delete"
                };

                _context.TblEmployeeRequestEmployeeEditLogs.Add(t);

                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index", new { id = TblEmployeeRequestUserMilitary.FldEmployeeRequestEmployeeId });
        }
    }
}
