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
    public class IndexModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public IndexModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        public IList<TblEmployeeRequestPrimaryInformation> TblEmployeeRequestPrimaryInformation { get; set; }

        public string Id { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Id = id;

            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../../Index");
            }

            if (id == null)
            {
                return RedirectToPage("../../Index");
            }

            TblEmployeeRequestPrimaryInformation = await _context.TblEmployeeRequestPrimaryInformations.Where(a => a.FldEmployeeRequestEmployeeId == id)
                .Include(t => t.FldEmployeeRequestEmployee).ToListAsync();

            return Page();
        }
    }
}
