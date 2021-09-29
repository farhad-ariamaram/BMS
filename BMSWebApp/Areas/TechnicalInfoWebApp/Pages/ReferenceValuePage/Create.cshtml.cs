using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechnicalInfoWebApp.Models;

namespace TechnicalInfoWebApp.Pages.ReferenceValuePage
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
        ViewData["FldReferenceTechnicalInfoGroupId"] = new SelectList(_context.TblReferenceTechnicalInfoGroups, "FldReferenceTechnicalInfoGroupId", "FldReferenceTechnicalInfoGroupReferenceId");
        ViewData["FldTechnicalInfoId"] = new SelectList(_context.TblTechnicalInfos, "FldTechnicalInfoId", "FldTechnicalInfoTxt");
            return Page();
        }

        [BindProperty]
        public TblReferenceValue TblReferenceValue { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TblReferenceValues.Add(TblReferenceValue);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
