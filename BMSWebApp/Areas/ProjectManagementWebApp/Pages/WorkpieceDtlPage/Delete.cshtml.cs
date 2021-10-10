using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectManagementWebApp.Models;

namespace ProjectManagementWebApp.Pages.WorkpieceDtlPage
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectManagementDBContext _context;

        public DeleteModel(ProjectManagementDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblWorkpieceDtl TblWorkpieceDtl { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblWorkpieceDtl = await _context.TblWorkpieceDtls
                .Include(t => t.FldWorkpiece)
                .Include(t => t.FldWorkpieceCompositionComponents).FirstOrDefaultAsync(m => m.FldWorkpieceDtlId == id);

            if (TblWorkpieceDtl == null)
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

            TblWorkpieceDtl = await _context.TblWorkpieceDtls.FindAsync(id);

            if (TblWorkpieceDtl != null)
            {
                _context.TblWorkpieceDtls.Remove(TblWorkpieceDtl);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
