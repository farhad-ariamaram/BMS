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
using EmployeeRequest.Utilities;

namespace EmployeeRequest.Pages.Employee.Military
{
    public class EditModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public EditModel(EmployeeRequestDBContext context)
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
            ViewData["FldEmployeeRequestMilitaryId"] = new SelectList(_context.TblEmployeeRequestMilitaries, "FldEmployeeRequestMilitaryId", "FldEmployeeRequestMilitaryMilitaryStatus");
            ViewData["FldEmployeeRequestMilitaryOrganizationId"] = new SelectList(_context.TblEmployeeRequestMilitaryOrganizations, "FldEmployeeRequestMilitaryOrganizationId", "FldEmployeeRequestMilitaryOrganizationOrganizationName");
            ViewData["startdate"] = TblEmployeeRequestUserMilitary.FldEmployeeRequestUserMilitaryStartDate.toPersianDate();
            ViewData["enddate"] = TblEmployeeRequestUserMilitary.FldEmployeeRequestUserMilitaryEndDate.toPersianDate();
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
                ViewData["FldEmployeeRequestMilitaryId"] = new SelectList(_context.TblEmployeeRequestMilitaries, "FldEmployeeRequestMilitaryId", "FldEmployeeRequestMilitaryMilitaryStatus");
                ViewData["FldEmployeeRequestMilitaryOrganizationId"] = new SelectList(_context.TblEmployeeRequestMilitaryOrganizations, "FldEmployeeRequestMilitaryOrganizationId", "FldEmployeeRequestMilitaryOrganizationOrganizationName");
                ViewData["startdate"] = TblEmployeeRequestUserMilitary.FldEmployeeRequestUserMilitaryStartDate.toPersianDate();
                ViewData["enddate"] = TblEmployeeRequestUserMilitary.FldEmployeeRequestUserMilitaryEndDate.toPersianDate();
                return Page();
            }

            _context.Attach(TblEmployeeRequestUserMilitary).State = EntityState.Modified;

            TblEmployeeRequestEmployeeEditLog t = new TblEmployeeRequestEmployeeEditLog()
            {
                FldEmployeeRequestEmployeeEditLogDate = DateTime.Now,
                FldEmployeeRequestUserId = Int64.Parse(uid),
                FldEmployeeRequestEmployeeId = TblEmployeeRequestUserMilitary.FldEmployeeRequestEmployeeId,
                FldEmployeeRequestEmployeeEditLogSection = "Military-Edit"
            };

            _context.TblEmployeeRequestEmployeeEditLogs.Add(t);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblEmployeeRequestUserMilitaryExists(TblEmployeeRequestUserMilitary.FldEmployeeRequestUserMilitaryId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("Index", new { id = TblEmployeeRequestUserMilitary.FldEmployeeRequestEmployeeId });
        }

        private bool TblEmployeeRequestUserMilitaryExists(long id)
        {
            return _context.TblEmployeeRequestUserMilitaries.Any(e => e.FldEmployeeRequestUserMilitaryId == id);
        }
    }
}
