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
    public class ScoringModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public ScoringModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        public IList<TblEmployeeRequestInterviewSession> TblEmployeeRequestInterviewSession { get;set; }
        public IList<TblEmployeeRequestPrimaryInformation> TblEmployeeRequestPrimaryInformation { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }

            TblEmployeeRequestInterviewSession = await _context.TblEmployeeRequestInterviewSessions
                .Include(t => t.FldEmployeeRequestEmployee)
                .Include(t => t.FldEmployeeRequestPrimaryAcception)
                .Include(t => t.FldEmployeeRequestUser)
                .Where(a=>a.FldEmployeeRequestUserId == Int64.Parse(uid))
                .ToListAsync();

            TblEmployeeRequestPrimaryInformation = await _context.TblEmployeeRequestPrimaryInformations.ToListAsync();

            return Page();
        }

        public IActionResult OnGetPoint(long id, int point, string eid)
        {
            TblEmployeeRequestInterviewSession TblEmployeeRequestInterviewSession2 = _context.TblEmployeeRequestInterviewSessions.Find(id);
            if (TblEmployeeRequestInterviewSession2 != null)
            {
                string uid = HttpContext.Session.GetString("uid");
                if (uid == null)
                {
                    return RedirectToPage("../Index");
                }
                TblEmployeeRequestInterviewSession2.FldEmployeeRequestInterviewSessionResultPoint = point;
                TblEmployeeRequestInterviewSession2.FldEmployeeRequestInterviewSessionDate = DateTime.Now;
                _context.TblEmployeeRequestInterviewSessions.Update(TblEmployeeRequestInterviewSession2);

                TblEmployeeRequestEmployee TblEmployeeRequestEmployee = _context.TblEmployeeRequestEmployees.Find(eid);
                TblEmployeeRequestEmployee.FldEmployeeRequestEmployeeResultPoint += point;
                _context.TblEmployeeRequestEmployees.Update(TblEmployeeRequestEmployee);

                _context.SaveChanges();
            }
            return RedirectToPage("Index");
        }

        public IActionResult OnGetAccept(long id)
        {
            TblEmployeeRequestInterviewSession TblEmployeeRequestInterviewSession2 = _context.TblEmployeeRequestInterviewSessions.Find(id);
            if (TblEmployeeRequestInterviewSession2 != null)
            {
                string uid = HttpContext.Session.GetString("uid");
                if (uid == null)
                {
                    return RedirectToPage("../Index");
                }
                TblEmployeeRequestInterviewSession2.FldEmployeeRequestPrimaryAcceptionId = 3;
                _context.TblEmployeeRequestInterviewSessions.Update(TblEmployeeRequestInterviewSession2);
                _context.SaveChanges();
            }
            return RedirectToPage("Index");
        }

        public IActionResult OnGetDeny(long id)
        {
            TblEmployeeRequestInterviewSession TblEmployeeRequestInterviewSession2 = _context.TblEmployeeRequestInterviewSessions.Find(id);
            if (TblEmployeeRequestInterviewSession2 != null)
            {
                string uid = HttpContext.Session.GetString("uid");
                if (uid == null)
                {
                    return RedirectToPage("../Index");
                }
                TblEmployeeRequestInterviewSession2.FldEmployeeRequestPrimaryAcceptionId = 2;
                _context.TblEmployeeRequestInterviewSessions.Update(TblEmployeeRequestInterviewSession2);
                _context.SaveChanges();
            }
            return RedirectToPage("Index");
        }
    }
}
