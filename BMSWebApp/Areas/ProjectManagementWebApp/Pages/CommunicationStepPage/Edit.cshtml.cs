using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectManagementWebApp.Models;

namespace ProjectManagementWebApp.Pages.CommunicationStepPage
{
    public class EditModel : PageModel
    {
        private readonly ProjectManagementDBContext _context;

        public EditModel(ProjectManagementDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblCommunicationStep TblCommunicationStep { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblCommunicationStep = await _context.TblCommunicationSteps
                .Include(t => t.FldImplementationSteps)
                .Include(t => t.FldImplementationStepsRelated)
                .Include(t => t.FldTypeOfCommunicationStep).FirstOrDefaultAsync(m => m.FldCommunicationStepId == id);

            if (TblCommunicationStep == null)
            {
                return NotFound();
            }
            ViewData["FldImplementationStepsId"] = new SelectList(_context.TblImplementationSteps, "FldImplementationStepsId", "FldImplementationStepsTxt");
            ViewData["FldImplementationStepsRelatedId"] = new SelectList(_context.TblImplementationSteps, "FldImplementationStepsId", "FldImplementationStepsTxt");
            ViewData["FldTypeOfCommunicationStepId"] = new SelectList(_context.TblTypeOfCommunicationSteps, "FldTypeOfCommunicationStepId", "FldTypeOfCommunicationStepTxt");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TblCommunicationStep).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCommunicationStepExists(TblCommunicationStep.FldCommunicationStepId))
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

        private bool TblCommunicationStepExists(Guid id)
        {
            return _context.TblCommunicationSteps.Any(e => e.FldCommunicationStepId == id);
        }
    }
}
