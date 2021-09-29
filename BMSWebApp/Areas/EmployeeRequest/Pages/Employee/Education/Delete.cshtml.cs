using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using EmployeeRequest.Models;

namespace EmployeeRequest.Pages.Employee.Education
{
    public class DeleteModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public DeleteModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblCustomerDegree TblCustomerDegree { get; set; }

        public async Task<IActionResult>
            OnGetAsync(long? id)
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

            TblCustomerDegree = await _context.TblCustomerDegrees
                    .Include(t => t.Diploma)
                    .Include(t => t.Education)
                    .Include(t => t.User).FirstOrDefaultAsync(m => m.FldCustomerDegreeId == id);

            if (TblCustomerDegree == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult>
            OnPostAsync(long? id)
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

            TblCustomerDegree = await _context.TblCustomerDegrees.FindAsync(id);

            if (TblCustomerDegree != null)
            {
                _context.TblCustomerDegrees.Remove(TblCustomerDegree);

                TblEmployeeRequestEmployeeEditLog t = new TblEmployeeRequestEmployeeEditLog()
                {
                    FldEmployeeRequestEmployeeEditLogDate = DateTime.Now,
                    FldEmployeeRequestUserId = Int64.Parse(uid),
                    FldEmployeeRequestEmployeeId = TblCustomerDegree.UserId,
                    FldEmployeeRequestEmployeeEditLogSection = "Education-Delete"
                };

                _context.TblEmployeeRequestEmployeeEditLogs.Add(t);

                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index", new { id = TblCustomerDegree.UserId });
        }
    }
}
