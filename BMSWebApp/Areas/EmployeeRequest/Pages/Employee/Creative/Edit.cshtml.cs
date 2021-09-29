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

namespace EmployeeRequest.Pages.Employee.Creative
{
    public class EditModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public EditModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblEmployeeRequestUserCreativity TblEmployeeRequestUserCreativity { get; set; }

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

            TblEmployeeRequestUserCreativity = await _context.TblEmployeeRequestUserCreativities
                .Include(t => t.FldEmployeeRequestCreativityType)
                .Include(t => t.FldEmployeeRequestEmployee).FirstOrDefaultAsync(m => m.FldEmployeeRequestUserCreativityId == id);

            if (TblEmployeeRequestUserCreativity == null)
            {
                return NotFound();
            }

            ViewData["FldEmployeeRequestCreativityTypeId"] = new SelectList(_context.TblEmployeeRequestCreativityTypes, "FldEmployeeRequestCreativityTypeId", "FldEmployeeRequestCreativityTypeCreativityType");
            ViewData["date"] = TblEmployeeRequestUserCreativity.FldEmployeeRequestUserCreativityDate.toPersianDate();

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
                ViewData["FldEmployeeRequestCreativityTypeId"] = new SelectList(_context.TblEmployeeRequestCreativityTypes, "FldEmployeeRequestCreativityTypeId", "FldEmployeeRequestCreativityTypeCreativityType");
                ViewData["date"] = TblEmployeeRequestUserCreativity.FldEmployeeRequestUserCreativityDate.toPersianDate();
                return Page();
            }

            _context.Attach(TblEmployeeRequestUserCreativity).State = EntityState.Modified;

            TblEmployeeRequestEmployeeEditLog t = new TblEmployeeRequestEmployeeEditLog()
            {
                FldEmployeeRequestEmployeeEditLogDate = DateTime.Now,
                FldEmployeeRequestUserId = Int64.Parse(uid),
                FldEmployeeRequestEmployeeId = TblEmployeeRequestUserCreativity.FldEmployeeRequestEmployeeId,
                FldEmployeeRequestEmployeeEditLogSection = "Creative-Edit"
            };

            _context.TblEmployeeRequestEmployeeEditLogs.Add(t);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblEmployeeRequestUserCreativityExists(TblEmployeeRequestUserCreativity.FldEmployeeRequestUserCreativityId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("Index", new { id = TblEmployeeRequestUserCreativity.FldEmployeeRequestEmployeeId });
        }

        private bool TblEmployeeRequestUserCreativityExists(long id)
        {
            return _context.TblEmployeeRequestUserCreativities.Any(e => e.FldEmployeeRequestUserCreativityId == id);
        }
    }
}
