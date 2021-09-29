using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechnicalInfoWebApp.Models;

namespace TechnicalInfoWebApp.Pages.TechnicalInfoDataTypePage
{
    public class EditModel : PageModel
    {
        private readonly TechnicalInfoWebApp.Models.TechnicalInfoDBContext _context;

        public EditModel(TechnicalInfoWebApp.Models.TechnicalInfoDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblTechnicalInfoDataType TblTechnicalInfoDataType { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblTechnicalInfoDataType = await _context.TblTechnicalInfoDataTypes
                .Include(t => t.FldDataDisplayType)
                .Include(t => t.FldParameters).FirstOrDefaultAsync(m => m.FldTechnicalInfoDataTypesId == id);

            if (TblTechnicalInfoDataType == null)
            {
                return NotFound();
            }
           ViewData["FldDataDisplayTypeId"] = new SelectList(_context.TblDataDisplayTypes, "FldDataDisplayTypeId", "FldDataDisplayTypeTxt");
           ViewData["FldParametersId"] = new SelectList(_context.TblParameters, "FldParametersId", "FldParametersText");
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

            _context.Attach(TblTechnicalInfoDataType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblTechnicalInfoDataTypeExists(TblTechnicalInfoDataType.FldTechnicalInfoDataTypesId))
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

        private bool TblTechnicalInfoDataTypeExists(Guid id)
        {
            return _context.TblTechnicalInfoDataTypes.Any(e => e.FldTechnicalInfoDataTypesId == id);
        }
    }
}
