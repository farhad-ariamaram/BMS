using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeRequest.Models;
using Microsoft.AspNetCore.Http;

namespace EmployeeRequest.Pages.EmployeeRequest.SkillPage
{
    public class CreateModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public CreateModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }

            return Page();
        }

        [BindProperty]
        public TblEmployeeRequestSkill TblEmployeeRequestSkill { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var t = _context.TblEmployeeRequestSkills.Where(a => a.FldEmployeeRequestSkillsSkillTitle == TblEmployeeRequestSkill.FldEmployeeRequestSkillsSkillTitle ||
                                                                 a.FldEmployeeRequestSkillsSkillEnglishTitle == TblEmployeeRequestSkill.FldEmployeeRequestSkillsSkillEnglishTitle);

            if (t.Count() > 0)
            {
                ModelState.AddModelError("duplicateSkill", "مهارت وارد شده از قبل موجود است");
                return Page();
            }

            _context.TblEmployeeRequestSkills.Add(TblEmployeeRequestSkill);
            await _context.SaveChangesAsync();


            return RedirectToPage("./Index");
        }
    }
}
