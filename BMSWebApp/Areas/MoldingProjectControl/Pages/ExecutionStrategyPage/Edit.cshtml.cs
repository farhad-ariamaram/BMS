using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoldingProjectControlWebApp.Models;

namespace MoldingProjectControlWebApp.Pages.ExecutionStrategyPage
{
    public class EditModel : PageModel
    {
        private readonly MoldingProjectControlWebApp.Models.MoldingProjectControlDBContext _context;

        public EditModel(MoldingProjectControlWebApp.Models.MoldingProjectControlDBContext context)
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
           ViewData["FldWorkTypeId"] = new SelectList(_context.TblWorkTypes, "FldWorkTypeId", "FldWorkTypeTxt");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TblExecutionStrategy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblExecutionStrategyExists(TblExecutionStrategy.FldExecutionStrategyId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TblExecutionStrategyExists(Guid id)
        {
            return _context.TblExecutionStrategies.Any(e => e.FldExecutionStrategyId == id);
        }
    }
}
