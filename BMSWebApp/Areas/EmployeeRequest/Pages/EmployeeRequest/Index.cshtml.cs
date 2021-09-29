using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeRequest.Models;
using Microsoft.AspNetCore.Http;

namespace EmployeeRequest.Pages.EmployeeRequest
{
    public class IndexModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public IndexModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        public IList<TblEmployeeRequestEmployeeRequest> TblEmployeeRequestEmployeeRequest { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }

            TblEmployeeRequestEmployeeRequest = await _context.TblEmployeeRequestEmployeeRequests
                .Include(t => t.FldEmployeeRequestJobOnet)
                .Include(t => t.FldEmployeeRequestJobTamin)
                .Include(t => t.FldEmployeeRequestJobs)
                .Include(t => t.FldEmployeeRequestUserAccepter)
                .Include(t => t.FldEmployeeRequestUserApplicant)
                .Include(t => t.FldEmployeeRequestUserSubmitter)
                .Include(t => t.FldEmployeeRequestJobTitleFrom)
                .ToListAsync();
           
            return Page();
        }

        public IActionResult OnGetDelete(long id)
        {
            TblEmployeeRequestEmployeeRequest TblEmployeeRequestEmployeeRequest2 = _context.TblEmployeeRequestEmployeeRequests.Find(id);
            if (TblEmployeeRequestEmployeeRequest2 != null)
            {
                _context.TblEmployeeRequestEmployeeRequests.Remove(TblEmployeeRequestEmployeeRequest2);
                _context.SaveChanges();
            }
            return RedirectToPage("Index");

        }
    }
}
