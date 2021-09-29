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
using EmployeeRequest.Utilities;

namespace EmployeeRequest.Pages.Employee.Compile
{
    public class EditModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public EditModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblEmployeeRequestUserCompilation TblEmployeeRequestUserCompilation { get; set; }

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

            TblEmployeeRequestUserCompilation = await _context.TblEmployeeRequestUserCompilations
                .Include(t => t.FldEmployeeRequestCompilationType)
                .Include(t => t.FldEmployeeRequestEmployee).FirstOrDefaultAsync(m => m.FldEmployeeRequestUserCompilationId == id);

            if (TblEmployeeRequestUserCompilation == null)
            {
                return NotFound();
            }

            ViewData["FldEmployeeRequestCompilationTypeId"] = new SelectList(_context.TblEmployeeRequestCompilationTypes, "FldEmployeeRequestCompilationTypeId", "FldEmployeeRequestCompilationTypeCompilationType");
            ViewData["date"] = TblEmployeeRequestUserCompilation.FldEmployeeRequestUserCompilationDate.toPersianDate();

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
                ViewData["FldEmployeeRequestCompilationTypeId"] = new SelectList(_context.TblEmployeeRequestCompilationTypes, "FldEmployeeRequestCompilationTypeId", "FldEmployeeRequestCompilationTypeCompilationType");
                ViewData["date"] = TblEmployeeRequestUserCompilation.FldEmployeeRequestUserCompilationDate.toPersianDate();
                return Page();
            }

            _context.Attach(TblEmployeeRequestUserCompilation).State = EntityState.Modified;

            TblEmployeeRequestEmployeeEditLog t = new TblEmployeeRequestEmployeeEditLog()
            {
                FldEmployeeRequestEmployeeEditLogDate = DateTime.Now,
                FldEmployeeRequestUserId = Int64.Parse(uid),
                FldEmployeeRequestEmployeeId = TblEmployeeRequestUserCompilation.FldEmployeeRequestEmployeeId,
                FldEmployeeRequestEmployeeEditLogSection = "Compile-Edit"
            };

            _context.TblEmployeeRequestEmployeeEditLogs.Add(t);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblEmployeeRequestUserCompilationExists(TblEmployeeRequestUserCompilation.FldEmployeeRequestUserCompilationId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("Index", new { id = TblEmployeeRequestUserCompilation.FldEmployeeRequestEmployeeId });
        }

        private bool TblEmployeeRequestUserCompilationExists(long id)
        {
            return _context.TblEmployeeRequestUserCompilations.Any(e => e.FldEmployeeRequestUserCompilationId == id);
        }
    }
}
