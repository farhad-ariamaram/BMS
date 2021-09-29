using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRequest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeRequest.Pages
{
    public class HelpModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public HelpModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        public TblEmployeeRequestHelp tblEmployeeRequestHelp { get; set; }

        public IActionResult OnGet(int? id)
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }

            if (id == null)
            {
                return RedirectToPage("Index");
            }

            tblEmployeeRequestHelp = _context.TblEmployeeRequestHelps.Find(id);

            if(tblEmployeeRequestHelp == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
