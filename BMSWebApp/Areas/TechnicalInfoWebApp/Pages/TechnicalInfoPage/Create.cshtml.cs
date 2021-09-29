using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechnicalInfoWebApp.Models;

namespace TechnicalInfoWebApp.Pages.TechnicalInfoPage
{
    public class CreateModel : PageModel
    {
        private readonly TechnicalInfoWebApp.Models.TechnicalInfoDBContext _context;

        public CreateModel(TechnicalInfoWebApp.Models.TechnicalInfoDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnGetFillType(Guid id)
        {
            ViewData["FldTechnicalInfoGroupId"] = new SelectList(_context.TblTechnicalInfoGroups, "FldTechnicalInfoGroupId", "FldTechnicalInfoGroupTxt");

            return new JsonResult(_context.TblTechnicalInfoDataTypes.Where(a => !(from b in _context.TblTechnicalInfos where b.FldTechnicalInfoGroupId == id select b.FldTechnicalInfoDataTypesId).Contains(a.FldTechnicalInfoDataTypesId)).Select(x => new
            {
                id = x.FldTechnicalInfoDataTypesId,
                value = x.FldTechnicalInfoDataTypesTxt
            }).ToList());
        }

        public IActionResult OnGetFillGroup()
        {
            return new JsonResult(_context.TblTechnicalInfoGroups.Include(a=>a.FldReference).Select(x => new
            {
                id = x.FldTechnicalInfoGroupId,
                value = x.FldTechnicalInfoGroupTxt + " - رفرنس :" + x.FldReference.FldReferenceTxt
            }).ToList());
        }

        [BindProperty]
        public TblTechnicalInfo TblTechnicalInfo { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TblTechnicalInfos.Add(TblTechnicalInfo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
