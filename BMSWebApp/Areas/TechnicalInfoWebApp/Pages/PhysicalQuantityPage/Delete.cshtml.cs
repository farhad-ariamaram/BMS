using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TechnicalInfoWebApp.Models;

namespace TechnicalInfoWebApp.Pages.PhysicalQuantityPage
{
    public class DeleteModel : PageModel
    {
        private readonly TechnicalInfoWebApp.Models.TechnicalInfoDBContext _context;

        public DeleteModel(TechnicalInfoWebApp.Models.TechnicalInfoDBContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblPhysicalQuantity = await _context.TblPhysicalQuantities.FindAsync(id);

            if (TblPhysicalQuantity != null)
            {
                _context.TblPhysicalQuantities.Remove(TblPhysicalQuantity);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
