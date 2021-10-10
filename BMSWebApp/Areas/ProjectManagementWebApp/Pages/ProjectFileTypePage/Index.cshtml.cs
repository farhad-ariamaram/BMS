using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectManagementWebApp.Models;

namespace ProjectManagementWebApp.Pages.ProjectFileTypePage
{
    public class IndexModel : PageModel
    {
        private readonly ProjectManagementDBContext _context;

        public IndexModel(ProjectManagementDBContext context)
        {
            _context = context;
        }

        public IList<TblProjectFileType> TblProjectFileType { get;set; }

        public async Task OnGetAsync()
        {
            TblProjectFileType = await _context.TblProjectFileTypes.ToListAsync();
        }
    }
}
