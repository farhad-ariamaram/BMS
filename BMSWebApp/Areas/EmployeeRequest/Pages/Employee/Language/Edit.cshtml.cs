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

namespace EmployeeRequest.Pages.Employee.Language
{
    public class EditModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public EditModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblEmployeeRequestUserLanguage TblEmployeeRequestUserLanguage { get; set; }

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

            TblEmployeeRequestUserLanguage = await _context.TblEmployeeRequestUserLanguages
                    .Include(t => t.FldEmployeeRequestEmployee)
                    .Include(t => t.FldEmployeeRequestUserLanguageLanguageType).FirstOrDefaultAsync(m => m.FldEmployeeRequestUserLanguageId == id);

            if (TblEmployeeRequestUserLanguage == null)
            {
                return NotFound();
            }
            ViewData["FldEmployeeRequestUserLanguageLanguageTypeId"] = new SelectList(_context.TblEmployeeRequestLanguageTypes, "FldEmployeeRequestLanguageTypeId", "FldEmployeeRequestLanguageTypeLanguageType");
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

            _context.Attach(TblEmployeeRequestUserLanguage).State = EntityState.Modified;

            TblEmployeeRequestEmployeeEditLog t = new TblEmployeeRequestEmployeeEditLog()
            {
                FldEmployeeRequestEmployeeEditLogDate = DateTime.Now,
                FldEmployeeRequestUserId = Int64.Parse(uid),
                FldEmployeeRequestEmployeeId = TblEmployeeRequestUserLanguage.FldEmployeeRequestEmployeeId,
                FldEmployeeRequestEmployeeEditLogSection = "Language-Edit"
            };

            _context.TblEmployeeRequestEmployeeEditLogs.Add(t);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblEmployeeRequestUserLanguageExists(TblEmployeeRequestUserLanguage.FldEmployeeRequestUserLanguageId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("Index", new { id = TblEmployeeRequestUserLanguage.FldEmployeeRequestEmployeeId });
        }

        private bool TblEmployeeRequestUserLanguageExists(long id)
        {
            return _context.TblEmployeeRequestUserLanguages.Any(e => e.FldEmployeeRequestUserLanguageId == id);
        }
    }
}
