using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoldingProjectControlWebApp.Models;

namespace MoldingProjectControlWebApp.Pages.ProjectFilePage
{
    public class EditModel : PageModel
    {
        private readonly MoldingProjectControlWebApp.Models.MoldingProjectControlDBContext _context;

        public EditModel(MoldingProjectControlWebApp.Models.MoldingProjectControlDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblProjectFile TblProjectFile { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblProjectFile = await _context.TblProjectFiles
                .Include(t => t.FldProject)
                .Include(t => t.FldProjectFileType)
                .Include(t => t.FldWorkpiece).FirstOrDefaultAsync(m => m.FldProjectFilesId == id);

            if (TblProjectFile == null)
            {
                return NotFound();
            }
           ViewData["FldProjectId"] = new SelectList(_context.TblProjects, "FldProjectId", "FldProjectTxt");
           ViewData["FldProjectFileTypeId"] = new SelectList(_context.TblProjectFileTypes, "FldProjectFileTypeId", "FldProjectFileTypeTxt");
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

            _context.Attach(TblProjectFile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblProjectFileExists(TblProjectFile.FldProjectFilesId))
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

        private bool TblProjectFileExists(Guid id)
        {
            return _context.TblProjectFiles.Any(e => e.FldProjectFilesId == id);
        }
    }
}
