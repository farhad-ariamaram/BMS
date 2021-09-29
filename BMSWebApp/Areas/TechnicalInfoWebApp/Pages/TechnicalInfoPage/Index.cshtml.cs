using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TechnicalInfoWebApp.Models;

namespace TechnicalInfoWebApp.Pages.TechnicalInfoPage
{
    public class IndexModel : PageModel
    {
        private readonly TechnicalInfoWebApp.Models.TechnicalInfoDBContext _context;

        public IndexModel(TechnicalInfoWebApp.Models.TechnicalInfoDBContext context)
        {
            _context = context;
        }

        public IList<TblTechnicalInfo> TblTechnicalInfo { get;set; }

        public async Task OnGetAsync()
        {
            TblTechnicalInfo = await _context.TblTechnicalInfos
                .Include(t => t.FldTechnicalInfoDataTypes)
                .Include(t => t.FldTechnicalInfoGroup).ToListAsync();
        }
    }
}
