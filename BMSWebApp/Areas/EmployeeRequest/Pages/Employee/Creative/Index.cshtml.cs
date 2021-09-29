using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeRequest.Models;
using Microsoft.AspNetCore.Http;

namespace EmployeeRequest.Pages.Employee.Creative
{
    public class IndexModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public IndexModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        public IList<TblEmployeeRequestUserCreativity> TblEmployeeRequestUserCreativity { get;set; }

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

            TblEmployeeRequestUserCreativity = await _context.TblEmployeeRequestUserCreativities
                .Where(a => a.FldEmployeeRequestEmployeeId == id)
                .Include(t => t.FldEmployeeRequestCreativityType)
                .Include(t => t.FldEmployeeRequestEmployee).ThenInclude(t => t.TblEmployeeRequestPrimaryInformations).ToListAsync();

            return Page();
        }
    }
}
