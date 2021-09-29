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
    public class IndexModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public IndexModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        public IList<OutlineVersion> OutlineVersion { get; set; }

        [BindProperty]
        public long versionId { get; set; }

        [BindProperty]
        public string versionTitle { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }

            if (id.HasValue)
            {
                versionId = id.Value;
                versionTitle = _context.Versions.Include(a => a.Skill).Where(a => a.Id == id.Value).FirstOrDefault().Skill.FldEmployeeRequestSkillsSkillTitle + " " + _context.Versions.Find(id.Value).Version1;
                OutlineVersion = await _context.OutlineVersions
                                .Include(o => o.Outline)
                                .Include(o => o.Topic)
                                .Include(o => o.Version)
                                .Where(a => a.VersionId == id)
                                .ToListAsync();
            }
            else
            {
                OutlineVersion = await _context.OutlineVersions
                .Include(o => o.Outline)
                .Include(o => o.Topic)
                .Include(o => o.Version).ToListAsync();
            }

            return Page();
        }
    }
}
