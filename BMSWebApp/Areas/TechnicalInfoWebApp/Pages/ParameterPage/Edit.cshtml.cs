using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechnicalInfoWebApp.Models;
using TechnicalInfoWebApp.ViewModels;

namespace TechnicalInfoWebApp.Pages.ParameterPage
{
    public class EditModel : PageModel
    {
        private readonly TechnicalInfoWebApp.Models.TechnicalInfoDBContext _context;

        public EditModel(TechnicalInfoWebApp.Models.TechnicalInfoDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblParameter TblParameter { get; set; }


        [BindProperty]
        public ParametersUnitsVM parametersUnitsVM { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblParameter = await _context.TblParameters
                .Include(t => t.FldPhysicalQuantity).FirstOrDefaultAsync(m => m.FldParametersId == id);

            if (TblParameter == null)
            {
                return NotFound();
            }
            
            ViewData["FldPhysicalQuantityId"] = new SelectList(_context.TblPhysicalQuantities, "FldPhysicalQuantityId", "FldPhysicalQuantityTxt");

            parametersUnitsVM = new ParametersUnitsVM
            {
                SelectedIds = _context.TblParametersUnits.Where(x =>
                    x.FldParametersId == id).Select(a => a.FldUnitId).ToArray(),
                Items = _context.TblUnits.Select(x => new SelectListItem
                {
                    Value = x.FldUnitId.ToString(),
                    Text = x.FldUnitName
                })
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TblParameter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                var f = _context.TblParametersUnits.Where(x => x.FldParametersId == TblParameter.FldParametersId);
                foreach (var item in f)
                {
                    _context.Remove(item);
                }

                await _context.SaveChangesAsync();

                if (parametersUnitsVM.SelectedIds != null)
                {

                    foreach (var item in parametersUnitsVM.SelectedIds)
                    {
                        await _context.TblParametersUnits.AddAsync(new TblParametersUnit
                        {
                            FldParametersId = TblParameter.FldParametersId,
                            FldUnitId = item
                        });
                    }

                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblParameterExists(TblParameter.FldParametersId))
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

        private bool TblParameterExists(Guid id)
        {
            return _context.TblParameters.Any(e => e.FldParametersId == id);
        }
    }
}
