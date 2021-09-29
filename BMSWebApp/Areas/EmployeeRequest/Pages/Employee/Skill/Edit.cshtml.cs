using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using EmployeeRequest.Models;

namespace EmployeeRequest.Pages.Employee.Skill
{
    public class EditModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public EditModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblEmployeeRequestUserSkill TblEmployeeRequestUserSkill { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../../Index");
            }

            if (id == null)
            {
                return NotFound();
            }

            TblEmployeeRequestUserSkill = await _context.TblEmployeeRequestUserSkills
                    .Include(t => t.FldEmployeeRequestEmployee)
                    .Include(t => t.FldEmployeeRequestSkills).FirstOrDefaultAsync(m => m.FldEmployeeRequestUserSkillId == id);

            if (TblEmployeeRequestUserSkill == null)
            {
                return NotFound();
            }
            ViewData["FldEmployeeRequestSkillsId"] = new SelectList(_context.TblEmployeeRequestSkills, "FldEmployeeRequestSkillsId", "FldEmployeeRequestSkillsSkillTitle");
            return Page();
        }

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

            _context.Attach(TblEmployeeRequestUserSkill).State = EntityState.Modified;

            TblEmployeeRequestEmployeeEditLog t = new TblEmployeeRequestEmployeeEditLog()
            {
                FldEmployeeRequestEmployeeEditLogDate = DateTime.Now,
                FldEmployeeRequestUserId = Int64.Parse(uid),
                FldEmployeeRequestEmployeeId = TblEmployeeRequestUserSkill.FldEmployeeRequestEmployeeId,
                FldEmployeeRequestEmployeeEditLogSection = "Skill-Edit"
            };

            _context.TblEmployeeRequestEmployeeEditLogs.Add(t);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblEmployeeRequestUserSkillExists(TblEmployeeRequestUserSkill.FldEmployeeRequestUserSkillId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("Index", new { id = TblEmployeeRequestUserSkill.FldEmployeeRequestEmployeeId });
        }

        private bool TblEmployeeRequestUserSkillExists(long id)
        {
            return _context.TblEmployeeRequestUserSkills.Any(e => e.FldEmployeeRequestUserSkillId == id);
        }
    }
}
