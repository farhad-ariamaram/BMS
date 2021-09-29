using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRequest.Models;
using EmployeeRequest.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequest.Pages.EmployAccept
{
    public class SetInterviewModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public SetInterviewModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblEmployeeRequestEmployee TblEmployeeRequestEmployee { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }

            if (id == null)
            {
                return NotFound();
            }

            TblEmployeeRequestEmployee = await _context.TblEmployeeRequestEmployees
                .FirstOrDefaultAsync(m => m.FldEmployeeRequestEmployeeId == id);

            if (TblEmployeeRequestEmployee == null)
            {
                return NotFound();
            }

            if(TblEmployeeRequestEmployee.FldEmployeeRequestEmployeeInterviewStartDate != null)
            {
                ViewData["startdate"] = TblEmployeeRequestEmployee.FldEmployeeRequestEmployeeInterviewStartDate.toPersianDate();
                ViewData["starttime"] = ((DateTime)TblEmployeeRequestEmployee.FldEmployeeRequestEmployeeInterviewStartDate).TimeOfDay.ToString().Remove(5);
            }

            if (TblEmployeeRequestEmployee.FldEmployeeRequestEmployeeInterviewEndDate != null)
            {
                ViewData["enddate"] = TblEmployeeRequestEmployee.FldEmployeeRequestEmployeeInterviewEndDate.toPersianDate();
                ViewData["endtime"] = ((DateTime)TblEmployeeRequestEmployee.FldEmployeeRequestEmployeeInterviewEndDate).TimeOfDay.ToString().Remove(5);
            }

            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["startdate"] = TblEmployeeRequestEmployee.FldEmployeeRequestEmployeeInterviewStartDate.toPersianDate();
                ViewData["starttime"] = ((DateTime)TblEmployeeRequestEmployee.FldEmployeeRequestEmployeeInterviewStartDate).TimeOfDay;
                ViewData["enddate"] = TblEmployeeRequestEmployee.FldEmployeeRequestEmployeeInterviewEndDate.toPersianDate();
                ViewData["endtime"] = ((DateTime)TblEmployeeRequestEmployee.FldEmployeeRequestEmployeeInterviewEndDate).TimeOfDay;
                return Page();
            }

            string startdate = Request.Form["startdate"] + "/" + Request.Form["starttime"];
            string enddate = Request.Form["enddate"] + "/" + Request.Form["endtime"];

            var startdatearray = startdate.Split('/');
            var starttimearray = startdatearray[3].Split(':');
            var enddatearray = enddate.Split('/');
            var endttimearray = enddatearray[3].Split(':');
            PersianCalendar pc = new PersianCalendar();

            DateTime startfinal = pc.ToDateTime(int.Parse(startdatearray[0]), int.Parse(startdatearray[1]), int.Parse(startdatearray[2]), int.Parse(starttimearray[0]), int.Parse(starttimearray[1]), 0,0);
            DateTime endfinal = pc.ToDateTime(int.Parse(enddatearray[0]), int.Parse(enddatearray[1]), int.Parse(enddatearray[2]), int.Parse(endttimearray[0]), int.Parse(endttimearray[1]), 0, 0);

            TblEmployeeRequestEmployee = await _context.TblEmployeeRequestEmployees
                .FirstOrDefaultAsync(m => m.FldEmployeeRequestEmployeeId == TblEmployeeRequestEmployee.FldEmployeeRequestEmployeeId);

            TblEmployeeRequestEmployee.FldEmployeeRequestEmployeeInterviewStartDate = startfinal;
            TblEmployeeRequestEmployee.FldEmployeeRequestEmployeeInterviewEndDate = endfinal;

            _context.Update(TblEmployeeRequestEmployee);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}