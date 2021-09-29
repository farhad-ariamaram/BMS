using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TechnicalInfoWebApp.Models;

namespace TechnicalInfoWebApp.Pages.ReferenceTechnicalInfoGroupPage
{
    public class DeleteModel : PageModel
    {
        private readonly TechnicalInfoWebApp.Models.TechnicalInfoDBContext _context;

        public DeleteModel(TechnicalInfoWebApp.Models.TechnicalInfoDBContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblReferenceTechnicalInfoGroup = await _context.TblReferenceTechnicalInfoGroups.FindAsync(id);

            if (TblReferenceTechnicalInfoGroup != null)
            {
                _context.TblReferenceTechnicalInfoGroups.Remove(TblReferenceTechnicalInfoGroup);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
