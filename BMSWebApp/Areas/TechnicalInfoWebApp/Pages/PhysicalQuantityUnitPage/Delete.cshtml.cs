using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TechnicalInfoWebApp.Models;

namespace TechnicalInfoWebApp.Pages.PhysicalQuantityUnitPage
{
    public class DeleteModel : PageModel
    {
        private readonly TechnicalInfoWebApp.Models.TechnicalInfoDBContext _context;

        public DeleteModel(TechnicalInfoWebApp.Models.TechnicalInfoDBContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblPhysicalQuantityUnit = await _context.TblPhysicalQuantityUnits.FindAsync(id);

            if (TblPhysicalQuantityUnit != null)
            {
                _context.TblPhysicalQuantityUnits.Remove(TblPhysicalQuantityUnit);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
