using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
        using EmployeeRequest.Models;

namespace EmployeeRequest.Pages.Employee.PrimaryInformation
{
    public class DeleteModel : PageModel
    {
    private readonly EmployeeRequestDBContext _context;

    public DeleteModel(EmployeeRequestDBContext context)
    {
    _context = context;
    }

    [BindProperty]
    public TblEmployeeRequestPrimaryInformation TblEmployeeRequestPrimaryInformation { get; set; }

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

        TblEmployeeRequestPrimaryInformation = await _context.TblEmployeeRequestPrimaryInformations
                .Include(t => t.FldEmployeeRequestEmployee).FirstOrDefaultAsync(m => m.FldEmployeeRequestPrimaryInformationId == id);

        if (TblEmployeeRequestPrimaryInformation == null)
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

            TblEmployeeRequestPrimaryInformation = await _context.TblEmployeeRequestPrimaryInformations.FindAsync(id);

            if (TblEmployeeRequestPrimaryInformation != null)
            {
            _context.TblEmployeeRequestPrimaryInformations.Remove(TblEmployeeRequestPrimaryInformation);

            TblEmployeeRequestEmployeeEditLog t = new TblEmployeeRequestEmployeeEditLog()
            {
            FldEmployeeRequestEmployeeEditLogDate = DateTime.Now,
            FldEmployeeRequestUserId = Int64.Parse(uid),
            FldEmployeeRequestEmployeeId = TblEmployeeRequestPrimaryInformation.FldEmployeeRequestEmployeeId,
            FldEmployeeRequestEmployeeEditLogSection = "Primary-Delete"
            };

            _context.TblEmployeeRequestEmployeeEditLogs.Add(t);

            await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index", new { id = TblEmployeeRequestPrimaryInformation.FldEmployeeRequestEmployeeId });
            }
            }
            }
