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
    public class AcceptModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public AcceptModel(EmployeeRequestDBContext context)
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
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }
            TblEmployeeRequestEmployeeRequest TblEmployeeRequestEmployeeRequest2 = _context.TblEmployeeRequestEmployeeRequests.Find(id);
            if (TblEmployeeRequestEmployeeRequest2 != null)
            {
                _context.TblEmployeeRequestEmployeeRequests.Remove(TblEmployeeRequestEmployeeRequest2);
                _context.SaveChanges();
            }
            return RedirectToPage("Index");
        }

        public IActionResult OnGetAccept(long id)
        {
            TblEmployeeRequestEmployeeRequest TblEmployeeRequestEmployeeRequest2 = _context.TblEmployeeRequestEmployeeRequests.Find(id);
            if (TblEmployeeRequestEmployeeRequest2 != null)
            {
                string uid = HttpContext.Session.GetString("uid");
                if (uid == null)
                {
                    return RedirectToPage("../Index");
                }
                TblEmployeeRequestEmployeeRequest2.FldEmployeeRequestEmployeeRequestIsAccept = true;
                TblEmployeeRequestEmployeeRequest2.FldEmployeeRequestEmployeeRequestAcceptDate = DateTime.Now;
                TblEmployeeRequestEmployeeRequest2.FldEmployeeRequestUserAccepterId = int.Parse(uid);
                _context.TblEmployeeRequestEmployeeRequests.Update(TblEmployeeRequestEmployeeRequest2);
                _context.SaveChanges();
            }
            return RedirectToPage("Index");
        }

        public IActionResult OnGetDeny(long id)
        {
            TblEmployeeRequestEmployeeRequest TblEmployeeRequestEmployeeRequest2 = _context.TblEmployeeRequestEmployeeRequests.Find(id);
            if (TblEmployeeRequestEmployeeRequest2 != null)
            {
                string uid = HttpContext.Session.GetString("uid");
                if (uid == null)
                {
                    return RedirectToPage("../Index");
                }
                TblEmployeeRequestEmployeeRequest2.FldEmployeeRequestEmployeeRequestIsAccept = false;
                TblEmployeeRequestEmployeeRequest2.FldEmployeeRequestEmployeeRequestAcceptDate = DateTime.Now;
                TblEmployeeRequestEmployeeRequest2.FldEmployeeRequestUserAccepterId = int.Parse(uid);
                _context.TblEmployeeRequestEmployeeRequests.Update(TblEmployeeRequestEmployeeRequest2);
                _context.SaveChanges();
            }
            return RedirectToPage("Index");
        }
    }
}