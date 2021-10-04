using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoldingProjectControlWebApp.Models;

namespace MoldingProjectControlWebApp.Pages.WorkpieceDtlPage
{
    public class IndexModel : PageModel
    {
        private readonly MoldingProjectControlWebApp.Models.MoldingProjectControlDBContext _context;

        public IndexModel(MoldingProjectControlWebApp.Models.MoldingProjectControlDBContext context)
        {
            _context = context;
        }

        public IList<TblWorkpieceDtl> TblWorkpieceDtl { get;set; }

        public async Task OnGetAsync()
        {
            TblWorkpieceDtl = await _context.TblWorkpieceDtls
                .Include(t => t.FldWorkpiece)
                .Include(t => t.FldWorkpieceCompositionComponents).ToListAsync();
        }
    }
}
