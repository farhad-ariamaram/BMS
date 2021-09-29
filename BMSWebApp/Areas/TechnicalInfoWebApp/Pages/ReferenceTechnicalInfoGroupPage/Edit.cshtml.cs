using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechnicalInfoWebApp.Models;

namespace TechnicalInfoWebApp.Pages.ReferenceTechnicalInfoGroupPage
{
    public class EditModel : PageModel
    {
        private readonly TechnicalInfoWebApp.Models.TechnicalInfoDBContext _context;

        public EditModel(TechnicalInfoWebApp.Models.TechnicalInfoDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblReferenceTechnicalInfoGroup TblReferenceTechnicalInfoGroup { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblReferenceTechnicalInfoGroup = await _context.TblReferenceTechnicalInfoGroups
                .Include(t => t.FldReference)
                .Include(t => t.FldTechnicalInfoGroup).FirstOrDefaultAsync(m => m.FldReferenceTechnicalInfoGroupId == id);

            if (TblReferenceTechnicalInfoGroup == null)
            {
                return NotFound();
            }
           ViewData["FldReferenceId"] = new SelectList(_context.TblReferences, "FldReferenceId", "FldReferenceTxt");
           ViewData["FldTechnicalInfoGroupId"] = new SelectList(_context.TblTechnicalInfoGroups, "FldTechnicalInfoGroupId", "FldTechnicalInfoGroupTxt");
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

            _context.Attach(TblReferenceTechnicalInfoGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblReferenceTechnicalInfoGroupExists(TblReferenceTechnicalInfoGroup.FldReferenceTechnicalInfoGroupId))
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

        private bool TblReferenceTechnicalInfoGroupExists(Guid id)
        {
            return _context.TblReferenceTechnicalInfoGroups.Any(e => e.FldReferenceTechnicalInfoGroupId == id);
        }
    }
}
