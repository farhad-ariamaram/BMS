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

namespace EmployeeRequest.Pages.Employee.PrimaryInformation
{
    public class EditModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public EditModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblEmployeeRequestPrimaryInformation TblEmployeeRequestPrimaryInformation { get; set; }

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

            TblEmployeeRequestPrimaryInformation = await _context.TblEmployeeRequestPrimaryInformations
                    .Include(t => t.FldEmployeeRequestEmployee).FirstOrDefaultAsync(m => m.FldEmployeeRequestPrimaryInformationId == id);

            if (TblEmployeeRequestPrimaryInformation == null)
            {
                return NotFound();
            }

            ViewData["birthdate"] = TblEmployeeRequestPrimaryInformation.FldEmployeeRequestPrimaryInformationBirthDate.toPersianDate();

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
                ViewData["birthdate"] = TblEmployeeRequestPrimaryInformation.FldEmployeeRequestPrimaryInformationBirthDate.toPersianDate();

                return Page();
            }

            _context.Attach(TblEmployeeRequestPrimaryInformation).State = EntityState.Modified;

            TblEmployeeRequestEmployeeEditLog t = new TblEmployeeRequestEmployeeEditLog()
            {
                FldEmployeeRequestEmployeeEditLogDate = DateTime.Now,
                FldEmployeeRequestUserId = Int64.Parse(uid),
                FldEmployeeRequestEmployeeId = TblEmployeeRequestPrimaryInformation.FldEmployeeRequestEmployeeId,
                FldEmployeeRequestEmployeeEditLogSection = "Primary-Edit"
            };

            _context.TblEmployeeRequestEmployeeEditLogs.Add(t);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblEmployeeRequestPrimaryInformationExists(TblEmployeeRequestPrimaryInformation.FldEmployeeRequestPrimaryInformationId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("Index", new { id = TblEmployeeRequestPrimaryInformation.FldEmployeeRequestEmployeeId });
        }

        private bool TblEmployeeRequestPrimaryInformationExists(long id)
        {
            return _context.TblEmployeeRequestPrimaryInformations.Any(e => e.FldEmployeeRequestPrimaryInformationId == id);
        }
    }
}
