using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeRequest.Models;
using Microsoft.AspNetCore.Http;

namespace EmployeeRequest.Pages.EmployeeRequest.SkillPage.VersionPage
{
    public class IndexModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public IndexModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        public IList<Models.Version> Version { get; set; }

        [BindProperty]
        public int? SkillId { get; set; }

        [BindProperty]
        public string SkillTitle { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }

            if (id.HasValue)
            {
                SkillId = id.Value;
                SkillTitle = _context.TblEmployeeRequestSkills.Find(id.Value).FldEmployeeRequestSkillsSkillTitle;
                Version = await _context.Versions
                    .Where(a => a.SkillId == id)
                    .Include(v => v.Skill).ToListAsync();
            }
            else
            {
                Version = await _context.Versions
                .Include(v => v.Skill).ToListAsync();
            }

            return Page();
        }
    }
}
