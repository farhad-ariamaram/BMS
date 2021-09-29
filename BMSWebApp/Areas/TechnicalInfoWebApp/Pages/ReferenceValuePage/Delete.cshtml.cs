using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TechnicalInfoWebApp.Models;

namespace TechnicalInfoWebApp.Pages.ReferenceValuePage
{
    public class DeleteModel : PageModel
    {
        private readonly TechnicalInfoWebApp.Models.TechnicalInfoDBContext _context;

        public DeleteModel(TechnicalInfoWebApp.Models.TechnicalInfoDBContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblReferenceValue = await _context.TblReferenceValues.FindAsync(id);

            if (TblReferenceValue != null)
            {
                _context.TblReferenceValues.Remove(TblReferenceValue);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
