using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TechnicalInfoWebApp.Models;

namespace TechnicalInfoWebApp.Pages.ParameterPage
{
    public class DeleteModel : PageModel
    {
        private readonly TechnicalInfoWebApp.Models.TechnicalInfoDBContext _context;

        public DeleteModel(TechnicalInfoWebApp.Models.TechnicalInfoDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblParameter TblParameter { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblParameter = await _context.TblParameters
                .Include(t => t.FldPhysicalQuantity).FirstOrDefaultAsync(m => m.FldParametersId == id);

            if (TblParameter == null)
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

            var f = _context.TblParametersUnits.Where(x => x.FldParametersId == TblParameter.FldParametersId);
            foreach (var item in f)
            {
                _context.Remove(item);
            }
            await _context.SaveChangesAsync();

            TblParameter = await _context.TblParameters.FindAsync(id);

            if (TblParameter != null)
            {
                _context.TblParameters.Remove(TblParameter);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
