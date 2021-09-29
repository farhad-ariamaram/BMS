using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LoggerWebApp.Models;

namespace LoggerWebApp.Pages
{
    public class EditModel : PageModel
    {
        private readonly LoggerWebApp.Models.ILogDBContext _context;

        public EditModel(LoggerWebApp.Models.ILogDBContext context)
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

            ViewData["FldIlogDbLogTypeId"] = new SelectList(_context.TblIlogDbTypes, "FldIlogDbTypeId", "FldIlogDbTypeTitle");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TblIlogDbIp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblIlogDbIpExists(TblIlogDbIp.FldIlogDbIpId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Edit");
        }

        private bool TblIlogDbIpExists(int id)
        {
            return _context.TblIlogDbIps.Any(e => e.FldIlogDbIpId == id);
        }
    }
}
