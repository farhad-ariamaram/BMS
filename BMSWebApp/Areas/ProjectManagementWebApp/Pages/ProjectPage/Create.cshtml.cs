using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManagementWebApp.Models;
using MoldingProjectControlWebApp.ViewModels;

namespace ProjectManagementWebApp.Pages.ProjectPage
{
    public class CreateModel : PageModel
    {
        private readonly ProjectManagementDBContext _context;

        public CreateModel(ProjectManagementDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblProject TblProject { get; set; }

        [BindProperty]
        public ProjectMoldVM projectMoldVM { get; set; }

        public void OnGet()
        {
            projectMoldVM = new ProjectMoldVM
            {
                SelectedIds = new Guid[] { },
                Items = _context.TblMolds.Select(x => new SelectListItem
                {
                    Value = x.FldMoldId.ToString(),
                    Text = x.FldMoldTxt
                })
            };
            ViewData["FldProjectTypeId"] = new SelectList(_context.TblProjectTypes, "FldProjectTypeId", "FldProjectTypeTxt");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TblProjects.Add(TblProject);
            await _context.SaveChangesAsync();

            if (projectMoldVM.SelectedIds != null)
            {
                foreach (var item in projectMoldVM.SelectedIds)
                {
                    await _context.TblProjectMolds.AddAsync(new TblProjectMold
                    {
                        FldMoldId = item,
                        FldProjectId = TblProject.FldProjectId
                    });
                }

                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
