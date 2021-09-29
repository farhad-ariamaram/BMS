using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
        using EmployeeRequest.Models;

namespace EmployeeRequest.Pages.Employee.Language
{
    public class DeleteModel : PageModel
    {
    private readonly EmployeeRequestDBContext _context;

    public DeleteModel(EmployeeRequestDBContext context)
    {
    _context = context;
    }

    [BindProperty]
    public TblEmployeeRequestUserLanguage TblEmployeeRequestUserLanguage { get; set; }

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

        TblEmployeeRequestUserLanguage = await _context.TblEmployeeRequestUserLanguages
                .Include(t => t.FldEmployeeRequestEmployee)
                .Include(t => t.FldEmployeeRequestUserLanguageLanguageType).FirstOrDefaultAsync(m => m.FldEmployeeRequestUserLanguageId == id);

        if (TblEmployeeRequestUserLanguage == null)
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

            TblEmployeeRequestUserLanguage = await _context.TblEmployeeRequestUserLanguages.FindAsync(id);

            if (TblEmployeeRequestUserLanguage != null)
            {
            _context.TblEmployeeRequestUserLanguages.Remove(TblEmployeeRequestUserLanguage);

            TblEmployeeRequestEmployeeEditLog t = new TblEmployeeRequestEmployeeEditLog()
            {
            FldEmployeeRequestEmployeeEditLogDate = DateTime.Now,
            FldEmployeeRequestUserId = Int64.Parse(uid),
            FldEmployeeRequestEmployeeId = TblEmployeeRequestUserLanguage.FldEmployeeRequestEmployeeId,
            FldEmployeeRequestEmployeeEditLogSection = "Language-Delete"
            };

            _context.TblEmployeeRequestEmployeeEditLogs.Add(t);

            await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index", new { id = TblEmployeeRequestUserLanguage.FldEmployeeRequestEmployeeId });
            }
            }
            }
