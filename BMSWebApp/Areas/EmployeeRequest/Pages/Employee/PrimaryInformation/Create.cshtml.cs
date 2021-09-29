using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using EmployeeRequest.Models;

namespace EmployeeRequest.Pages.Employee.PrimaryInformation
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
        public TblEmployeeRequestPrimaryInformation TblEmployeeRequestPrimaryInformation { get; set; }

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

            long lastid = _context.TblEmployeeRequestPrimaryInformations.OrderByDescending(a => a.FldEmployeeRequestPrimaryInformationId).FirstOrDefault().FldEmployeeRequestPrimaryInformationId;
            TblEmployeeRequestPrimaryInformation.FldEmployeeRequestPrimaryInformationId = lastid + 1;
            _context.TblEmployeeRequestPrimaryInformations.Add(TblEmployeeRequestPrimaryInformation);

            _context.TblEmployeeRequestPrimaryInformations.Add(TblEmployeeRequestPrimaryInformation);

            TblEmployeeRequestEmployeeEditLog t = new TblEmployeeRequestEmployeeEditLog()
            {
                FldEmployeeRequestEmployeeEditLogDate = DateTime.Now,
                FldEmployeeRequestUserId = Int64.Parse(uid),
                FldEmployeeRequestEmployeeId = TblEmployeeRequestPrimaryInformation.FldEmployeeRequestEmployeeId,
                FldEmployeeRequestEmployeeEditLogSection = "Primary-Create"
            };
            _context.TblEmployeeRequestEmployeeEditLogs.Add(t);

            await _context.SaveChangesAsync();

            return RedirectToPage("Index", new { id = TblEmployeeRequestPrimaryInformation.FldEmployeeRequestEmployeeId });
        }
    }
}
