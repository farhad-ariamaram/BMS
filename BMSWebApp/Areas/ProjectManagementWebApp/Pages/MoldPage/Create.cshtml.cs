using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManagementWebApp.Models;
using MoldingProjectControlWebApp.ViewModels;

namespace ProjectManagementWebApp.Pages.MoldPage
{
    public class CreateModel : PageModel
    {
        private readonly ProjectManagementDBContext _context;

        public CreateModel(ProjectManagementDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblMold TblMold { get; set; }

        [BindProperty]
        public MoldWorkpieceVM moldWorkpieceVM { get; set; }

        public void OnGet()
        {
            moldWorkpieceVM = new MoldWorkpieceVM
            {
                SelectedIds = new Guid[] { },
                Items = _context.TblWorkpieces.Select(x => new SelectListItem
                {
                    Value = x.FldWorkpieceId.ToString(),
                    Text = x.FldWorkpieceTxt
                })
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TblMolds.Add(TblMold);
            await _context.SaveChangesAsync();

            if (moldWorkpieceVM.SelectedIds != null)
            {
                foreach (var item in moldWorkpieceVM.SelectedIds)
                {
                    await _context.TblMoldWorkpieces.AddAsync(new TblMoldWorkpiece
                    {
                        FldWorkpieceId = item,
                        FldMoldId = TblMold.FldMoldId
                    });
                }

                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
