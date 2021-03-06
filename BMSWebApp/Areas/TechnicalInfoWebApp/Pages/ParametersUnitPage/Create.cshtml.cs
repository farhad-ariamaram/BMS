using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechnicalInfoWebApp.Models;

namespace TechnicalInfoWebApp.Pages.ParametersUnitPage
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
        ViewData["FldParametersId"] = new SelectList(_context.TblParameters, "FldParametersId", "FldParametersText");
        ViewData["FldUnitId"] = new SelectList(_context.TblUnits, "FldUnitId", "FldUnitName");
            return Page();
        }

        [BindProperty]
        public TblParametersUnit TblParametersUnit { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TblParametersUnits.Add(TblParametersUnit);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
