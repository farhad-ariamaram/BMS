using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LoggerWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LoggerWebApp.Pages
{
    public class DetailModel : PageModel
    {
        private readonly ILogDBContext _context;

        public DetailModel(ILogDBContext context)
        {
            _context = context;
        }

        public IQueryable<TblIlogDbIp> IpsListQ { get; set; }
        public IList<TblIlogDbIp> IpsList { get; set; }

        public async Task<IActionResult> OnGet(string search)
        {
            IpsListQ = from m in _context.TblIlogDbIps select m;

            if (!string.IsNullOrEmpty(search))
            {
                IpsListQ = IpsListQ.Where(t => t.FldIlogDbIpAddress.Contains(search) || t.FldIlogDbIpTitle.Contains(search));
            }

            IpsList = await IpsListQ.Include(t=>t.FldIlogDbLogType).ToListAsync();

            return Page();
        }
    }
}
