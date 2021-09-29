using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechnicalInfoWebApp.Models;

namespace TechnicalInfoWebApp.Pages.PhysicalQuantityUnitPage
{
    public class EditModel : PageModel
    {
        private readonly TechnicalInfoWebApp.Models.TechnicalInfoDBContext _context;

        public EditModel(TechnicalInfoWebApp.Models.TechnicalInfoDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblPhysicalQuantityUnit TblPhysicalQuantityUnit { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblPhysicalQuantityUnit = await _context.TblPhysicalQuantityUnits
                .Include(t => t.FldPhysicalQuantity)
                .Include(t => t.FldUnit).FirstOrDefaultAsync(m => m.FldPhysicalQuantityUnitsId == id);

            if (TblPhysicalQuantityUnit == null)
            {
                return NotFound();
            }
           ViewData["FldPhysicalQuantityId"] = new SelectList(_context.TblPhysicalQuantities, "FldPhysicalQuantityId", "FldPhysicalQuantityTxt");
           ViewData["FldUnitId"] = new SelectList(_context.TblUnits, "FldUnitId", "FldUnitName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TblPhysicalQuantityUnit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPhysicalQuantityUnitExists(TblPhysicalQuantityUnit.FldPhysicalQuantityUnitsId))
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

        private bool TblPhysicalQuantityUnitExists(Guid id)
        {
            return _context.TblPhysicalQuantityUnits.Any(e => e.FldPhysicalQuantityUnitsId == id);
        }
    }
}
