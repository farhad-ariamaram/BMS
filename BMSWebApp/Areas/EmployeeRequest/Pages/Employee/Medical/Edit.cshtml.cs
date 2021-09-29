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

namespace EmployeeRequest.Pages.Employee.Medical
{
    public class EditModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public EditModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblEmployeeRequestMedicalRecord TblEmployeeRequestMedicalRecord { get; set; }

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

            TblEmployeeRequestMedicalRecord = await _context.TblEmployeeRequestMedicalRecords
                        .Include(t => t.FldEmployeeRequestEmployee).FirstOrDefaultAsync(m => m.FldEmployeeRequestMedicalRecordId == id);

            if (TblEmployeeRequestMedicalRecord == null)
            {
                return NotFound();
            }

            ViewData["startdate"] = TblEmployeeRequestMedicalRecord.FldEmployeeRequestMedicalRecordStartDate.toPersianDate();
            ViewData["enddate"] = TblEmployeeRequestMedicalRecord.FldEmployeeRequestMedicalRecordEndDate.toPersianDate();

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
                ViewData["startdate"] = TblEmployeeRequestMedicalRecord.FldEmployeeRequestMedicalRecordStartDate.toPersianDate();
                ViewData["enddate"] = TblEmployeeRequestMedicalRecord.FldEmployeeRequestMedicalRecordEndDate.toPersianDate();

                return Page();
            }

            _context.Attach(TblEmployeeRequestMedicalRecord).State = EntityState.Modified;

            TblEmployeeRequestEmployeeEditLog t = new TblEmployeeRequestEmployeeEditLog()
            {
                FldEmployeeRequestEmployeeEditLogDate = DateTime.Now,
                FldEmployeeRequestUserId = Int64.Parse(uid),
                FldEmployeeRequestEmployeeId = TblEmployeeRequestMedicalRecord.FldEmployeeRequestEmployeeId,
                FldEmployeeRequestEmployeeEditLogSection = "Medical-Edit"
            };

            _context.TblEmployeeRequestEmployeeEditLogs.Add(t);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblEmployeeRequestMedicalRecordExists(TblEmployeeRequestMedicalRecord.FldEmployeeRequestMedicalRecordId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("Index", new { id = TblEmployeeRequestMedicalRecord.FldEmployeeRequestEmployeeId });
        }

        private bool TblEmployeeRequestMedicalRecordExists(long id)
        {
            return _context.TblEmployeeRequestMedicalRecords.Any(e => e.FldEmployeeRequestMedicalRecordId == id);
        }
    }
}
