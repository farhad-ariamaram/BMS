using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectManagementWebApp.Models;

namespace ProjectManagementWebApp.Pages.ProjectPage
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectManagementDBContext _context;

        public DeleteModel(ProjectManagementDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblProject TblProject { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblProject = await _context.TblProjects.Include(t=>t.FldProjectType).FirstOrDefaultAsync(m => m.FldProjectId == id);

            if (TblProject == null)
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

            var f = _context.TblProjectMolds.Where(x => x.FldProjectId == TblProject.FldProjectId);
            foreach (var item in f)
            {
                _context.Remove(item);
            }
            await _context.SaveChangesAsync();

            TblProject = await _context.TblProjects.FindAsync(id);

            if (TblProject != null)
            {
                _context.TblProjects.Remove(TblProject);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
