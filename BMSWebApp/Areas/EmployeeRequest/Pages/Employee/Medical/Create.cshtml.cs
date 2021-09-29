using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeRequest.Models;
using Microsoft.AspNetCore.Http;

namespace EmployeeRequest.Pages.Employee.Medical
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

            return Page();
        }

        [BindProperty]
        public TblEmployeeRequestMedicalRecord TblEmployeeRequestMedicalRecord { get; set; }

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

            long lastid = _context.TblEmployeeRequestMedicalRecords.OrderByDescending(a => a.FldEmployeeRequestMedicalRecordId).FirstOrDefault().FldEmployeeRequestMedicalRecordId;
            TblEmployeeRequestMedicalRecord.FldEmployeeRequestMedicalRecordId = lastid + 1;
            _context.TblEmployeeRequestMedicalRecords.Add(TblEmployeeRequestMedicalRecord);

            _context.TblEmployeeRequestMedicalRecords.Add(TblEmployeeRequestMedicalRecord);

            TblEmployeeRequestEmployeeEditLog t = new TblEmployeeRequestEmployeeEditLog()
            {
                FldEmployeeRequestEmployeeEditLogDate = DateTime.Now,
                FldEmployeeRequestUserId = Int64.Parse(uid),
                FldEmployeeRequestEmployeeId = TblEmployeeRequestMedicalRecord.FldEmployeeRequestEmployeeId,
                FldEmployeeRequestEmployeeEditLogSection = "Medical-Create"
            };
            _context.TblEmployeeRequestEmployeeEditLogs.Add(t);

            await _context.SaveChangesAsync();

            return RedirectToPage("Index", new { id = TblEmployeeRequestMedicalRecord.FldEmployeeRequestEmployeeId });
        }
    }
}
