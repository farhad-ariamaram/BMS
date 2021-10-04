using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoldingProjectControlWebApp.Models;

namespace MoldingProjectControlWebApp.Pages.SoftwareUsedPage
{
    public class DeleteModel : PageModel
    {
        private readonly MoldingProjectControlWebApp.Models.MoldingProjectControlDBContext _context;

        public DeleteModel(MoldingProjectControlWebApp.Models.MoldingProjectControlDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblSoftwareUsed TblSoftwareUsed { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblSoftwareUsed = await _context.TblSoftwareUseds.FirstOrDefaultAsync(m => m.FldSoftwareUsedId == id);

            if (TblSoftwareUsed == null)
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

            var f = _context.TblSoftwareUsedProjectFileTypes.Where(x => x.FldSoftwareUsedId == TblSoftwareUsed.FldSoftwareUsedId);
            foreach (var item in f)
            {
                _context.Remove(item);
            }
            await _context.SaveChangesAsync();

            TblSoftwareUsed = await _context.TblSoftwareUseds.FindAsync(id);

            if (TblSoftwareUsed != null)
            {
                _context.TblSoftwareUseds.Remove(TblSoftwareUsed);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
