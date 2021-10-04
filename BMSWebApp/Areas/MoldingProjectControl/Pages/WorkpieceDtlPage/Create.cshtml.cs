using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoldingProjectControlWebApp.Models;

namespace MoldingProjectControlWebApp.Pages.WorkpieceDtlPage
{
    public class CreateModel : PageModel
    {
        private readonly MoldingProjectControlWebApp.Models.MoldingProjectControlDBContext _context;

        public CreateModel(MoldingProjectControlWebApp.Models.MoldingProjectControlDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["FldWorkpieceId"] = new SelectList(_context.TblWorkpieces, "FldWorkpieceId", "FldWorkpieceTxt");
        ViewData["FldWorkpieceCompositionComponentsId"] = new SelectList(_context.TblWorkpieces, "FldWorkpieceId", "FldWorkpieceTxt");
            return Page();
        }

        [BindProperty]
        public TblWorkpieceDtl TblWorkpieceDtl { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TblWorkpieceDtls.Add(TblWorkpieceDtl);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
