using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeRequest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace EmployeeRequest.Pages.EmployAccept
{
    public class CreateScorerModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public CreateScorerModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        public List<TblEmployeeRequestHelp> tblEmployeeRequestHelps { get; set; }

        public IActionResult OnGet()
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }

            tblEmployeeRequestHelps = _context.TblEmployeeRequestHelps.ToList();

            ViewData["FldEmployee"] = (from p in _context.TblEmployeeRequestEmployees
                                       join f in _context.TblEmployeeRequestPrimaryInformations
                                       on p.FldEmployeeRequestEmployeeId equals f.FldEmployeeRequestEmployeeId
                                       select new SelectListItem
                                       {
                                           Value = p.FldEmployeeRequestEmployeeId,
                                           Text = f.FldEmployeeRequestPrimaryInformationFirstName + " " + f.FldEmployeeRequestPrimaryInformationLastName
                                       });

            ViewData["FldEmployeeRequestUserId"] = new SelectList(_context.TblEmployeeRequestUsers, "FldEmployeeRequestUserId", "FldEmployeeRequestUserUsername");
            return Page();
        }

        [BindProperty]
        public TblEmployeeRequestInterviewSession TblEmployeeRequestInterviewSession { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["FldEmployeeRequestEmployeeId"] = new SelectList(_context.TblEmployeeRequestEmployees.Where(a => a.FldEmployeeRequestUserFinalAccepterId == null), "FldEmployeeRequestEmployeeId", "FldEmployeeRequestEmployeeUsername");
                ViewData["FldEmployeeRequestUserId"] = new SelectList(_context.TblEmployeeRequestUsers, "FldEmployeeRequestUserId", "FldEmployeeRequestUserUsername");
                return Page();
            }

            TblEmployeeRequestInterviewSession.FldEmployeeRequestPrimaryAcceptionId = 1;
            _context.TblEmployeeRequestInterviewSessions.Add(TblEmployeeRequestInterviewSession);

            TblEmployeeRequestEmployee TblEmployeeRequestEmployees = _context.TblEmployeeRequestEmployees.Find(TblEmployeeRequestInterviewSession.FldEmployeeRequestEmployeeId);
            if (TblEmployeeRequestEmployees.FldEmployeeRequestEmployeeMaxPoint == null)
            {
                TblEmployeeRequestEmployees.FldEmployeeRequestEmployeeMaxPoint = TblEmployeeRequestInterviewSession.FldEmployeeRequestInterviewSessionMaxPoint;
            }
            else
            {
                TblEmployeeRequestEmployees.FldEmployeeRequestEmployeeMaxPoint += TblEmployeeRequestInterviewSession.FldEmployeeRequestInterviewSessionMaxPoint;
            }
            _context.TblEmployeeRequestEmployees.Update(TblEmployeeRequestEmployees);

            await _context.SaveChangesAsync();

            return RedirectToPage("CreateScorer");
        }
    }
}
