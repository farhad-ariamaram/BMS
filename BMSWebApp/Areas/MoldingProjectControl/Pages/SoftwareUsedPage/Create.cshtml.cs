using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoldingProjectControlWebApp.Models;
using MoldingProjectControlWebApp.ViewModels;

namespace MoldingProjectControlWebApp.Pages.SoftwareUsedPage
{
    public class CreateModel : PageModel
    {
        private readonly MoldingProjectControlWebApp.Models.MoldingProjectControlDBContext _context;

        public CreateModel(MoldingProjectControlWebApp.Models.MoldingProjectControlDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblSoftwareUsed TblSoftwareUsed { get; set; }

        [BindProperty]
        public SoftwareUsedProjectFileTypeVM softwareUsedProjectFileTypeVM { get; set; }

        public void OnGet()
        {
            softwareUsedProjectFileTypeVM = new SoftwareUsedProjectFileTypeVM
            {
                SelectedIds = new Guid[] { },
                Items = _context.TblProjectFileTypes.Select(x => new SelectListItem
                {
                    Value = x.FldProjectFileTypeId.ToString(),
                    Text = x.FldProjectFileTypeTxt
                })
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TblSoftwareUseds.Add(TblSoftwareUsed);

            await _context.SaveChangesAsync();

            if (softwareUsedProjectFileTypeVM.SelectedIds != null)
            {
                foreach (var item in softwareUsedProjectFileTypeVM.SelectedIds)
                {
                    await _context.TblSoftwareUsedProjectFileTypes.AddAsync(new TblSoftwareUsedProjectFileType
                    {
                        FldProjectFileTypeId = item,
                        FldSoftwareUsedId = TblSoftwareUsed.FldSoftwareUsedId
                    });
                }
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
