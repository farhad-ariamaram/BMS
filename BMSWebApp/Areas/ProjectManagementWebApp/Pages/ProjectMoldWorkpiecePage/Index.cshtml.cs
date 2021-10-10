using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectManagementWebApp.Models;

namespace ProjectManagementWebApp.Pages.ProjectMoldWorkpiecePage
{
    public class IndexModel : PageModel
    {
        private readonly ProjectManagementDBContext _context;

        public IndexModel(ProjectManagementDBContext context)
        {
            _context = context;
        }

        public IList<TblProjectMoldWorkpiece> TblProjectMoldWorkpiece { get;set; }

        public async Task OnGetAsync()
        {
            TblProjectMoldWorkpiece = await _context.TblProjectMoldWorkpieces
                .Include(t => t.FldProjectMold)
                .Include(t => t.FldWorkpiece).ToListAsync();
        }
    }
}
