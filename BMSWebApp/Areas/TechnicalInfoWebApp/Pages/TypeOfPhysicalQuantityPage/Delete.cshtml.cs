using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TechnicalInfoWebApp.Models;

namespace TechnicalInfoWebApp.Pages.TypeOfPhysicalQuantityPage
{
    public class DeleteModel : PageModel
    {
        private readonly TechnicalInfoWebApp.Models.TechnicalInfoDBContext _context;

        public DeleteModel(TechnicalInfoWebApp.Models.TechnicalInfoDBContext context)
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

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblTypeOfPhysicalQuantity = await _context.TblTypeOfPhysicalQuantities.FindAsync(id);

            if (TblTypeOfPhysicalQuantity != null)
            {
                _context.TblTypeOfPhysicalQuantities.Remove(TblTypeOfPhysicalQuantity);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
