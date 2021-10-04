using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoldingProjectControlWebApp.Models;

namespace MoldingProjectControlWebApp.Pages.WorkpieceDtlPage
{
    public class EditModel : PageModel
    {
        private readonly MoldingProjectControlWebApp.Models.MoldingProjectControlDBContext _context;

        public EditModel(MoldingProjectControlWebApp.Models.MoldingProjectControlDBContext context)
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
           ViewData["FldWorkpieceId"] = new SelectList(_context.TblWorkpieces, "FldWorkpieceId", "FldWorkpieceTxt");
           ViewData["FldWorkpieceCompositionComponentsId"] = new SelectList(_context.TblWorkpieces, "FldWorkpieceId", "FldWorkpieceTxt");
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

            _context.Attach(TblWorkpieceDtl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblWorkpieceDtlExists(TblWorkpieceDtl.FldWorkpieceDtlId))
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

        private bool TblWorkpieceDtlExists(Guid id)
        {
            return _context.TblWorkpieceDtls.Any(e => e.FldWorkpieceDtlId == id);
        }
    }
}
