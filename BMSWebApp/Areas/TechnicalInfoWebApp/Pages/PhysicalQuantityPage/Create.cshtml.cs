using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechnicalInfoWebApp.Models;

namespace TechnicalInfoWebApp.Pages.PhysicalQuantityPage
{
    public class CreateModel : PageModel
    {
        private readonly TechnicalInfoWebApp.Models.TechnicalInfoDBContext _context;

        public CreateModel(TechnicalInfoWebApp.Models.TechnicalInfoDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["FldTypeOfPhysicalQuantityId"] = new SelectList(_context.TblTypeOfPhysicalQuantities, "FldTypeOfPhysicalQuantityId", "FldTypeOfPhysicalQuantityTxt");
            return Page();
        }

        [BindProperty]
        public TblPhysicalQuantity TblPhysicalQuantity { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TblPhysicalQuantities.Add(TblPhysicalQuantity);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
