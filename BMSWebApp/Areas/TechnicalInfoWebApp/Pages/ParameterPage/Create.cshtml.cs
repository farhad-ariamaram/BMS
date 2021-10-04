using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechnicalInfoWebApp.Models;
using TechnicalInfoWebApp.ViewModels;

namespace TechnicalInfoWebApp.Pages.ParameterPage
{
    public class CreateModel : PageModel
    {
        private readonly TechnicalInfoWebApp.Models.TechnicalInfoDBContext _context;

        public CreateModel(TechnicalInfoWebApp.Models.TechnicalInfoDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblParameter TblParameter { get; set; }

        [BindProperty]
        public ParametersUnitsVM parametersUnitsVM { get; set; }

        public IActionResult OnGet()
        {
            ViewData["FldPhysicalQuantityId"] = new SelectList(_context.TblPhysicalQuantities, "FldPhysicalQuantityId", "FldPhysicalQuantityTxt");

            parametersUnitsVM = new ParametersUnitsVM
            {
                SelectedIds = new Guid[] { },
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

            _context.TblParameters.Add(TblParameter);
            await _context.SaveChangesAsync();

            if (parametersUnitsVM.SelectedIds != null)
            {
                foreach (var item in parametersUnitsVM.SelectedIds)
                {
                    await _context.TblParametersUnits.AddAsync(new TblParametersUnit
                    {
                        FldUnitId = item,
                        FldParametersId = TblParameter.FldParametersId
                    });
                }

                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
