using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeRequest.Models;
using Microsoft.AspNetCore.Http;

namespace EmployeeRequest.Pages.Employee.Medical
{
    public class DeleteModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public DeleteModel(EmployeeRequestDBContext context)
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

            TblEmployeeRequestMedicalRecord = await _context.TblEmployeeRequestMedicalRecords.FindAsync(id);

            if (TblEmployeeRequestMedicalRecord != null)
            {
                _context.TblEmployeeRequestMedicalRecords.Remove(TblEmployeeRequestMedicalRecord);

                TblEmployeeRequestEmployeeEditLog t = new TblEmployeeRequestEmployeeEditLog()
                {
                    FldEmployeeRequestEmployeeEditLogDate = DateTime.Now,
                    FldEmployeeRequestUserId = Int64.Parse(uid),
                    FldEmployeeRequestEmployeeId = TblEmployeeRequestMedicalRecord.FldEmployeeRequestEmployeeId,
                    FldEmployeeRequestEmployeeEditLogSection = "Medical-Delete"
                };

                _context.TblEmployeeRequestEmployeeEditLogs.Add(t);

                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index", new { id = TblEmployeeRequestMedicalRecord.FldEmployeeRequestEmployeeId });
        }
    }
}
