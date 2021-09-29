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

namespace EmployeeRequest.Pages.Employee.General
{
    public class EditModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public EditModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblEmployeeRequestGeneralRecord TblEmployeeRequestGeneralRecord { get; set; }

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

            TblEmployeeRequestGeneralRecord = await _context.TblEmployeeRequestGeneralRecords
                        .Include(t => t.FldEmployeeRequestEmployee).FirstOrDefaultAsync(m => m.FldEmployeeRequestGeneralRecordId == id);

            if (TblEmployeeRequestGeneralRecord == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult>
        OnPostAsync()
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

            _context.Attach(TblEmployeeRequestGeneralRecord).State = EntityState.Modified;

            TblEmployeeRequestEmployeeEditLog t = new TblEmployeeRequestEmployeeEditLog()
            {
                FldEmployeeRequestEmployeeEditLogDate = DateTime.Now,
                FldEmployeeRequestUserId = Int64.Parse(uid),
                FldEmployeeRequestEmployeeId = TblEmployeeRequestGeneralRecord.FldEmployeeRequestEmployeeId,
                FldEmployeeRequestEmployeeEditLogSection = "General-Edit"
            };

            _context.TblEmployeeRequestEmployeeEditLogs.Add(t);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblEmployeeRequestGeneralRecordExists(TblEmployeeRequestGeneralRecord.FldEmployeeRequestGeneralRecordId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("Index", new { id = TblEmployeeRequestGeneralRecord.FldEmployeeRequestEmployeeId });
        }

        private bool TblEmployeeRequestGeneralRecordExists(long id)
        {
            return _context.TblEmployeeRequestGeneralRecords.Any(e => e.FldEmployeeRequestGeneralRecordId == id);
        }
    }
}
