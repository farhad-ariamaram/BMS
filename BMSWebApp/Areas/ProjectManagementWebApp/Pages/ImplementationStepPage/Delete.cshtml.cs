using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectManagementWebApp.Models;

namespace ProjectManagementWebApp.Pages.ImplementationStepPage
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectManagementDBContext _context;

        public DeleteModel(ProjectManagementDBContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblImplementationStep = await _context.TblImplementationSteps.FindAsync(id);

            if (TblImplementationStep != null)
            {
                _context.TblImplementationSteps.Remove(TblImplementationStep);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
