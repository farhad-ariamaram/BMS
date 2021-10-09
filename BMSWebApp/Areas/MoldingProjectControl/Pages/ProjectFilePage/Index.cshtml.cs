using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoldingProjectControlWebApp.Models;

namespace MoldingProjectControlWebApp.Pages.ProjectFilePage
{
    public class IndexModel : PageModel
    {
        private readonly MoldingProjectControlWebApp.Models.MoldingProjectControlDBContext _context;

        public IndexModel(MoldingProjectControlWebApp.Models.MoldingProjectControlDBContext context)
        {
            _context = context;
        }

        public IList<TblProjectFile> TblProjectFile { get;set; }

        public async Task OnGetAsync()
        {
            TblProjectFile = await _context.TblProjectFiles
                .Include(t => t.FldProject)
                .Include(t => t.FldProjectFileType)
                .Include(t => t.FldWorkpiece).ToListAsync();
        }

        public async Task<IActionResult> OnGetPreviousFileAsync(Guid id)
        {
            var t = await _context.TblProjectFiles.FindAsync(id);
            if (t != null)
            {
                t.FldProjectFilesFileId = t.FldProjectFilesOldFileId;
                t.FldProjectFilesOldFileId = null;
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
