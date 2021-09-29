using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeRequest.Models;
using Microsoft.AspNetCore.Http;

namespace EmployeeRequest.Pages.EmployeeRequest.SkillPage.OutlineVersionPage
{
    public class DeleteModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public DeleteModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OutlineVersion OutlineVersion { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }

            if (id == null)
            {
                return NotFound();
            }

            OutlineVersion = await _context.OutlineVersions
                .Include(o => o.Outline)
                .Include(o => o.Topic)
                .Include(o => o.Version).FirstOrDefaultAsync(m => m.Id == id);

            if (OutlineVersion == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OutlineVersion = await _context.OutlineVersions.FindAsync(id);

            if (OutlineVersion != null)
            {
                _context.OutlineVersions.Remove(OutlineVersion);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new { id = OutlineVersion.VersionId });
        }
    }
}
