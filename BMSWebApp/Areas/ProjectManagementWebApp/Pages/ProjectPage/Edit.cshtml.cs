using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectManagementWebApp.Models;
using MoldingProjectControlWebApp.ViewModels;

namespace ProjectManagementWebApp.Pages.ProjectPage
{
    public class EditModel : PageModel
    {
        private readonly ProjectManagementDBContext _context;

        public EditModel(ProjectManagementDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblProject TblProject { get; set; }

        [BindProperty]
        public ProjectMoldVM projectMoldVM { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblProject = await _context.TblProjects.FirstOrDefaultAsync(m => m.FldProjectId == id);

            if (TblProject == null)
            {
                return NotFound();
            }

            projectMoldVM = new ProjectMoldVM
            {
                SelectedIds = _context.TblProjectMolds.Where(x =>
                    x.FldProjectId == id).Select(a => a.FldMoldId).ToArray(),
                Items = _context.TblMolds.Select(x => new SelectListItem
                {
                    Value = x.FldMoldId.ToString(),
                    Text = x.FldMoldTxt
                })
            };

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TblProject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                var f = _context.TblProjectMolds.Where(x => x.FldProjectId == TblProject.FldProjectId);
                foreach (var item in f)
                {
                    _context.Remove(item);
                }

                await _context.SaveChangesAsync();

                if (projectMoldVM.SelectedIds != null)
                {

                    foreach (var item in projectMoldVM.SelectedIds)
                    {
                        await _context.TblProjectMolds.AddAsync(new TblProjectMold
                        {
                            FldProjectId = TblProject.FldProjectId,
                            FldMoldId = item
                        });
                    }

                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblProjectExists(TblProject.FldProjectId))
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

        private bool TblProjectExists(Guid id)
        {
            return _context.TblProjects.Any(e => e.FldProjectId == id);
        }
    }
}
