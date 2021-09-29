using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeRequest.Models;
using Microsoft.AspNetCore.Http;

namespace EmployeeRequest.Pages.Employee.Suggestion
{
    public class DeleteModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public DeleteModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblUserSuggestion TblUserSuggestion { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
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

            TblUserSuggestion = await _context.TblUserSuggestions
                .Include(t => t.User).FirstOrDefaultAsync(m => m.Id == id);

            if (TblUserSuggestion == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
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

            TblUserSuggestion = await _context.TblUserSuggestions.FindAsync(id);

            if (TblUserSuggestion != null)
            {
                _context.TblUserSuggestions.Remove(TblUserSuggestion);

                TblEmployeeRequestEmployeeEditLog t = new TblEmployeeRequestEmployeeEditLog()
                {
                    FldEmployeeRequestEmployeeEditLogDate = DateTime.Now,
                    FldEmployeeRequestUserId = Int64.Parse(uid),
                    FldEmployeeRequestEmployeeId = TblUserSuggestion.UserId,
                    FldEmployeeRequestEmployeeEditLogSection = "Suggestion-Delete"
                };

                _context.TblEmployeeRequestEmployeeEditLogs.Add(t);

                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new { id = TblUserSuggestion.UserId });
        }
    }
}
