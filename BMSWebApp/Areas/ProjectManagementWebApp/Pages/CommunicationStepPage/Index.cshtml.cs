using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectManagementWebApp.Models;

namespace ProjectManagementWebApp.Pages.CommunicationStepPage
{
    public class IndexModel : PageModel
    {
        private readonly ProjectManagementDBContext _context;

        public IndexModel(ProjectManagementDBContext context)
        {
            _context = context;
        }

        public IList<TblCommunicationStep> TblCommunicationStep { get;set; }

        public async Task OnGetAsync()
        {
            TblCommunicationStep = await _context.TblCommunicationSteps
                .Include(t => t.FldImplementationSteps)
                .Include(t => t.FldImplementationStepsRelated)
                .Include(t => t.FldTypeOfCommunicationStep).ToListAsync();
        }
    }
}
