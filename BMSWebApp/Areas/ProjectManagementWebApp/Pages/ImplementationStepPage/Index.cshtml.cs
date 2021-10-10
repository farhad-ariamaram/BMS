using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectManagementWebApp.Models;

namespace ProjectManagementWebApp.Pages.ImplementationStepPage
{
    public class IndexModel : PageModel
    {
        private readonly ProjectManagementDBContext _context;

        public IndexModel(ProjectManagementDBContext context)
        {
            _context = context;
        }

        public IList<TblImplementationStep> TblImplementationStep { get;set; }

        public async Task OnGetAsync()
        {
            TblImplementationStep = await _context.TblImplementationSteps
                .Include(t => t.FldExecutionStrategy)
                .Include(t => t.FldProject).ToListAsync();
        }
    }
}
