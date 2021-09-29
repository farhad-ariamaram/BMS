using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LoggerWebApp.Models;

namespace LoggerWebApp.Pages
{
    public class CreateModel : PageModel
    {
        private readonly LoggerWebApp.Models.ILogDBContext _context;

        public CreateModel(LoggerWebApp.Models.ILogDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["FldIlogDbLogTypeId"] = new SelectList(_context.TblIlogDbTypes, "FldIlogDbTypeId", "FldIlogDbTypeTitle");
            return Page();
        }

        [BindProperty]
        public TblIlogDbIp TblIlogDbIp { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TblIlogDbIps.Add(TblIlogDbIp);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
