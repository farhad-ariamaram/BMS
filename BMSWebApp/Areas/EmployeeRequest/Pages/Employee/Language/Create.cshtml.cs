using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using EmployeeRequest.Models;

namespace EmployeeRequest.Pages.Employee.Language
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

            ViewData["FldEmployeeRequestUserLanguageLanguageTypeId"] = new SelectList(_context.TblEmployeeRequestLanguageTypes, "FldEmployeeRequestLanguageTypeId", "FldEmployeeRequestLanguageTypeLanguageType");
            return Page();
        }

        [BindProperty]
        public TblEmployeeRequestUserLanguage TblEmployeeRequestUserLanguage { get; set; }

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

            long lastid = _context.TblEmployeeRequestUserLanguages.OrderByDescending(a => a.FldEmployeeRequestUserLanguageId).FirstOrDefault().FldEmployeeRequestUserLanguageId;
            TblEmployeeRequestUserLanguage.FldEmployeeRequestUserLanguageId = lastid + 1;
            _context.TblEmployeeRequestUserLanguages.Add(TblEmployeeRequestUserLanguage);

            _context.TblEmployeeRequestUserLanguages.Add(TblEmployeeRequestUserLanguage);

            TblEmployeeRequestEmployeeEditLog t = new TblEmployeeRequestEmployeeEditLog()
            {
                FldEmployeeRequestEmployeeEditLogDate = DateTime.Now,
                FldEmployeeRequestUserId = Int64.Parse(uid),
                FldEmployeeRequestEmployeeId = TblEmployeeRequestUserLanguage.FldEmployeeRequestEmployeeId,
                FldEmployeeRequestEmployeeEditLogSection = "Language-Create"
            };
            _context.TblEmployeeRequestEmployeeEditLogs.Add(t);

            await _context.SaveChangesAsync();

            return RedirectToPage("Index", new { id = TblEmployeeRequestUserLanguage.FldEmployeeRequestEmployeeId });
        }
    }
}
