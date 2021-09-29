using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeRequest.Models;
using Microsoft.AspNetCore.Http;

namespace EmployeeRequest.Pages.EmployeeRequest.SkillPage.TopicPage
{
    public class IndexModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public IndexModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string VersionTitle { get; set; }

        [BindProperty]
        public long versionId { get; set; }

        public IList<Topic> Topic { get; set; }

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
                VersionTitle = _context.Versions.Include(a => a.Skill).Where(a => a.Id == id.Value).FirstOrDefault().Skill.FldEmployeeRequestSkillsSkillTitle + " " + _context.Versions.Find(id.Value).Version1;
                Topic = await _context.Topics
                .Include(t => t.Version)
                .Where(a => a.VersionId == id.Value)
                .ToListAsync();
            }
            else
            {
                Topic = await _context.Topics
                .Include(t => t.Version).ToListAsync();
            }

            return Page();
        }
    }
}
