using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechnicalInfoWebApp.Models;

namespace TechnicalInfoWebApp.Pages.ParametersUnitPage
{
    public class EditModel : PageModel
    {
        private readonly TechnicalInfoWebApp.Models.TechnicalInfoDBContext _context;

        public EditModel(TechnicalInfoWebApp.Models.TechnicalInfoDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblParametersUnit TblParametersUnit { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblParametersUnit = await _context.TblParametersUnits
                .Include(t => t.FldParameters)
                .Include(t => t.FldUnit).FirstOrDefaultAsync(m => m.FldParametersUnitsId == id);

            if (TblParametersUnit == null)
            {
                return NotFound();
            }
           ViewData["FldParametersId"] = new SelectList(_context.TblParameters, "FldParametersId", "FldParametersText");
           ViewData["FldUnitId"] = new SelectList(_context.TblUnits, "FldUnitId", "FldUnitName");
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

            _context.Attach(TblParametersUnit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblParametersUnitExists(TblParametersUnit.FldParametersUnitsId))
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

        private bool TblParametersUnitExists(Guid id)
        {
            return _context.TblParametersUnits.Any(e => e.FldParametersUnitsId == id);
        }
    }
}
