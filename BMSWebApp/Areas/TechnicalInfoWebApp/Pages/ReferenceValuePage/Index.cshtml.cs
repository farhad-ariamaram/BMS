using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TechnicalInfoWebApp.Models;

namespace TechnicalInfoWebApp.Pages.ReferenceValuePage
{
    public class IndexModel : PageModel
    {
        private readonly TechnicalInfoWebApp.Models.TechnicalInfoDBContext _context;

        public IndexModel(TechnicalInfoWebApp.Models.TechnicalInfoDBContext context)
        {
            _context = context;
        }

        public IList<TblReferenceValue> TblReferenceValue { get;set; }

        public async Task OnGetAsync()
        {
            TblReferenceValue = await _context.TblReferenceValues
                .Include(t => t.FldReferenceTechnicalInfoGroup)
                .Include(t => t.FldTechnicalInfo).ToListAsync();
        }
    }
}
