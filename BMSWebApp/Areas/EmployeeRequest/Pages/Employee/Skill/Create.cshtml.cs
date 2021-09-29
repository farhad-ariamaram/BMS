using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using EmployeeRequest.Models;

namespace EmployeeRequest.Pages.Employee.Skill
{
    public class CreateModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public CreateModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(string id)
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../../Index");
            }

            ViewData["EmployeeId"] = id;

            ViewData["FldEmployeeRequestSkillsId"] = new SelectList(_context.TblEmployeeRequestSkills, "FldEmployeeRequestSkillsId", "FldEmployeeRequestSkillsSkillTitle");
            return Page();
        }

        [BindProperty]
        public TblEmployeeRequestUserSkill TblEmployeeRequestUserSkill { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../../Index");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            long lastid = _context.TblEmployeeRequestUserSkills.OrderByDescending(a => a.FldEmployeeRequestUserSkillId).FirstOrDefault().FldEmployeeRequestUserSkillId;
            TblEmployeeRequestUserSkill.FldEmployeeRequestUserSkillId = lastid + 1;
            _context.TblEmployeeRequestUserSkills.Add(TblEmployeeRequestUserSkill);

            TblEmployeeRequestEmployeeEditLog t = new TblEmployeeRequestEmployeeEditLog()
            {
                FldEmployeeRequestEmployeeEditLogDate = DateTime.Now,
                FldEmployeeRequestUserId = Int64.Parse(uid),
                FldEmployeeRequestEmployeeId = TblEmployeeRequestUserSkill.FldEmployeeRequestEmployeeId,
                FldEmployeeRequestEmployeeEditLogSection = "Skill-Create"
            };
            _context.TblEmployeeRequestEmployeeEditLogs.Add(t);

            await _context.SaveChangesAsync();

            return RedirectToPage("Index", new { id = TblEmployeeRequestUserSkill.FldEmployeeRequestEmployeeId });
        }
    }
}
