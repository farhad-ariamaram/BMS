using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRequest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequest.Pages.EmployeeRequest
{
    public class TransferModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public TransferModel(EmployeeRequestDBContext context)
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

        public IActionResult OnGetTransfer(long id)
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }
            TblEmployeeRequestEmployeeRequest TblEmployeeRequestEmployeeRequest2 = _context.TblEmployeeRequestEmployeeRequests
                .Include(t => t.FldEmployeeRequestJobs)
                .Include(t => t.FldEmployeeRequestJobOnet)
                .Include(t => t.FldEmployeeRequestJobTamin)
                .Where(a => a.FldEmployeeRequestEmployeeRequestId == id)
                .FirstOrDefault();
            if (TblEmployeeRequestEmployeeRequest2 != null)
            {
                TblEmployeeRequestEmployeeRequest2.FldEmployeeRequestEmployeeRequestIsTransfered = true;
                TblEmployeeRequestEmployeeRequest2.FldEmployeeRequestEmployeeRequestTransferDate = DateTime.Now;
                _context.TblEmployeeRequestEmployeeRequests.Update(TblEmployeeRequestEmployeeRequest2);
                _context.SaveChanges();
            }
            return RedirectToPage("Index");
        }


    }
}