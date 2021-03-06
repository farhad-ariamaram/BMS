using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuardWebApp.Models;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace GuardWebApp.Pages.ShiftPage
{
    public class EditModel : PageModel
    {
        private readonly GuardWebApp.Models.GuardianDBContext _context;

        public EditModel(GuardWebApp.Models.GuardianDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Shift Shift { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            var uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }

            if (id == null)
            {
                return NotFound();
            }

            Shift = await _context.Shifts
                .Include(s => s.GuardArea)
                .Include(s => s.Rhythm).FirstOrDefaultAsync(m => m.Id == id);

            if (Shift == null)
            {
                return NotFound();
            }

            var guardArea = await _context.GuardAreas.FindAsync(Shift.GuardAreaId);
            ViewData["GuardAreaName"] = guardArea.Description;
            ViewData["RhythmId"] = new SelectList(_context.Rhythms.Where(a=>a.GuardAreaId==Shift.GuardAreaId), "Id", "Title");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            PersianCalendar pc = new PersianCalendar();
            Shift.DateTime = new System.DateTime(1400, int.Parse(Request.Form["monthField"].ToString()), int.Parse(Request.Form["dayField"].ToString()), pc);

            _context.Attach(Shift).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShiftExists(Shift.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ShiftExists(long id)
        {
            return _context.Shifts.Any(e => e.Id == id);
        }
    }
}
