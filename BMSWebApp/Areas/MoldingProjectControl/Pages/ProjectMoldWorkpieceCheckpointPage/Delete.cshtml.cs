using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoldingProjectControlWebApp.Models;

namespace MoldingProjectControlWebApp.Pages.ProjectMoldWorkpieceCheckpointPage
{
    public class DeleteModel : PageModel
    {
        private readonly MoldingProjectControlWebApp.Models.MoldingProjectControlDBContext _context;

        public DeleteModel(MoldingProjectControlWebApp.Models.MoldingProjectControlDBContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblProjectMoldWorkpieceCheckpoint = await _context.TblProjectMoldWorkpieceCheckpoints.FindAsync(id);

            if (TblProjectMoldWorkpieceCheckpoint != null)
            {
                _context.TblProjectMoldWorkpieceCheckpoints.Remove(TblProjectMoldWorkpieceCheckpoint);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
