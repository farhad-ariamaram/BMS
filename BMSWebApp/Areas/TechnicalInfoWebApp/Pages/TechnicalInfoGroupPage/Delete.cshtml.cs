using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TechnicalInfoWebApp.Models;

namespace TechnicalInfoWebApp.Pages.TechnicalInfoGroupPage
{
    public class DeleteModel : PageModel
    {
        private readonly TechnicalInfoWebApp.Models.TechnicalInfoDBContext _context;

        public DeleteModel(TechnicalInfoWebApp.Models.TechnicalInfoDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblTechnicalInfoGroup TblTechnicalInfoGroup { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblTechnicalInfoGroup = await _context.TblTechnicalInfoGroups
                .Include(t => t.FldReference).FirstOrDefaultAsync(m => m.FldTechnicalInfoGroupId == id);

            if (TblTechnicalInfoGroup == null)
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

            TblTechnicalInfoGroup = await _context.TblTechnicalInfoGroups.FindAsync(id);

            if (TblTechnicalInfoGroup != null)
            {
                _context.TblTechnicalInfoGroups.Remove(TblTechnicalInfoGroup);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
