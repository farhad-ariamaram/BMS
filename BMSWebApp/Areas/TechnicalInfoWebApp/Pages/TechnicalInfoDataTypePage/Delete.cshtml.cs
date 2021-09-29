using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TechnicalInfoWebApp.Models;

namespace TechnicalInfoWebApp.Pages.TechnicalInfoDataTypePage
{
    public class DeleteModel : PageModel
    {
        private readonly TechnicalInfoWebApp.Models.TechnicalInfoDBContext _context;

        public DeleteModel(TechnicalInfoWebApp.Models.TechnicalInfoDBContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblTechnicalInfoDataType = await _context.TblTechnicalInfoDataTypes.FindAsync(id);

            if (TblTechnicalInfoDataType != null)
            {
                _context.TblTechnicalInfoDataTypes.Remove(TblTechnicalInfoDataType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
