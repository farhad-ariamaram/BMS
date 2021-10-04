using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechnicalInfoWebApp.Models;
using TechnicalInfoWebApp.ViewModels;

namespace TechnicalInfoWebApp.Pages.PhysicalQuantityPage
{
    public class EditModel : PageModel
    {
        private readonly TechnicalInfoWebApp.Models.TechnicalInfoDBContext _context;

        public EditModel(TechnicalInfoWebApp.Models.TechnicalInfoDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblPhysicalQuantity TblPhysicalQuantity { get; set; }

        [BindProperty]
        public PhysicalQuantityUnitsVM physicalQuantityUnitsVM { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblPhysicalQuantity = await _context.TblPhysicalQuantities
                .Include(t => t.FldTypeOfPhysicalQuantity).FirstOrDefaultAsync(m => m.FldPhysicalQuantityId == id);

            if (TblPhysicalQuantity == null)
            {
                return NotFound();
            }

            ViewData["FldTypeOfPhysicalQuantityId"] = new SelectList(_context.TblTypeOfPhysicalQuantities, "FldTypeOfPhysicalQuantityId", "FldTypeOfPhysicalQuantityTxt");

            physicalQuantityUnitsVM = new PhysicalQuantityUnitsVM
            {
                SelectedIds = _context.TblPhysicalQuantityUnits.Where(x =>
                    x.FldPhysicalQuantityId == id).Select(a => a.FldUnitId).ToArray(),
                Items = _context.TblUnits.Select(x => new SelectListItem
                {
                    Value = x.FldUnitId.ToString(),
                    Text = x.FldUnitName
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

            _context.Attach(TblPhysicalQuantity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                var f = _context.TblPhysicalQuantityUnits.Where(x => x.FldPhysicalQuantityId == TblPhysicalQuantity.FldPhysicalQuantityId);
                foreach (var item in f)
                {
                    _context.Remove(item);
                }

                await _context.SaveChangesAsync();

                if (physicalQuantityUnitsVM.SelectedIds != null)
                {

                    foreach (var item in physicalQuantityUnitsVM.SelectedIds)
                    {
                        await _context.TblPhysicalQuantityUnits.AddAsync(new TblPhysicalQuantityUnit
                        {
                            FldPhysicalQuantityId = TblPhysicalQuantity.FldPhysicalQuantityId,
                            FldUnitId = item
                        });
                    }

                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPhysicalQuantityExists(TblPhysicalQuantity.FldPhysicalQuantityId))
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

        private bool TblPhysicalQuantityExists(Guid id)
        {
            return _context.TblPhysicalQuantities.Any(e => e.FldPhysicalQuantityId == id);
        }
    }
}
