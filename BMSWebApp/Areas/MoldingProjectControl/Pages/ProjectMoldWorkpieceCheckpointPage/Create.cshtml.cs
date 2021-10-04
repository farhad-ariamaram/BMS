using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoldingProjectControlWebApp.Models;

namespace MoldingProjectControlWebApp.Pages.ProjectMoldWorkpieceCheckpointPage
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
        ViewData["FldProjectMoldWorkpieceId"] = new SelectList(_context.TblProjectMoldWorkpieces, "FldProjectMoldWorkpieceId", "FldProjectMoldWorkpieceId");
            return Page();
        }

        [BindProperty]
        public TblProjectMoldWorkpieceCheckpoint TblProjectMoldWorkpieceCheckpoint { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TblProjectMoldWorkpieceCheckpoints.Add(TblProjectMoldWorkpieceCheckpoint);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
