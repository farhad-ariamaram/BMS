using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TechnicalInfoWebApp.Pages
{
    public class TechnicalGroupRefModel : PageModel
    {
        private readonly TechnicalInfoWebApp.Models.TechnicalInfoDBContext _context;

        public TechnicalGroupRefModel(TechnicalInfoWebApp.Models.TechnicalInfoDBContext context)
        {
            _context = context;
        }

        public List<Models.TblTechnicalInfo> tblTechnicalInfos { get; set; }

        public async Task<IActionResult> OnGet(string refrence, string refTechInfoGroup)
        {
            var h = int.Parse(refrence);
            var t = await _context.TblTechnicalInfoGroups.Where(a => a.FldReferenceId == h).FirstOrDefaultAsync();
            if (t == null)
            {
                ViewData["status"] = "400";
                return Page();
            }

            var rtig = new Models.TblReferenceTechnicalInfoGroup
            {
                FldReferenceId = t.FldReferenceId,
                FldTechnicalInfoGroupId = t.FldTechnicalInfoGroupId,
                FldReferenceTechnicalInfoGroupReferenceId = refTechInfoGroup
            };

            await _context.TblReferenceTechnicalInfoGroups.AddAsync(rtig);

            await _context.SaveChangesAsync();

            tblTechnicalInfos = await _context.TblTechnicalInfos
                .Include(t => t.FldTechnicalInfoDataTypes)
                .ThenInclude(t => t.TblTechnicalInfoDataTypesValues)
                .Include(t => t.FldTechnicalInfoDataTypes)
                .ThenInclude(t => t.FldDataDisplayType)
                .Where(a => a.FldTechnicalInfoGroupId == t.FldTechnicalInfoGroupId)
                .ToListAsync();

            ViewData["status"] = "200";
            ViewData["FldTechnicalInfoGroupId"] = t.FldTechnicalInfoGroupId;
            ViewData["FldReferenceTechnicalInfoGroupId"] = rtig.FldReferenceTechnicalInfoGroupId;
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var t = Request.Form["FldTechnicalInfoGroupId"].ToString();

            tblTechnicalInfos = await _context.TblTechnicalInfos
            .Include(t => t.FldTechnicalInfoDataTypes)
            .ThenInclude(t => t.TblTechnicalInfoDataTypesValues)
            .Include(t => t.FldTechnicalInfoDataTypes)
            .ThenInclude(t => t.FldDataDisplayType)
            .Where(a => a.FldTechnicalInfoGroupId.ToString() == t)
            .ToListAsync();

            foreach (var item in tblTechnicalInfos)
            {
                await _context.TblReferenceValues.AddAsync(new Models.TblReferenceValue { 
                    FldReferenceTechnicalInfoGroupId = toGuid(Request.Form["FldReferenceTechnicalInfoGroupId"].ToString()),
                    FldTechnicalInfoId = item.FldTechnicalInfoId,
                    FldReferenceValuesValue = Request.Form[item.FldTechnicalInfoId.ToString()].ToString(),
                    FldReferenceValuesDirection = Request.Form["dir"+item.FldTechnicalInfoId.ToString()].ToString()
                });
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private Guid toGuid(string s)
        {
            Guid ownerIdGuid = Guid.Empty;
            ownerIdGuid = new Guid(s);
            return ownerIdGuid;
        }
    }
}
