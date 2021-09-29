using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechnicalInfoWebApp.Models;

namespace TechnicalInfoWebApp.Pages.TypeOfPhysicalQuantityPage
{
    public class EditModel : PageModel
    {
        private readonly TechnicalInfoWebApp.Models.TechnicalInfoDBContext _context;

        public EditModel(TechnicalInfoWebApp.Models.TechnicalInfoDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblTypeOfPhysicalQuantity TblTypeOfPhysicalQuantity { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblTypeOfPhysicalQuantity = await _context.TblTypeOfPhysicalQuantities.FirstOrDefaultAsync(m => m.FldTypeOfPhysicalQuantityId == id);

            if (TblTypeOfPhysicalQuantity == null)
            {
                return NotFound();
            }
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

            _context.Attach(TblTypeOfPhysicalQuantity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblTypeOfPhysicalQuantityExists(TblTypeOfPhysicalQuantity.FldTypeOfPhysicalQuantityId))
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

        private bool TblTypeOfPhysicalQuantityExists(Guid id)
        {
            return _context.TblTypeOfPhysicalQuantities.Any(e => e.FldTypeOfPhysicalQuantityId == id);
        }
    }
}
