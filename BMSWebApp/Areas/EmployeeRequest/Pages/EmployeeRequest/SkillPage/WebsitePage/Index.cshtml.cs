using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeRequest.Models;

namespace EmployeeRequest.Pages.EmployeeRequest.SkillPage.WebsitePage
{
    public class IndexModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public IndexModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        public IList<TblWebsite> TblWebsite { get; set; }

        public int DefinationId { get; set; }
        public int SubDefinationId { get; set; }
        public string SubDefinationText { get; set; }

        //1=Skill
        //2=Version
        //3=Knowledge
        //4=Outline
        //5=Topic
        public async Task OnGetAsync(int definationId, int subDefId)
        {
            TblWebsite = await _context.TblWebsites
                .Where(a => a.DefinitionId == definationId && a.SubDefinationId == subDefId)
                .Include(t => t.Definition)
                .Include(t => t.WebsiteType)
                .ToListAsync();

            DefinationId = definationId;
            SubDefinationId = subDefId;

            if (definationId == 1)
            {
                SubDefinationText = _context.TblEmployeeRequestSkills.FirstOrDefault(a => a.FldEmployeeRequestSkillsId == subDefId).FldEmployeeRequestSkillsSkillTitle;
            }
            else if (definationId == 2)
            {
                SubDefinationText = _context.Versions.FirstOrDefault(a => a.Id == subDefId).Version1;
            }
            else if (definationId == 4)
            {
                SubDefinationText = _context.Outlines.FirstOrDefault(a => a.Id == subDefId).Title;
            }
            else if (definationId == 5)
            {
                SubDefinationText = _context.Topics.FirstOrDefault(a => a.Id == subDefId).Title;
            }
        }
    }
}
