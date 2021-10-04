using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechnicalInfoWebApp.Models;
using TechnicalInfoWebApp.ViewModels;

namespace TechnicalInfoWebApp.Pages.PhysicalQuantityPage
{
    public class CreateModel : PageModel
    {
        private readonly TechnicalInfoWebApp.Models.TechnicalInfoDBContext _context;

        public CreateModel(TechnicalInfoWebApp.Models.TechnicalInfoDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblPhysicalQuantity TblPhysicalQuantity { get; set; }

        [BindProperty]
        public PhysicalQuantityUnitsVM physicalQuantityUnitsVM { get; set; }

        public IActionResult OnGet()
        {
            ViewData["FldTypeOfPhysicalQuantityId"] = new SelectList(_context.TblTypeOfPhysicalQuantities, "FldTypeOfPhysicalQuantityId", "FldTypeOfPhysicalQuantityTxt");

            physicalQuantityUnitsVM = new PhysicalQuantityUnitsVM
            {
                SelectedIds = new Guid[] { },
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

            _context.TblPhysicalQuantities.Add(TblPhysicalQuantity);
            await _context.SaveChangesAsync();

            if (physicalQuantityUnitsVM.SelectedIds != null)
            {
                foreach (var item in physicalQuantityUnitsVM.SelectedIds)
                {
                    await _context.TblPhysicalQuantityUnits.AddAsync(new TblPhysicalQuantityUnit
                    {
                        FldUnitId = item,
                        FldPhysicalQuantityId = TblPhysicalQuantity.FldPhysicalQuantityId
                    });
                }

                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
