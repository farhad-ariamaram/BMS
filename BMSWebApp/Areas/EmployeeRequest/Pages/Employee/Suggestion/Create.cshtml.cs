using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeRequest.Models;
using Microsoft.AspNetCore.Http;

namespace EmployeeRequest.Pages.Employee.Suggestion
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
            ViewData["UserId"] = new SelectList(_context.TblEmployeeRequestEmployees, "FldEmployeeRequestEmployeeId", "FldEmployeeRequestEmployeeId");
            return Page();
        }

        [BindProperty]
        public TblUserSuggestion TblUserSuggestion { get; set; }

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

            int lastid = _context.TblUserSuggestions.OrderByDescending(a => a.Id).FirstOrDefault().Id;
            TblUserSuggestion.Id = lastid + 1;
            _context.TblUserSuggestions.Add(TblUserSuggestion);

            TblEmployeeRequestEmployeeEditLog t = new TblEmployeeRequestEmployeeEditLog()
            {
                FldEmployeeRequestEmployeeEditLogDate = DateTime.Now,
                FldEmployeeRequestUserId = Int64.Parse(uid),
                FldEmployeeRequestEmployeeId = TblUserSuggestion.UserId,
                FldEmployeeRequestEmployeeEditLogSection = "Suggestion-Create"
            };
            _context.TblEmployeeRequestEmployeeEditLogs.Add(t);

            await _context.SaveChangesAsync();

            _context.TblUserSuggestions.Add(TblUserSuggestion);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { id = TblUserSuggestion.UserId });
        }
    }
}
