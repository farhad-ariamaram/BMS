using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeRequest.Models;
using Microsoft.AspNetCore.Http;

namespace EmployeeRequest.Pages.Employee.Creative
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

            ViewData["FldEmployeeRequestCreativityTypeId"] = new SelectList(_context.TblEmployeeRequestCreativityTypes, "FldEmployeeRequestCreativityTypeId", "FldEmployeeRequestCreativityTypeCreativityType");
            ViewData["EmployeeId"] = id;
            return Page();
        }

        [BindProperty]
        public TblEmployeeRequestUserCreativity TblEmployeeRequestUserCreativity { get; set; }

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

            long lastid = _context.TblEmployeeRequestUserCreativities.OrderByDescending(a => a.FldEmployeeRequestUserCreativityId).FirstOrDefault().FldEmployeeRequestUserCreativityId;
            TblEmployeeRequestUserCreativity.FldEmployeeRequestUserCreativityId = lastid + 1;
            _context.TblEmployeeRequestUserCreativities.Add(TblEmployeeRequestUserCreativity);

            TblEmployeeRequestEmployeeEditLog t = new TblEmployeeRequestEmployeeEditLog()
            {
                FldEmployeeRequestEmployeeEditLogDate = DateTime.Now,
                FldEmployeeRequestUserId = Int64.Parse(uid),
                FldEmployeeRequestEmployeeId = TblEmployeeRequestUserCreativity.FldEmployeeRequestEmployeeId,
                FldEmployeeRequestEmployeeEditLogSection = "Creative-Create"
            };
            _context.TblEmployeeRequestEmployeeEditLogs.Add(t);

            await _context.SaveChangesAsync();

            return RedirectToPage("Index", new { id = TblEmployeeRequestUserCreativity.FldEmployeeRequestEmployeeId });
        }
    }
}
