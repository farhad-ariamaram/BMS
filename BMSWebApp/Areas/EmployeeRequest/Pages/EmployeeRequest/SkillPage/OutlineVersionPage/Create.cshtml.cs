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

namespace EmployeeRequest.Pages.EmployeeRequest.SkillPage.OutlineVersionPage
{
    public class CreateModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public CreateModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

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
                ViewData["OutlineId"] = new SelectList(_context.Outlines, "Id", "Title");
                ViewData["TopicId"] = new SelectList(_context.Topics.Where(a => a.VersionId == id.Value), "Id", "Title");
            }
            else
            {
                ViewData["OutlineId"] = new SelectList(_context.Outlines, "Id", "Title");
                ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "Title");
                ViewData["VersionId"] = new SelectList(_context.Versions.Where(a => a.Id == id.Value), "Id", "Version1");
            }

            VersionTitle = _context.Versions.Include(o=>o.Skill).FirstOrDefault(a => a.Id == id.Value).Skill.FldEmployeeRequestSkillsSkillTitle + " " + _context.Versions.FirstOrDefault(a => a.Id == id.Value).Version1;

            return Page();
        }

        [BindProperty]
        public OutlineVersion OutlineVersion { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.OutlineVersions.Add(OutlineVersion);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { id = OutlineVersion.VersionId });
        }
    }
}
