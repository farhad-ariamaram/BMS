using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoldingProjectControlWebApp.Models;

namespace MoldingProjectControlWebApp.Pages.MoldPage
{
    public class DeleteModel : PageModel
    {
        private readonly MoldingProjectControlWebApp.Models.MoldingProjectControlDBContext _context;

        public DeleteModel(MoldingProjectControlWebApp.Models.MoldingProjectControlDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblMold TblMold { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblMold = await _context.TblMolds.FirstOrDefaultAsync(m => m.FldMoldId == id);

            if (TblMold == null)
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

            var f = _context.TblMoldWorkpieces.Where(x => x.FldMoldId == TblMold.FldMoldId);
            foreach (var item in f)
            {
                _context.Remove(item);
            }
            await _context.SaveChangesAsync();

            TblMold = await _context.TblMolds.FindAsync(id);

            if (TblMold != null)
            {
                _context.TblMolds.Remove(TblMold);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
