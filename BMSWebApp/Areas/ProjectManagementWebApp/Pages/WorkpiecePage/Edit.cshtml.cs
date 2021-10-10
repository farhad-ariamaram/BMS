using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectManagementWebApp.Models;

namespace ProjectManagementWebApp.Pages.WorkpiecePage
{
    public class EditModel : PageModel
    {
        private readonly ProjectManagementDBContext _context;

        public EditModel(ProjectManagementDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblWorkpiece TblWorkpiece { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblWorkpiece = await _context.TblWorkpieces.FirstOrDefaultAsync(m => m.FldWorkpieceId == id);

            if (TblWorkpiece == null)
            {
                return NotFound();
            }
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

            _context.Attach(TblWorkpiece).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblWorkpieceExists(TblWorkpiece.FldWorkpieceId))
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

        private bool TblWorkpieceExists(Guid id)
        {
            return _context.TblWorkpieces.Any(e => e.FldWorkpieceId == id);
        }
    }
}
