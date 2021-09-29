using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeRequest.Models;

namespace EmployeeRequest.Pages.EmployeeRequest.SkillPage.WebsitePage
{
    public class EditModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public EditModel(EmployeeRequestDBContext context)
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
            ViewData["WebsiteTypeId"] = new SelectList(_context.TblWebsiteTypes, "Id", "Title");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (!TblWebsite.Website.ToLower().StartsWith("http"))
            {
                TblWebsite.Website = "http://" + TblWebsite.Website;
            }

            _context.Attach(TblWebsite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblWebsiteExists(TblWebsite.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new { definationId = TblWebsite.DefinitionId, subDefId = TblWebsite.SubDefinationId });
        }

        private bool TblWebsiteExists(int id)
        {
            return _context.TblWebsites.Any(e => e.Id == id);
        }
    }
}
