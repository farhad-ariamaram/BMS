using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeRequest.Models;
using Microsoft.AspNetCore.Http;

namespace EmployeeRequest.Pages.Employee.HowFind
{
    public class EditModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public EditModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblEmployeeRequestHowFind TblEmployeeRequestHowFind { get; set; }

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

            TblEmployeeRequestHowFind = await _context.TblEmployeeRequestHowFinds
                .Include(t => t.FldEmployeeRequestEmployee).FirstOrDefaultAsync(m => m.FldEmployeeRequestHowFindId == id);

            if (TblEmployeeRequestHowFind == null)
            {
                return NotFound();
            }
            ViewData["FldEmployeeRequestEmployeeId"] = new SelectList(_context.TblEmployeeRequestEmployees, "FldEmployeeRequestEmployeeId", "FldEmployeeRequestEmployeeId");
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

            _context.Attach(TblEmployeeRequestHowFind).State = EntityState.Modified;

            TblEmployeeRequestEmployeeEditLog t = new TblEmployeeRequestEmployeeEditLog()
            {
                FldEmployeeRequestEmployeeEditLogDate = DateTime.Now,
                FldEmployeeRequestUserId = Int64.Parse(uid),
                FldEmployeeRequestEmployeeId = TblEmployeeRequestHowFind.FldEmployeeRequestEmployeeId,
                FldEmployeeRequestEmployeeEditLogSection = "HowFind-Edit"
            };

            _context.TblEmployeeRequestEmployeeEditLogs.Add(t);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblEmployeeRequestHowFindExists(TblEmployeeRequestHowFind.FldEmployeeRequestHowFindId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("Index", new { id = TblEmployeeRequestHowFind.FldEmployeeRequestEmployeeId });
        }

        private bool TblEmployeeRequestHowFindExists(long id)
        {
            return _context.TblEmployeeRequestHowFinds.Any(e => e.FldEmployeeRequestHowFindId == id);
        }
    }
}
