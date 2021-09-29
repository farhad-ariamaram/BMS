using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LoggerWebApp.Models;

namespace LoggerWebApp.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly LoggerWebApp.Models.ILogDBContext _context;

        public DeleteModel(LoggerWebApp.Models.ILogDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblIlogDbIp TblIlogDbIp { get; set; }

        public IList<TblIlogDbIp> IpList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            ViewData["id"] = id;

            if (id == null)
            {
                IpList = await _context.TblIlogDbIps
                    .Include(t => t.FldIlogDbLogType).ToListAsync();

                return Page();
            }

            TblIlogDbIp = await _context.TblIlogDbIps
                .Include(t => t.FldIlogDbLogType).FirstOrDefaultAsync(m => m.FldIlogDbIpId == id);

            if (TblIlogDbIp == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return Page();
            }

            TblIlogDbIp = await _context.TblIlogDbIps.FindAsync(id);

            if (TblIlogDbIp != null)
            {
                _context.TblIlogDbLogs.RemoveRange(_context.TblIlogDbLogs.Where(a => a.FldIlogDbIpId == id));
                await _context.SaveChangesAsync();

                _context.TblIlogDbIps.Remove(TblIlogDbIp);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Delete");
        }
    }
}
