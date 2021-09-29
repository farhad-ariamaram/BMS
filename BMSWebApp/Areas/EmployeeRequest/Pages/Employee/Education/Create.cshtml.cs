using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using EmployeeRequest.Models;

namespace EmployeeRequest.Pages.Employee.Education
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

            ViewData["DiplomaId"] = new SelectList(_context.PayDiplomas, "DiplomaId", "DiplomaName");
            ViewData["EducationId"] = new SelectList(_context.PayEducations, "EducationId", "EducationName");
            return Page();
        }

        [BindProperty]
        public TblCustomerDegree TblCustomerDegree { get; set; }

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

            long lastid = _context.TblCustomerDegrees.OrderByDescending(a => a.FldCustomerDegreeId).FirstOrDefault().FldCustomerDegreeId;
            TblCustomerDegree.FldCustomerDegreeId = lastid + 1;
            _context.TblCustomerDegrees.Add(TblCustomerDegree);

            _context.TblCustomerDegrees.Add(TblCustomerDegree);

            TblEmployeeRequestEmployeeEditLog t = new TblEmployeeRequestEmployeeEditLog()
            {
                FldEmployeeRequestEmployeeEditLogDate = DateTime.Now,
                FldEmployeeRequestUserId = Int64.Parse(uid),
                FldEmployeeRequestEmployeeId = TblCustomerDegree.UserId,
                FldEmployeeRequestEmployeeEditLogSection = "Education-Create"
            };
            _context.TblEmployeeRequestEmployeeEditLogs.Add(t);

            await _context.SaveChangesAsync();

            return RedirectToPage("Index", new { id = TblCustomerDegree.UserId });
        }
    }
}
