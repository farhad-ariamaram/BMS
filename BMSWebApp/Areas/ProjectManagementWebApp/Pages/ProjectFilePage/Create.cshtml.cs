using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManagementWebApp.Models;

namespace ProjectManagementWebApp.Pages.ProjectFilePage
{
    public class CreateModel : PageModel
    {
        private readonly ProjectManagementDBContext _context;

        public CreateModel(ProjectManagementDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(Guid? ProjId)
        {
            if (ProjId == null)
            {
                return RedirectToPage("../Index");
            }

            ViewData["FldProjectId"] = ProjId.Value;
            ViewData["FldProjectFileTypeId"] = new SelectList(_context.TblProjectFileTypes, "FldProjectFileTypeId", "FldProjectFileTypeTxt");
            ViewData["FldWorkpieceId"] = new SelectList(_context.TblWorkpieces, "FldWorkpieceId", "FldWorkpieceTxt");
            return Page();
        }

        [BindProperty]
        public TblProjectFile TblProjectFile { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["FldProjectId"] = Request.Form["TblProjectFile.FldProjectId"].ToString();
                ViewData["FldProjectFileTypeId"] = new SelectList(_context.TblProjectFileTypes, "FldProjectFileTypeId", "FldProjectFileTypeTxt");
                ViewData["FldWorkpieceId"] = new SelectList(_context.TblWorkpieces, "FldWorkpieceId", "FldWorkpieceTxt");
                return Page();
            }

            _context.TblProjectFiles.Add(TblProjectFile);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index" , new { ProjId = Request.Form["TblProjectFile.FldProjectId"].ToString() });
        }
    }
}
