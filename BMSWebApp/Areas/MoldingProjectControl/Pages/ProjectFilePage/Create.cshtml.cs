using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoldingProjectControlWebApp.Models;

namespace MoldingProjectControlWebApp.Pages.ProjectFilePage
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
        ViewData["FldProjectId"] = new SelectList(_context.TblProjects, "FldProjectId", "FldProjectTxt");
        ViewData["FldProjectFileTypeId"] = new SelectList(_context.TblProjectFileTypes, "FldProjectFileTypeId", "FldProjectFileTypeTxt");
        ViewData["FldWorkpieceId"] = new SelectList(_context.TblWorkpieces, "FldWorkpieceId", "FldWorkpieceTxt");
            return Page();
        }

        [BindProperty]
        public TblProjectFile TblProjectFile { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TblProjectFiles.Add(TblProjectFile);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
