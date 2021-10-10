using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectManagementWebApp.Models;

namespace ProjectManagementWebApp.Pages.SoftwareUsedPage
{
    public class IndexModel : PageModel
    {
        private readonly ProjectManagementDBContext _context;

        public IndexModel(ProjectManagementDBContext context)
        {
            _context = context;
        }

        public IList<TblSoftwareUsed> TblSoftwareUsed { get;set; }

        public async Task OnGetAsync()
        {
            TblSoftwareUsed = await _context.TblSoftwareUseds.ToListAsync();
        }
    }
}
