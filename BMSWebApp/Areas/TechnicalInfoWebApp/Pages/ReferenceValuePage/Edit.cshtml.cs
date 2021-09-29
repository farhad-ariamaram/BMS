using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechnicalInfoWebApp.Models;

namespace TechnicalInfoWebApp.Pages.ReferenceValuePage
{
    public class EditModel : PageModel
    {
        private readonly TechnicalInfoWebApp.Models.TechnicalInfoDBContext _context;

        public EditModel(TechnicalInfoWebApp.Models.TechnicalInfoDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblReferenceValue TblReferenceValue { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblReferenceValue = await _context.TblReferenceValues
                .Include(t => t.FldReferenceTechnicalInfoGroup)
                .Include(t => t.FldTechnicalInfo).FirstOrDefaultAsync(m => m.FldReferenceValuesId == id);

            if (TblReferenceValue == null)
            {
                return NotFound();
            }
           ViewData["FldReferenceTechnicalInfoGroupId"] = new SelectList(_context.TblReferenceTechnicalInfoGroups, "FldReferenceTechnicalInfoGroupId", "FldReferenceTechnicalInfoGroupReferenceId");
           ViewData["FldTechnicalInfoId"] = new SelectList(_context.TblTechnicalInfos, "FldTechnicalInfoId", "FldTechnicalInfoTxt");
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

            _context.Attach(TblReferenceValue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblReferenceValueExists(TblReferenceValue.FldReferenceValuesId))
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

        private bool TblReferenceValueExists(Guid id)
        {
            return _context.TblReferenceValues.Any(e => e.FldReferenceValuesId == id);
        }
    }
}
