using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoldingProjectControlWebApp.Models;

namespace MoldingProjectControlWebApp.Pages.ProjectMoldWorkpiecePage
{
    public class EditModel : PageModel
    {
        private readonly MoldingProjectControlWebApp.Models.MoldingProjectControlDBContext _context;

        public EditModel(MoldingProjectControlWebApp.Models.MoldingProjectControlDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblProjectMoldWorkpiece TblProjectMoldWorkpiece { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblProjectMoldWorkpiece = await _context.TblProjectMoldWorkpieces
                .Include(t => t.FldProjectMold)
                .Include(t => t.FldWorkpiece).FirstOrDefaultAsync(m => m.FldProjectMoldWorkpieceId == id);

            if (TblProjectMoldWorkpiece == null)
            {
                return NotFound();
            }
           ViewData["FldProjectMoldId"] = new SelectList(_context.TblProjectMolds, "FldProjectMoldId", "FldProjectMoldId");
           ViewData["FldWorkpieceId"] = new SelectList(_context.TblWorkpieces, "FldWorkpieceId", "FldWorkpieceTxt");
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

            _context.Attach(TblProjectMoldWorkpiece).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblProjectMoldWorkpieceExists(TblProjectMoldWorkpiece.FldProjectMoldWorkpieceId))
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

        private bool TblProjectMoldWorkpieceExists(Guid id)
        {
            return _context.TblProjectMoldWorkpieces.Any(e => e.FldProjectMoldWorkpieceId == id);
        }
    }
}
