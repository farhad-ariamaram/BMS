using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeRequest.Models;

namespace EmployeeRequest.Pages.EmployeeRequest.SkillPage.WebsitePage
{
    public class DeleteModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public DeleteModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblWebsite TblWebsite { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblWebsite = await _context.TblWebsites
                .Include(t => t.Definition)
                .Include(t => t.WebsiteType).FirstOrDefaultAsync(m => m.Id == id);

            if (TblWebsite == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblWebsite = await _context.TblWebsites.FindAsync(id);

            if (TblWebsite != null)
            {
                _context.TblWebsites.Remove(TblWebsite);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index" , new { definationId = TblWebsite.DefinitionId, subDefId = TblWebsite.SubDefinationId });
        }
    }
}
