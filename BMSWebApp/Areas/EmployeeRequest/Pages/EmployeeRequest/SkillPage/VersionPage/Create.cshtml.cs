using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeRequest.Models;
using Microsoft.AspNetCore.Http;

namespace EmployeeRequest.Pages.EmployeeRequest.SkillPage.VersionPage
{
    public class CreateModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public CreateModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        public string SkillTitle { get; set; }

        [BindProperty]
        public int SkillId { get; set; }

        public IActionResult OnGet(int? id)
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }

            if (id.HasValue)
            {
                SkillId = id.Value;
                SkillTitle = _context.TblEmployeeRequestSkills.FirstOrDefault(a => a.FldEmployeeRequestSkillsId == id.Value).FldEmployeeRequestSkillsSkillTitle;
            }
            else
            {
                RedirectToPage("./Index");
            }

            return Page();
        }

        [BindProperty]
        public Models.Version Version { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Versions.Add(Version);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { id = Version.SkillId });
        }
    }
}
