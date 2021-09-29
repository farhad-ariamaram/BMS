using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TechnicalInfoWebApp.Models;

namespace TechnicalInfoWebApp.Pages.TechnicalInfoDataTypesValuePage
{
    public class DeleteModel : PageModel
    {
        private readonly TechnicalInfoWebApp.Models.TechnicalInfoDBContext _context;

        public DeleteModel(TechnicalInfoWebApp.Models.TechnicalInfoDBContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblTechnicalInfoDataTypesValue = await _context.TblTechnicalInfoDataTypesValues.FindAsync(id);

            if (TblTechnicalInfoDataTypesValue != null)
            {
                _context.TblTechnicalInfoDataTypesValues.Remove(TblTechnicalInfoDataTypesValue);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
