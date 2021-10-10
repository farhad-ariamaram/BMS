using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectManagementWebApp.Models;

namespace ProjectManagementWebApp.Pages.ExecutionStrategyPage
{
    public class IndexModel : PageModel
    {
        private readonly ProjectManagementDBContext _context;

        public IndexModel(ProjectManagementDBContext context)
        {
            _context = context;
        }

        public IList<TblExecutionStrategy> TblExecutionStrategy { get;set; }

        public async Task OnGetAsync()
        {
            TblExecutionStrategy = await _context.TblExecutionStrategies
                .Include(t => t.FldWorkType).ToListAsync();
        }
    }
}
