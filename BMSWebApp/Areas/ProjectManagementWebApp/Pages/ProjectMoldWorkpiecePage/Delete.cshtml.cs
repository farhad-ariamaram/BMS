using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectManagementWebApp.Models;

namespace ProjectManagementWebApp.Pages.ProjectMoldWorkpiecePage
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectManagementDBContext _context;

        public DeleteModel(ProjectManagementDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblProjectMoldWorkpiece TblProjectMoldWorkpiece { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblProjectMoldWorkpiece = await _context.TblProjectMoldWorkpieces
                .Include(t => t.FldProjectMold)
                .Include(t => t.FldWorkpiece).FirstOrDefaultAsync(m => m.FldProjectMoldWorkpieceId == id);

            if (TblProjectMoldWorkpiece == null)
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

            TblProjectMoldWorkpiece = await _context.TblProjectMoldWorkpieces.FindAsync(id);

            if (TblProjectMoldWorkpiece != null)
            {
                _context.TblProjectMoldWorkpieces.Remove(TblProjectMoldWorkpiece);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
