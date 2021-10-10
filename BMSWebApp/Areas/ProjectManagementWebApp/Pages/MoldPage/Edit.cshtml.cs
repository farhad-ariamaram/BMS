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

namespace ProjectManagementWebApp.Pages.MoldPage
{
    public class EditModel : PageModel
    {
        private readonly ProjectManagementDBContext _context;

        public EditModel(ProjectManagementDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MoldWorkpieceVM moldWorkpieceVM { get; set; }

        [BindProperty]
        public TblMold TblMold { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblMold = await _context.TblMolds.FirstOrDefaultAsync(m => m.FldMoldId == id);

            if (TblMold == null)
            {
                return NotFound();
            }

            moldWorkpieceVM = new MoldWorkpieceVM
            {
                SelectedIds = _context.TblMoldWorkpieces.Where(x =>
                    x.FldMoldId == id).Select(a => a.FldWorkpieceId).ToArray(),
                Items = _context.TblWorkpieces.Select(x => new SelectListItem
                {
                    Value = x.FldWorkpieceId.ToString(),
                    Text = x.FldWorkpieceTxt
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

            _context.Attach(TblMold).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                var f = _context.TblMoldWorkpieces.Where(x => x.FldMoldId == TblMold.FldMoldId);
                foreach (var item in f)
                {
                    _context.Remove(item);
                }

                await _context.SaveChangesAsync();

                if (moldWorkpieceVM.SelectedIds != null)
                {

                    foreach (var item in moldWorkpieceVM.SelectedIds)
                    {
                        await _context.TblMoldWorkpieces.AddAsync(new TblMoldWorkpiece
                        {
                            FldMoldId = TblMold.FldMoldId,
                            FldWorkpieceId = item
                        });
                    }

                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblMoldExists(TblMold.FldMoldId))
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

        private bool TblMoldExists(Guid id)
        {
            return _context.TblMolds.Any(e => e.FldMoldId == id);
        }
    }
}
