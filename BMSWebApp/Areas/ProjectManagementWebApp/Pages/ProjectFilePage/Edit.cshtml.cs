using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectManagementWebApp.Models;

namespace ProjectManagementWebApp.Pages.ProjectFilePage
{
    public class EditModel : PageModel
    {
        private readonly ProjectManagementDBContext _context;

        public EditModel(ProjectManagementDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblProjectFile TblProjectFile { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id, Guid? ProjId)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (ProjId == null)
            {
                return RedirectToPage("../Index");
            }

            ViewData["FldProjectId"] = ProjId.Value;

            TblProjectFile = await _context.TblProjectFiles
                .Include(t => t.FldProject)
                .Include(t => t.FldProjectFileType)
                .Include(t => t.FldWorkpiece).FirstOrDefaultAsync(m => m.FldProjectFilesId == id);

            if (TblProjectFile == null)
            {
                return NotFound();
            }
            ViewData["FldProjectFileTypeId"] = new SelectList(_context.TblProjectFileTypes, "FldProjectFileTypeId", "FldProjectFileTypeTxt");
            ViewData["FldWorkpieceId"] = new SelectList(_context.TblWorkpieces, "FldWorkpieceId", "FldWorkpieceTxt");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["FldProjectId"] = Request.Form["TblProjectFile.FldProjectId"].ToString();
                ViewData["FldProjectFileTypeId"] = new SelectList(_context.TblProjectFileTypes, "FldProjectFileTypeId", "FldProjectFileTypeTxt");
                ViewData["FldWorkpieceId"] = new SelectList(_context.TblWorkpieces, "FldWorkpieceId", "FldWorkpieceTxt");
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

            return RedirectToPage("./Index", new { ProjId = Request.Form["TblProjectFile.FldProjectId"].ToString() });
        }

        private bool TblProjectFileExists(Guid id)
        {
            return _context.TblProjectFiles.Any(e => e.FldProjectFilesId == id);
        }
    }
}
