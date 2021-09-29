using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeRequest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequest.Pages.EmployeeRequest.SkillPage.TopicPage
{
    public class CreateModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public CreateModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public long VersionId { get; set; }

        public string VersionTitle { get; set; }

        public IActionResult OnGet(long? id)
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }

            if (id.HasValue)
            {
                VersionId = id.Value;
            }

            VersionTitle = _context.Versions.Include(o => o.Skill).FirstOrDefault(a => a.Id == id.Value).Skill.FldEmployeeRequestSkillsSkillTitle + " " + _context.Versions.FirstOrDefault(a => a.Id == id.Value).Version1;

            return Page();
        }

        [BindProperty]
        public Topic Topic { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Topics.Add(Topic);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { id = Topic.VersionId });
        }
    }
}
