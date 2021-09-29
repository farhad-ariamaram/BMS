using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechnicalInfoWebApp.Models;

namespace TechnicalInfoWebApp.Pages.TechnicalInfoDataTypesValuePage
{
    public class EditModel : PageModel
    {
        private readonly TechnicalInfoWebApp.Models.TechnicalInfoDBContext _context;

        public EditModel(TechnicalInfoWebApp.Models.TechnicalInfoDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblTechnicalInfoDataTypesValue TblTechnicalInfoDataTypesValue { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblTechnicalInfoDataTypesValue = await _context.TblTechnicalInfoDataTypesValues
                .Include(t => t.FldTechnicalInfoDataTypes).FirstOrDefaultAsync(m => m.FldTechnicalInfoDataTypesValuesId == id);

            if (TblTechnicalInfoDataTypesValue == null)
            {
                return NotFound();
            }
           ViewData["FldTechnicalInfoDataTypesId"] = new SelectList(_context.TblTechnicalInfoDataTypes, "FldTechnicalInfoDataTypesId", "FldTechnicalInfoDataTypesTxt");
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

            _context.Attach(TblTechnicalInfoDataTypesValue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblTechnicalInfoDataTypesValueExists(TblTechnicalInfoDataTypesValue.FldTechnicalInfoDataTypesValuesId))
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

        private bool TblTechnicalInfoDataTypesValueExists(Guid id)
        {
            return _context.TblTechnicalInfoDataTypesValues.Any(e => e.FldTechnicalInfoDataTypesValuesId == id);
        }
    }
}
