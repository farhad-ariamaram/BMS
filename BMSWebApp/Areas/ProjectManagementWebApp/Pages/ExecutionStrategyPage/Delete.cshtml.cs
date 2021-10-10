using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectManagementWebApp.Models;

namespace ProjectManagementWebApp.Pages.ExecutionStrategyPage
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectManagementDBContext _context;

        public DeleteModel(ProjectManagementDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblExecutionStrategy TblExecutionStrategy { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblExecutionStrategy = await _context.TblExecutionStrategies
                .Include(t => t.FldWorkType).FirstOrDefaultAsync(m => m.FldExecutionStrategyId == id);

            if (TblExecutionStrategy == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblExecutionStrategy = await _context.TblExecutionStrategies.FindAsync(id);

            if (TblExecutionStrategy != null)
            {
                _context.TblExecutionStrategies.Remove(TblExecutionStrategy);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
