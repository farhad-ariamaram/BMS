using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
        using EmployeeRequest.Models;

namespace EmployeeRequest.Pages.Employee.WorkExperience
{
    public class DeleteModel : PageModel
    {
    private readonly EmployeeRequestDBContext _context;

    public DeleteModel(EmployeeRequestDBContext context)
    {
    _context = context;
    }

    [BindProperty]
    public TblWorkExperience TblWorkExperience { get; set; }

    public async Task<IActionResult>
        OnGetAsync(long? id)
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

        TblWorkExperience = await _context.TblWorkExperiences
                .Include(t => t.FldLeaveJob)
                .Include(t => t.FldTaminJob)
                .Include(t => t.User).FirstOrDefaultAsync(m => m.FldWorkExperienceId == id);

        if (TblWorkExperience == null)
        {
        return NotFound();
        }
        return Page();
        }

        public async Task<IActionResult>
            OnPostAsync(long? id)
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

            TblWorkExperience = await _context.TblWorkExperiences.FindAsync(id);

            if (TblWorkExperience != null)
            {
            _context.TblWorkExperiences.Remove(TblWorkExperience);

            TblEmployeeRequestEmployeeEditLog t = new TblEmployeeRequestEmployeeEditLog()
            {
            FldEmployeeRequestEmployeeEditLogDate = DateTime.Now,
            FldEmployeeRequestUserId = Int64.Parse(uid),
            FldEmployeeRequestEmployeeId = TblWorkExperience.UserId,
            FldEmployeeRequestEmployeeEditLogSection = "Experience-Delete"
            };

            _context.TblEmployeeRequestEmployeeEditLogs.Add(t);

            await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index", new { id = TblWorkExperience.UserId });
            }
            }
            }
