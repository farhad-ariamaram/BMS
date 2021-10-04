using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoldingProjectControlWebApp.Models;

namespace MoldingProjectControlWebApp.Pages.ProjectMoldWorkpiecePage
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
        ViewData["FldProjectMoldId"] = new SelectList(_context.TblProjectMolds, "FldProjectMoldId", "FldProjectMoldId");
        ViewData["FldWorkpieceId"] = new SelectList(_context.TblWorkpieces, "FldWorkpieceId", "FldWorkpieceTxt");
            return Page();
        }

        [BindProperty]
        public TblProjectMoldWorkpiece TblProjectMoldWorkpiece { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TblProjectMoldWorkpieces.Add(TblProjectMoldWorkpiece);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
