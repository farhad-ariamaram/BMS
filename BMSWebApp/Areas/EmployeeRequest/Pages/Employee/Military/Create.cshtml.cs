using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using EmployeeRequest.Models;

namespace EmployeeRequest.Pages.Employee.Military
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

            ViewData["FldEmployeeRequestMilitaryId"] = new SelectList(_context.TblEmployeeRequestMilitaries, "FldEmployeeRequestMilitaryId", "FldEmployeeRequestMilitaryMilitaryStatus");
            ViewData["FldEmployeeRequestMilitaryOrganizationId"] = new SelectList(_context.TblEmployeeRequestMilitaryOrganizations, "FldEmployeeRequestMilitaryOrganizationId", "FldEmployeeRequestMilitaryOrganizationOrganizationName");
            return Page();
        }

        [BindProperty]
        public TblEmployeeRequestUserMilitary TblEmployeeRequestUserMilitary { get; set; }

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

            long lastid = _context.TblEmployeeRequestUserMilitaries.OrderByDescending(a => a.FldEmployeeRequestUserMilitaryId).FirstOrDefault().FldEmployeeRequestUserMilitaryId;
            TblEmployeeRequestUserMilitary.FldEmployeeRequestUserMilitaryId = lastid + 1;
            _context.TblEmployeeRequestUserMilitaries.Add(TblEmployeeRequestUserMilitary);

            _context.TblEmployeeRequestUserMilitaries.Add(TblEmployeeRequestUserMilitary);

            TblEmployeeRequestEmployeeEditLog t = new TblEmployeeRequestEmployeeEditLog()
            {
                FldEmployeeRequestEmployeeEditLogDate = DateTime.Now,
                FldEmployeeRequestUserId = Int64.Parse(uid),
                FldEmployeeRequestEmployeeId = TblEmployeeRequestUserMilitary.FldEmployeeRequestEmployeeId,
                FldEmployeeRequestEmployeeEditLogSection = "Military-Create"
            };
            _context.TblEmployeeRequestEmployeeEditLogs.Add(t);

            await _context.SaveChangesAsync();

            return RedirectToPage("Index", new { id = TblEmployeeRequestUserMilitary.FldEmployeeRequestEmployeeId });
        }
    }
}
