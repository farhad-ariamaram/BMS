using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectManagementWebApp.Models;

namespace ProjectManagementWebApp.Pages.CommunicationStepPage
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectManagementDBContext _context;

        public DeleteModel(ProjectManagementDBContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblCommunicationStep = await _context.TblCommunicationSteps.FindAsync(id);

            if (TblCommunicationStep != null)
            {
                _context.TblCommunicationSteps.Remove(TblCommunicationStep);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
