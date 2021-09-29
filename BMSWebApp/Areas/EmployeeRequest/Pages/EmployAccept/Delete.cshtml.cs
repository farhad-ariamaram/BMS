using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRequest.Models;
using JW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequest.Pages.EmployAccept
{
    public class DeleteModel : PageModel
    {

        private readonly EmployeeRequestDBContext _context;

        public DeleteModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        public IEnumerable<TblEmployeeRequestEmployee> Items { get; set; }
        public IList<TblEmployeeRequestEmployee> TblEmployeeRequestEmployee { get; set; }
        public IList<TblEmployeeRequestEmployeeEditLog> TblEditLog { get; set; }
        public int currentpagesize { get; set; }
        public int currentpage { get; set; }
        public Pager Pager { get; set; }
        public string currentFilter { get; set; }
        public string currentorderBy { get; set; }
        public string currentorderType { get; set; }

        public async Task<IActionResult> OnGet(string pagesize, string search, string orderBy, string orderType, int p = 1)
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }

            TblEmployeeRequestEmployee = await _context.TblEmployeeRequestEmployees
                .Include(t => t.TblEmployeeRequestPageTimeLogs)
                .Include(t => t.TblEmployeeRequestPrimaryInformations)
                .Include(t => t.TblEmployeeRequestEmployeeEditLogs.Where(a => a.FldEmployeeRequestEmployeeEditLogSection == "Delete").OrderByDescending(s => s.FldEmployeeRequestEmployeeEditLogDate)).ThenInclude(c => c.FldEmployeeRequestUser)
                .OrderBy(a => a.TblEmployeeRequestPageTimeLogs.Where(a => a.FldEmployeeRequestPageTimeLogPageLevel == "Level1").FirstOrDefault())
                .Where(a => a.IsDelete.Value)
                .ToListAsync();

            currentpage = p;
            currentFilter = search;
            currentorderBy = orderBy;
            currentorderType = orderType;

            //setting & pagesize
            if (!string.IsNullOrEmpty(pagesize))
            {
                currentpagesize = int.Parse(pagesize);
                if (await _context.TblEmployeeRequestUserSettings.Where(a => a.FldEmployeeRequestUserId == Int64.Parse(uid)).AnyAsync())
                {
                    var t = await _context.TblEmployeeRequestUserSettings.Where(a => a.FldEmployeeRequestUserId == Int64.Parse(uid)).FirstOrDefaultAsync();
                    t.FldEmployeeRequestUserSettingPageSize = int.Parse(pagesize);
                    _context.Update(t);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    await _context.TblEmployeeRequestUserSettings.AddAsync(new TblEmployeeRequestUserSetting
                    {
                        FldEmployeeRequestUserId = Int64.Parse(uid),
                        FldEmployeeRequestUserSettingPageSize = int.Parse(pagesize)
                    });

                    await _context.SaveChangesAsync();
                }
            }
            else
            {
                if (await _context.TblEmployeeRequestUserSettings.Where(a => a.FldEmployeeRequestUserId == Int64.Parse(uid)).AnyAsync())
                {
                    var t = await _context.TblEmployeeRequestUserSettings.Where(a => a.FldEmployeeRequestUserId == Int64.Parse(uid)).FirstOrDefaultAsync();
                    currentpagesize = t.FldEmployeeRequestUserSettingPageSize;
                }
                else
                {
                    await _context.TblEmployeeRequestUserSettings.AddAsync(new TblEmployeeRequestUserSetting
                    {
                        FldEmployeeRequestUserId = Int64.Parse(uid),
                        FldEmployeeRequestUserSettingPageSize = 5
                    });

                    await _context.SaveChangesAsync();
                    currentpagesize = 5;
                }
            }

            //sort
            if (!string.IsNullOrEmpty(orderBy))
            {
                switch (orderBy)
                {
                    case "name":
                        if (orderType == "desc")
                        {
                            TblEmployeeRequestEmployee = TblEmployeeRequestEmployee.OrderByDescending(a => a.TblEmployeeRequestPrimaryInformations.FirstOrDefault().FldEmployeeRequestPrimaryInformationFirstName).ToList();
                        }
                        else
                        {
                            TblEmployeeRequestEmployee = TblEmployeeRequestEmployee.OrderBy(a => a.TblEmployeeRequestPrimaryInformations.FirstOrDefault().FldEmployeeRequestPrimaryInformationFirstName).ToList();
                        }
                        break;
                    case "deldate":
                        if (orderType == "desc")
                        {
                            TblEmployeeRequestEmployee = TblEmployeeRequestEmployee.OrderByDescending(a => a.TblEmployeeRequestEmployeeEditLogs.FirstOrDefault().FldEmployeeRequestEmployeeEditLogDate).ToList();
                        }
                        else
                        {
                            TblEmployeeRequestEmployee = TblEmployeeRequestEmployee.OrderBy(a => a.TblEmployeeRequestEmployeeEditLogs.FirstOrDefault().FldEmployeeRequestEmployeeEditLogDate).ToList();
                        }
                        break;
                    case "deleter":
                        if (orderType == "desc")
                        {
                            TblEmployeeRequestEmployee = TblEmployeeRequestEmployee.OrderByDescending(a => a.TblEmployeeRequestEmployeeEditLogs.FirstOrDefault().FldEmployeeRequestUser.FldEmployeeRequestUserName).ToList();
                        }
                        else
                        {
                            TblEmployeeRequestEmployee = TblEmployeeRequestEmployee.OrderBy(a => a.TblEmployeeRequestEmployeeEditLogs.FirstOrDefault().FldEmployeeRequestUser.FldEmployeeRequestUserName).ToList();
                        }
                        break;
                    default:
                        if (orderType == "desc")
                        {
                            TblEmployeeRequestEmployee = TblEmployeeRequestEmployee.OrderByDescending(a => a.TblEmployeeRequestPageTimeLogs.FirstOrDefault().FldEmployeeRequestPageTimeLogStartTime).ToList();
                        }
                        else
                        {
                            TblEmployeeRequestEmployee = TblEmployeeRequestEmployee.OrderBy(a => a.TblEmployeeRequestPageTimeLogs.FirstOrDefault().FldEmployeeRequestPageTimeLogStartTime).ToList();
                        }
                        break;
                }
            }

            //search
            if (!string.IsNullOrEmpty(search))
            {
                TblEmployeeRequestEmployee = TblEmployeeRequestEmployee
                    .Where(a =>
                        a.TblEmployeeRequestPrimaryInformations.FirstOrDefault().FldEmployeeRequestPrimaryInformationFirstName.Contains(search) ||
                        a.TblEmployeeRequestPrimaryInformations.FirstOrDefault().FldEmployeeRequestPrimaryInformationLastName.Contains(search) ||
                        a.TblEmployeeRequestPrimaryInformations.FirstOrDefault().FldEmployeeRequestPrimaryInformationNationalCode.Contains(search) ||
                        a.TblEmployeeRequestPrimaryInformations.FirstOrDefault().FldEmployeeRequestPrimaryInformationPhoneNo.Contains(search))
                    .ToList();
            }

            Pager = new Pager(TblEmployeeRequestEmployee.Count(), p, currentpagesize);
            Items = TblEmployeeRequestEmployee.Skip((Pager.CurrentPage - 1) * Pager.PageSize).Take(Pager.PageSize);

            return Page();
        }

        public IActionResult OnGetUnDeleteUser(string id)
        {
            TblEmployeeRequestEmployee TblEmployeeRequestEmployee2 = _context.TblEmployeeRequestEmployees.Find(id);
            if (TblEmployeeRequestEmployee2 != null)
            {
                string uid = HttpContext.Session.GetString("uid");
                if (uid == null)
                {
                    return RedirectToPage("../Index");
                }

                TblEmployeeRequestEmployee2.IsDelete = false;
                TblEmployeeRequestEmployee2.DeleteDescription = "";

                _context.TblEmployeeRequestEmployees.Update(TblEmployeeRequestEmployee2);
                _context.SaveChanges();

                _context.TblEmployeeRequestEmployeeEditLogs.Add(new TblEmployeeRequestEmployeeEditLog
                {
                    FldEmployeeRequestUserId = Int64.Parse(uid),
                    FldEmployeeRequestEmployeeEditLogDate = DateTime.Now,
                    FldEmployeeRequestEmployeeEditLogSection = "UnDelete",
                    FldEmployeeRequestEmployeeId = TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeeId
                });
                _context.SaveChanges();
            }
            return RedirectToPage("Index");
        }
    }
}
