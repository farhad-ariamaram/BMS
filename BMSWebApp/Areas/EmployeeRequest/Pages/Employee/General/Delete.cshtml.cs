using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeRequest.Models;
using Microsoft.AspNetCore.Http;

namespace EmployeeRequest.Pages.Employee.General
{
    public class DeleteModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public DeleteModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblEmployeeRequestGeneralRecord TblEmployeeRequestGeneralRecord { get; set; }

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

            TblEmployeeRequestGeneralRecord = await _context.TblEmployeeRequestGeneralRecords
                    .Include(t => t.FldEmployeeRequestEmployee).FirstOrDefaultAsync(m => m.FldEmployeeRequestGeneralRecordId == id);

            if (TblEmployeeRequestGeneralRecord == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult>
    OnPostAsync(long? id)
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

            TblEmployeeRequestGeneralRecord = await _context.TblEmployeeRequestGeneralRecords.FindAsync(id);

            if (TblEmployeeRequestGeneralRecord != null)
            {
                _context.TblEmployeeRequestGeneralRecords.Remove(TblEmployeeRequestGeneralRecord);

                TblEmployeeRequestEmployeeEditLog t = new TblEmployeeRequestEmployeeEditLog()
                {
                    FldEmployeeRequestEmployeeEditLogDate = DateTime.Now,
                    FldEmployeeRequestUserId = Int64.Parse(uid),
                    FldEmployeeRequestEmployeeId = TblEmployeeRequestGeneralRecord.FldEmployeeRequestEmployeeId,
                    FldEmployeeRequestEmployeeEditLogSection = "General-Delete"
                };

                _context.TblEmployeeRequestEmployeeEditLogs.Add(t);

                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index", new { id = TblEmployeeRequestGeneralRecord.FldEmployeeRequestEmployeeId });
        }
    }
}
