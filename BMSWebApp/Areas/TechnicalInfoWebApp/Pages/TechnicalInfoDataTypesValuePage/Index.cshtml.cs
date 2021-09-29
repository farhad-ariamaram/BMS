using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TechnicalInfoWebApp.Models;

namespace TechnicalInfoWebApp.Pages.TechnicalInfoDataTypesValuePage
{
    public class IndexModel : PageModel
    {
        private readonly TechnicalInfoWebApp.Models.TechnicalInfoDBContext _context;

        public IndexModel(TechnicalInfoWebApp.Models.TechnicalInfoDBContext context)
        {
            _context = context;
        }

        public IList<TblTechnicalInfoDataTypesValue> TblTechnicalInfoDataTypesValue { get;set; }

        public async Task OnGetAsync()
        {
            TblTechnicalInfoDataTypesValue = await _context.TblTechnicalInfoDataTypesValues
                .Include(t => t.FldTechnicalInfoDataTypes).ToListAsync();
        }
    }
}
