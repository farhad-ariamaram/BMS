using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechnicalInfoWebApp.Models;

namespace TechnicalInfoWebApp.Pages.TechnicalInfoDataTypePage
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
        ViewData["FldDataDisplayTypeId"] = new SelectList(_context.TblDataDisplayTypes, "FldDataDisplayTypeId", "FldDataDisplayTypeTxt");
        ViewData["FldParametersId"] = new SelectList(_context.TblParameters, "FldParametersId", "FldParametersText");
            return Page();
        }

        [BindProperty]
        public TblTechnicalInfoDataType TblTechnicalInfoDataType { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TblTechnicalInfoDataTypes.Add(TblTechnicalInfoDataType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
