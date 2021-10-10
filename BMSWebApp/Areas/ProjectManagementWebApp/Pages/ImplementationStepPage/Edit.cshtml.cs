using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectManagementWebApp.Models;

namespace ProjectManagementWebApp.Pages.ImplementationStepPage
{
    public class EditModel : PageModel
    {
        private readonly ProjectManagementDBContext _context;

        public EditModel(ProjectManagementDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblImplementationStep TblImplementationStep { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblImplementationStep = await _context.TblImplementationSteps
                .Include(t => t.FldExecutionStrategy)
                .Include(t => t.FldProject).FirstOrDefaultAsync(m => m.FldImplementationStepsId == id);

            if (TblImplementationStep == null)
            {
                return NotFound();
            }
            ViewData["FldProjectTypeId"] = new SelectList(_context.TblProjectTypes, "FldProjectTypeId", "FldProjectTypeTxt");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["FldProjectTypeId"] = new SelectList(_context.TblProjectTypes, "FldProjectTypeId", "FldProjectTypeTxt");
                return Page();
            }

            _context.Attach(TblImplementationStep).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblImplementationStepExists(TblImplementationStep.FldImplementationStepsId))
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

        private bool TblImplementationStepExists(Guid id)
        {
            return _context.TblImplementationSteps.Any(e => e.FldImplementationStepsId == id);
        }
    }
}
