using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectManagementWebApp.Models;

namespace ProjectManagementWebApp.Pages.ProjectMoldWorkpieceCheckpointPage
{
    public class EditModel : PageModel
    {
        private readonly ProjectManagementDBContext _context;

        public EditModel(ProjectManagementDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblProjectMoldWorkpieceCheckpoint TblProjectMoldWorkpieceCheckpoint { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblProjectMoldWorkpieceCheckpoint = await _context.TblProjectMoldWorkpieceCheckpoints
                .Include(t => t.FldProjectMoldWorkpiece).FirstOrDefaultAsync(m => m.FldProjectMoldWorkpieceCheckpointId == id);

            if (TblProjectMoldWorkpieceCheckpoint == null)
            {
                return NotFound();
            }
           ViewData["FldProjectMoldWorkpieceId"] = new SelectList(_context.TblProjectMoldWorkpieces, "FldProjectMoldWorkpieceId", "FldProjectMoldWorkpieceId");
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

            _context.Attach(TblProjectMoldWorkpieceCheckpoint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblProjectMoldWorkpieceCheckpointExists(TblProjectMoldWorkpieceCheckpoint.FldProjectMoldWorkpieceCheckpointId))
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

        private bool TblProjectMoldWorkpieceCheckpointExists(Guid id)
        {
            return _context.TblProjectMoldWorkpieceCheckpoints.Any(e => e.FldProjectMoldWorkpieceCheckpointId == id);
        }
    }
}
