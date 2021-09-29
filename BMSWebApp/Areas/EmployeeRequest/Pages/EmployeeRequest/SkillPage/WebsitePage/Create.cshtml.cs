using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeRequest.Models;

namespace EmployeeRequest.Pages.EmployeeRequest.SkillPage.WebsitePage
{
    public class CreateModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public CreateModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        public int DefinationId { get; set; }
        public int SubDefinationId { get; set; }
        public string SubDefinationText { get; set; }

        //1=Skill
        //2=Version
        //3=Knowledge
        //4=Outline
        //5=Topic
        public IActionResult OnGet(int definationId, int subDefId)
        {
            DefinationId = definationId;
            SubDefinationId = subDefId;

            ViewData["WebsiteTypeId"] = new SelectList(_context.TblWebsiteTypes, "Id", "Title");
            return Page();
        }

        [BindProperty]
        public TblWebsite TblWebsite { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (!TblWebsite.Website.ToLower().StartsWith("http"))
            {
                TblWebsite.Website = "http://" + TblWebsite.Website;
            }

            _context.TblWebsites.Add(TblWebsite);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index",new { definationId = TblWebsite.DefinitionId, subDefId = TblWebsite.SubDefinationId });
        }
    }
}
