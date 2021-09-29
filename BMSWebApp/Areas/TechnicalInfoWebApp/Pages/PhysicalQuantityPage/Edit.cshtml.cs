using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechnicalInfoWebApp.Models;

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

            _context.Attach(TblPhysicalQuantity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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
