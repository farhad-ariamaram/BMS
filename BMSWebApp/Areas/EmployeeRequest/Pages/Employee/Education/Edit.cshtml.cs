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

namespace EmployeeRequest.Pages.Employee.Education
{
    public class EditModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public EditModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblCustomerDegree TblCustomerDegree { get; set; }

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

            TblCustomerDegree = await _context.TblCustomerDegrees
                    .Include(t => t.Diploma)
                    .Include(t => t.Education)
                    .Include(t => t.User).FirstOrDefaultAsync(m => m.FldCustomerDegreeId == id);

            if (TblCustomerDegree == null)
            {
                return NotFound();
            }
            ViewData["DiplomaId"] = new SelectList(_context.PayDiplomas, "DiplomaId", "DiplomaName");
            ViewData["EducationId"] = new SelectList(_context.PayEducations, "EducationId", "EducationName");
            ViewData["startdate"] = TblCustomerDegree.FldStartDate.toPersianDate();
            ViewData["enddate"] = TblCustomerDegree.FldEndDate.toPersianDate();
            ViewData["exdate"] = TblCustomerDegree.FldExportDate.toPersianDate();
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
                ViewData["DiplomaId"] = new SelectList(_context.PayDiplomas, "DiplomaId", "DiplomaName");
                ViewData["EducationId"] = new SelectList(_context.PayEducations, "EducationId", "EducationName");
                ViewData["startdate"] = TblCustomerDegree.FldStartDate.toPersianDate();
                ViewData["enddate"] = TblCustomerDegree.FldEndDate.toPersianDate();
                ViewData["exdate"] = TblCustomerDegree.FldExportDate.toPersianDate();
                return Page();
            }

            _context.Attach(TblCustomerDegree).State = EntityState.Modified;

            TblEmployeeRequestEmployeeEditLog t = new TblEmployeeRequestEmployeeEditLog()
            {
                FldEmployeeRequestEmployeeEditLogDate = DateTime.Now,
                FldEmployeeRequestUserId = Int64.Parse(uid),
                FldEmployeeRequestEmployeeId = TblCustomerDegree.UserId,
                FldEmployeeRequestEmployeeEditLogSection = "Education-Edit"
            };

            _context.TblEmployeeRequestEmployeeEditLogs.Add(t);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCustomerDegreeExists(TblCustomerDegree.FldCustomerDegreeId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("Index", new { id = TblCustomerDegree.UserId });
        }

        private bool TblCustomerDegreeExists(long id)
        {
            return _context.TblCustomerDegrees.Any(e => e.FldCustomerDegreeId == id);
        }
    }
}
