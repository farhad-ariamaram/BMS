using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeRequest.Models;
using Microsoft.AspNetCore.Http;

namespace EmployeeRequest.Pages.Employee.Compile
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

            ViewData["FldEmployeeRequestCompilationTypeId"] = new SelectList(_context.TblEmployeeRequestCompilationTypes, "FldEmployeeRequestCompilationTypeId", "FldEmployeeRequestCompilationTypeCompilationType");
            ViewData["EmployeeId"] = id;
            return Page();
        }

        [BindProperty]
        public TblEmployeeRequestUserCompilation TblEmployeeRequestUserCompilation { get; set; }

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

            long lastid = _context.TblEmployeeRequestUserCompilations.OrderByDescending(a => a.FldEmployeeRequestUserCompilationId).FirstOrDefault().FldEmployeeRequestUserCompilationId;
            TblEmployeeRequestUserCompilation.FldEmployeeRequestUserCompilationId = lastid + 1;
            _context.TblEmployeeRequestUserCompilations.Add(TblEmployeeRequestUserCompilation);

            TblEmployeeRequestEmployeeEditLog t = new TblEmployeeRequestEmployeeEditLog()
            {
                FldEmployeeRequestEmployeeEditLogDate = DateTime.Now,
                FldEmployeeRequestUserId = Int64.Parse(uid),
                FldEmployeeRequestEmployeeId = TblEmployeeRequestUserCompilation.FldEmployeeRequestEmployeeId,
                FldEmployeeRequestEmployeeEditLogSection = "Compile-Create"
            };
            _context.TblEmployeeRequestEmployeeEditLogs.Add(t);

            await _context.SaveChangesAsync();

            return RedirectToPage("Index", new { id = TblEmployeeRequestUserCompilation.FldEmployeeRequestEmployeeId });
        }
    }
}
