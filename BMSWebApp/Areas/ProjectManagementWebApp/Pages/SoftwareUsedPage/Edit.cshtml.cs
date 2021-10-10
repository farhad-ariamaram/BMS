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

namespace ProjectManagementWebApp.Pages.SoftwareUsedPage
{
    public class EditModel : PageModel
    {
        private readonly ProjectManagementDBContext _context;

        public EditModel(ProjectManagementDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblSoftwareUsed TblSoftwareUsed { get; set; }

        [BindProperty]
        public SoftwareUsedProjectFileTypeVM softwareUsedProjectFileTypeVM { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblSoftwareUsed = await _context.TblSoftwareUseds.FirstOrDefaultAsync(m => m.FldSoftwareUsedId == id);

            if (TblSoftwareUsed == null)
            {
                return NotFound();
            }

            softwareUsedProjectFileTypeVM = new SoftwareUsedProjectFileTypeVM
            {
                SelectedIds = _context.TblSoftwareUsedProjectFileTypes.Where(x =>
                    x.FldSoftwareUsedId == id).Select(a => a.FldProjectFileTypeId).ToArray(),
                Items = _context.TblProjectFileTypes.Select(x => new SelectListItem
                {
                    Value = x.FldProjectFileTypeId.ToString(),
                    Text = x.FldProjectFileTypeTxt
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

            _context.Attach(TblSoftwareUsed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                var f = _context.TblSoftwareUsedProjectFileTypes.Where(x => x.FldSoftwareUsedId == TblSoftwareUsed.FldSoftwareUsedId);
                foreach (var item in f)
                {
                    _context.Remove(item);
                }

                await _context.SaveChangesAsync();

                if (softwareUsedProjectFileTypeVM.SelectedIds != null)
                {

                    foreach (var item in softwareUsedProjectFileTypeVM.SelectedIds)
                    {
                        await _context.TblSoftwareUsedProjectFileTypes.AddAsync(new TblSoftwareUsedProjectFileType
                        {
                            FldSoftwareUsedId = TblSoftwareUsed.FldSoftwareUsedId,
                            FldProjectFileTypeId = item
                        });
                    }

                    await _context.SaveChangesAsync();
                }

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblSoftwareUsedExists(TblSoftwareUsed.FldSoftwareUsedId))
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

        private bool TblSoftwareUsedExists(Guid id)
        {
            return _context.TblSoftwareUseds.Any(e => e.FldSoftwareUsedId == id);
        }
    }
}
