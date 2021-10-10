using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectManagementWebApp.Models;

namespace ProjectManagementWebApp.Pages.ProjectFilePage
{
    public class IndexModel : PageModel
    {
        private readonly ProjectManagementDBContext _context;

        public IndexModel(ProjectManagementDBContext context)
        {
            _context = context;
        }

        public IList<TblProjectFile> TblProjectFile { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? ProjId)
        {
            if (ProjId == null)
            {
                return RedirectToPage("../Index");
            }

            ViewData["ProjId"] = ProjId;

            TblProjectFile = await _context.TblProjectFiles
                .Include(t => t.FldProject)
                .Include(t => t.FldProjectFileType)
                .Include(t => t.FldWorkpiece)
                .Where(a => a.FldProjectId == ProjId.Value)
                .ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnGetPreviousFileAsync(Guid id, Guid ProjId)
        {
            var t = await _context.TblProjectFiles.FindAsync(id);
            if (t != null)
            {
                t.FldProjectFilesFileId = t.FldProjectFilesOldFileId;
                t.FldProjectFilesOldFileId = null;
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index" , new { ProjId = ProjId });
        }

        public async Task<IActionResult> OnGetDeleteAsync(Guid? id, Guid? ProjId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t = await _context.TblProjectFiles.FindAsync(id);

            if (t != null)
            {
                _context.TblProjectFiles.Remove(t);
                await _context.SaveChangesAsync();
            }

            ViewData["ProjId"] = ProjId;

            TblProjectFile = await _context.TblProjectFiles
                .Include(t => t.FldProject)
                .Include(t => t.FldProjectFileType)
                .Include(t => t.FldWorkpiece)
                .Where(a => a.FldProjectId == ProjId.Value)
                .ToListAsync();

            return Page();

            //return Redirect($"{Request.Host}{Request.Path}{Request.QueryString.ToString().Split('&')[0]}");
        }
    }
}
