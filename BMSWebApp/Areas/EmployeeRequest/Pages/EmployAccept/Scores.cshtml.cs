using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeRequest.Models;
using Microsoft.AspNetCore.Http;

namespace EmployeeRequest.Pages.EmployAccept
{
    public class ScoresModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public ScoresModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        public IList<TblEmployeeRequestInterviewSession> TblEmployeeRequestInterviewSession { get;set; }
        public IList<TblEmployeeRequestPrimaryInformation> TblEmployeeRequestPrimaryInformation { get; set; }


        public async Task<IActionResult> OnGetAsync(string id)
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }

            if (string.IsNullOrEmpty(id))
            {
                return RedirectToPage("../Panel/Index");
            }

            TblEmployeeRequestInterviewSession = await _context.TblEmployeeRequestInterviewSessions
                .Include(t => t.FldEmployeeRequestEmployee)
                .Include(t => t.FldEmployeeRequestPrimaryAcception)
                .Include(t => t.FldEmployeeRequestUser)
                .Where(a=>a.FldEmployeeRequestEmployeeId==id)
                .ToListAsync();

            TblEmployeeRequestPrimaryInformation = await _context.TblEmployeeRequestPrimaryInformations.ToListAsync();

            return Page();
        }
    }
}
