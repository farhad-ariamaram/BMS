using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechnicalInfoWebApp.Models;

namespace TechnicalInfoWebApp.Pages.ReferenceTechnicalInfoGroupPage
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
        ViewData["FldReferenceId"] = new SelectList(_context.TblReferences, "FldReferenceId", "FldReferenceTxt");
        ViewData["FldTechnicalInfoGroupId"] = new SelectList(_context.TblTechnicalInfoGroups, "FldTechnicalInfoGroupId", "FldTechnicalInfoGroupTxt");
            return Page();
        }

        [BindProperty]
        public TblReferenceTechnicalInfoGroup TblReferenceTechnicalInfoGroup { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TblReferenceTechnicalInfoGroups.Add(TblReferenceTechnicalInfoGroup);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
