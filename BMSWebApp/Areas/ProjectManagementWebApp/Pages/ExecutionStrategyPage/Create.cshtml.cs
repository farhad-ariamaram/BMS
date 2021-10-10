using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManagementWebApp.Models;

namespace ProjectManagementWebApp.Pages.ExecutionStrategyPage
{
    public class CreateModel : PageModel
    {
        private readonly ProjectManagementDBContext _context;

        public CreateModel(ProjectManagementDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["FldWorkTypeId"] = new SelectList(_context.TblWorkTypes, "FldWorkTypeId", "FldWorkTypeTxt");
            return Page();
        }

        [BindProperty]
        public TblExecutionStrategy TblExecutionStrategy { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TblExecutionStrategies.Add(TblExecutionStrategy);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
