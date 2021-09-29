using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeRequest.Models;
using Microsoft.AspNetCore.Http;
using JW;

namespace EmployeeRequest.Pages.EmployAccept
{
    public class IndexModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public IndexModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        public IList<TblEmployeeRequestEmployee> TblEmployeeRequestEmployee { get; set; }

        public string currentFilter { get; set; }
        public string currentprim { get; set; }
        public string currentfinal { get; set; }
        public int currentpagesize { get; set; }
        public int currentpage { get; set; }
        public string currentorderBy { get; set; }
        public string currentorderType { get; set; }

        //paging
        public IEnumerable<TblEmployeeRequestEmployee> Items { get; set; }
        public Pager Pager { get; set; }

        public async Task<IActionResult> OnGetAsync(string duplicate,
                                                    string search,
                                                    string prim,
                                                    string final,
                                                    string orderType,
                                                    string orderBy,
                                                    string pagesize,
                                                    int p = 1)
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }

            TblEmployeeRequestEmployee = await _context.TblEmployeeRequestEmployees
                .Include(t => t.FldEmployeeRequestFinalAcception)
                .Include(t => t.FldEmployeeRequestPagesSequence)
                .Include(t => t.FldEmployeeRequestPrimaryAcception)
                .Include(t => t.FldEmployeeRequestUserFinalAccepter)
                .Include(t => t.FldEmployeeRequestUserPrimaryAccepter)
                .Include(t => t.TblEmployeeRequestPageTimeLogs)
                .Include(t => t.TblEmployeeRequestPrimaryInformations)
                .OrderByDescending(a => a.TblEmployeeRequestPageTimeLogs.Where(a => a.FldEmployeeRequestPageTimeLogPageLevel == "Level1").FirstOrDefault())
                .Where(a=>!a.IsDelete.Value)
                .ToListAsync();

            currentFilter = search;
            currentprim = prim;
            currentfinal = final;
            currentpage = p;
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

            //duplicate
            if (!string.IsNullOrEmpty(duplicate))
            {
                TblEmployeeRequestEmployee = TblEmployeeRequestEmployee
                    .Where(a =>
                        a.TblEmployeeRequestPrimaryInformations.FirstOrDefault().FldEmployeeRequestPrimaryInformationNationalCode == duplicate ||
                        a.TblEmployeeRequestPrimaryInformations.FirstOrDefault().FldEmployeeRequestPrimaryInformationPhoneNo == duplicate ||
                        a.TblEmployeeRequestPrimaryInformations.FirstOrDefault().FldEmployeeRequestPrimaryInformationPostalCode == duplicate)
                    .ToList();
            }

            //search
            if (!string.IsNullOrEmpty(search))
            {
                TblEmployeeRequestEmployee = TblEmployeeRequestEmployee
                    .Where(a =>
                        a.TblEmployeeRequestPrimaryInformations.FirstOrDefault().FldEmployeeRequestPrimaryInformationFirstName.Contains(search) ||
                        a.TblEmployeeRequestPrimaryInformations.FirstOrDefault().FldEmployeeRequestPrimaryInformationLastName.Contains(search))
                    .ToList();
            }

            //primary
            if (prim == "0")
            {
                TblEmployeeRequestEmployee = TblEmployeeRequestEmployee
                    .Where(a => a.FldEmployeeRequestPrimaryAcceptionId == null || a.FldEmployeeRequestPrimaryAcceptionId == 1)
                    .ToList();

            }
            else if (prim == "1")
            {
                TblEmployeeRequestEmployee = TblEmployeeRequestEmployee
                    .Where(a => a.FldEmployeeRequestPrimaryAcceptionId == 3)
                    .ToList();
            }
            else if (prim == "2")
            {
                TblEmployeeRequestEmployee = TblEmployeeRequestEmployee
                    .Where(a => a.FldEmployeeRequestPrimaryAcceptionId == 2)
                    .ToList();
            }

            //final
            if (final == "0")
            {
                TblEmployeeRequestEmployee = TblEmployeeRequestEmployee
                    .Where(a => a.FldEmployeeRequestFinalAcceptionId == null)
                    .ToList();

            }
            else if (final == "1")
            {
                TblEmployeeRequestEmployee = TblEmployeeRequestEmployee
                    .Where(a => a.FldEmployeeRequestFinalAcceptionId == 1)
                    .ToList();
            }
            else if (final == "2")
            {
                TblEmployeeRequestEmployee = TblEmployeeRequestEmployee
                    .Where(a => a.FldEmployeeRequestFinalAcceptionId == 2)
                    .ToList();
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
                    case "regdate":
                        if (orderType == "desc")
                        {
                            TblEmployeeRequestEmployee = TblEmployeeRequestEmployee.OrderByDescending(a => a.TblEmployeeRequestPageTimeLogs.FirstOrDefault().FldEmployeeRequestPageTimeLogStartTime).ToList();
                        }
                        else
                        {
                            TblEmployeeRequestEmployee = TblEmployeeRequestEmployee.OrderBy(a => a.TblEmployeeRequestPageTimeLogs.FirstOrDefault().FldEmployeeRequestPageTimeLogStartTime).ToList();
                        }
                        break;
                    case "primacc":
                        if (orderType == "desc")
                        {
                            TblEmployeeRequestEmployee = TblEmployeeRequestEmployee.OrderByDescending(a => a.FldEmployeeRequestUserPrimaryAccepterId).ToList();
                        }
                        else
                        {
                            TblEmployeeRequestEmployee = TblEmployeeRequestEmployee.OrderBy(a => a.FldEmployeeRequestUserPrimaryAccepterId).ToList();
                        }
                        break;
                    case "finalacc":
                        if (orderType == "desc")
                        {
                            TblEmployeeRequestEmployee = TblEmployeeRequestEmployee.OrderByDescending(a => a.FldEmployeeRequestUserFinalAccepterId).ToList();
                        }
                        else
                        {
                            TblEmployeeRequestEmployee = TblEmployeeRequestEmployee.OrderBy(a => a.FldEmployeeRequestUserFinalAccepterId).ToList();
                        }
                        break;
                    case "primaccdate":
                        if (orderType == "desc")
                        {
                            TblEmployeeRequestEmployee = TblEmployeeRequestEmployee.OrderByDescending(a => a.FldEmployeeRequestEmployeePrimaryAcceptionDate).ToList();
                        }
                        else
                        {
                            TblEmployeeRequestEmployee = TblEmployeeRequestEmployee.OrderBy(a => a.FldEmployeeRequestEmployeePrimaryAcceptionDate).ToList();
                        }
                        break;
                    case "finalaccdate":
                        if (orderType == "desc")
                        {
                            TblEmployeeRequestEmployee = TblEmployeeRequestEmployee.OrderByDescending(a => a.FldEmployeeRequestEmployeeFinalAcceptionDate).ToList();
                        }
                        else
                        {
                            TblEmployeeRequestEmployee = TblEmployeeRequestEmployee.OrderBy(a => a.FldEmployeeRequestEmployeeFinalAcceptionDate).ToList();
                        }
                        break;
                    case "interstartdate":
                        if (orderType == "desc")
                        {
                            TblEmployeeRequestEmployee = TblEmployeeRequestEmployee.OrderByDescending(a => a.FldEmployeeRequestEmployeeInterviewStartDate).ToList();
                        }
                        else
                        {
                            TblEmployeeRequestEmployee = TblEmployeeRequestEmployee.OrderBy(a => a.FldEmployeeRequestEmployeeInterviewStartDate).ToList();
                        }
                        break;
                    case "interenddate":
                        if (orderType == "desc")
                        {
                            TblEmployeeRequestEmployee = TblEmployeeRequestEmployee.OrderByDescending(a => a.FldEmployeeRequestEmployeeInterviewEndDate).ToList();
                        }
                        else
                        {
                            TblEmployeeRequestEmployee = TblEmployeeRequestEmployee.OrderBy(a => a.FldEmployeeRequestEmployeeInterviewEndDate).ToList();
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

            // paging
            Pager = new Pager(TblEmployeeRequestEmployee.Count(), p, currentpagesize);
            Items = TblEmployeeRequestEmployee.Skip((Pager.CurrentPage - 1) * Pager.PageSize).Take(Pager.PageSize);

            return Page();
        }

        public IActionResult OnGetAccept(string id, string description)
        {
            TblEmployeeRequestEmployee TblEmployeeRequestEmployee2 = _context.TblEmployeeRequestEmployees.Find(id);
            if (TblEmployeeRequestEmployee2 != null)
            {
                string uid = HttpContext.Session.GetString("uid");
                if (uid == null)
                {
                    return RedirectToPage("../Index");
                }
                TblEmployeeRequestEmployee2.FldEmployeeRequestPrimaryAcceptionId = 3;
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeePrimaryAcceptionDate = DateTime.Now;
                TblEmployeeRequestEmployee2.FldEmployeeRequestUserPrimaryAccepterId = Int64.Parse(uid);
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeePrimaryAcceptDescription = description;
                _context.TblEmployeeRequestEmployees.Update(TblEmployeeRequestEmployee2);
                _context.SaveChanges();
            }
            return RedirectToPage("Index");
        }

        public IActionResult OnGetDeny(string id, string description)
        {
            TblEmployeeRequestEmployee TblEmployeeRequestEmployee2 = _context.TblEmployeeRequestEmployees.Find(id);
            if (TblEmployeeRequestEmployee2 != null)
            {
                string uid = HttpContext.Session.GetString("uid");
                if (uid == null)
                {
                    return RedirectToPage("../Index");
                }
                TblEmployeeRequestEmployee2.FldEmployeeRequestPrimaryAcceptionId = 2;
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeePrimaryAcceptionDate = DateTime.Now;
                TblEmployeeRequestEmployee2.FldEmployeeRequestUserPrimaryAccepterId = Int64.Parse(uid);
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeePrimaryRejectDescription = description;
                _context.TblEmployeeRequestEmployees.Update(TblEmployeeRequestEmployee2);
                _context.SaveChanges();
            }
            return RedirectToPage("Index");
        }

        public IActionResult OnGetFAccept(string id, string description)
        {
            TblEmployeeRequestEmployee TblEmployeeRequestEmployee2 = _context.TblEmployeeRequestEmployees.Find(id);
            if (TblEmployeeRequestEmployee2 != null)
            {
                string uid = HttpContext.Session.GetString("uid");
                if (uid == null)
                {
                    return RedirectToPage("../Index");
                }
                TblEmployeeRequestEmployee2.FldEmployeeRequestFinalAcceptionId = 1;
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeeFinalAcceptionDate = DateTime.Now;
                TblEmployeeRequestEmployee2.FldEmployeeRequestUserFinalAccepterId = Int64.Parse(uid);
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeeFinalAcceptDescription = description;
                _context.TblEmployeeRequestEmployees.Update(TblEmployeeRequestEmployee2);
                _context.SaveChanges();
            }
            return RedirectToPage("Index");
        }

        public IActionResult OnGetFDeny(string id, string description)
        {
            TblEmployeeRequestEmployee TblEmployeeRequestEmployee2 = _context.TblEmployeeRequestEmployees.Find(id);
            if (TblEmployeeRequestEmployee2 != null)
            {
                string uid = HttpContext.Session.GetString("uid");
                if (uid == null)
                {
                    return RedirectToPage("../Index");
                }
                TblEmployeeRequestEmployee2.FldEmployeeRequestFinalAcceptionId = 2;
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeeFinalAcceptionDate = DateTime.Now;
                TblEmployeeRequestEmployee2.FldEmployeeRequestUserFinalAccepterId = Int64.Parse(uid);
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeeFinalRejectDescription = description;
                _context.TblEmployeeRequestEmployees.Update(TblEmployeeRequestEmployee2);
                _context.SaveChanges();
            }
            return RedirectToPage("Index");
        }

        public IActionResult OnGetFRevert(string id)
        {
            TblEmployeeRequestEmployee TblEmployeeRequestEmployee2 = _context.TblEmployeeRequestEmployees.Find(id);
            if (TblEmployeeRequestEmployee2 != null)
            {
                string uid = HttpContext.Session.GetString("uid");
                if (uid == null)
                {
                    return RedirectToPage("../Index");
                }
                TblEmployeeRequestEmployee2.FldEmployeeRequestFinalAcceptionId = null;
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeeFinalAcceptionDate = null;
                TblEmployeeRequestEmployee2.FldEmployeeRequestUserFinalAccepterId = null;
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeeFinalRejectDescription = null;
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeeFinalAcceptDescription = null;
                _context.TblEmployeeRequestEmployees.Update(TblEmployeeRequestEmployee2);
                _context.SaveChanges();
            }
            return RedirectToPage("Index");
        }

        public IActionResult OnGetRevert(string id)
        {
            TblEmployeeRequestEmployee TblEmployeeRequestEmployee2 = _context.TblEmployeeRequestEmployees.Find(id);
            if (TblEmployeeRequestEmployee2 != null)
            {
                string uid = HttpContext.Session.GetString("uid");
                if (uid == null)
                {
                    return RedirectToPage("../Index");
                }
                TblEmployeeRequestEmployee2.FldEmployeeRequestPrimaryAcceptionId = null;
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeePrimaryAcceptionDate = null;
                TblEmployeeRequestEmployee2.FldEmployeeRequestUserPrimaryAccepterId = null;
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeePrimaryAcceptDescription = null;
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeePrimaryRejectDescription = null;
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeeRejectFromUserDescription = null;
                if (TblEmployeeRequestEmployee2.FldEmployeeRequestFinalAcceptionId != null)
                {
                    TblEmployeeRequestEmployee2.FldEmployeeRequestFinalAcceptionId = null;
                    TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeeFinalAcceptionDate = null;
                    TblEmployeeRequestEmployee2.FldEmployeeRequestUserFinalAccepterId = null;
                    TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeeFinalRejectDescription = null;
                    TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeeFinalAcceptDescription = null;
                }

                _context.TblEmployeeRequestEmployees.Update(TblEmployeeRequestEmployee2);
                _context.SaveChanges();
            }
            return RedirectToPage("Index");
        }

        public IActionResult OnGetIRevert(string id)
        {
            TblEmployeeRequestEmployee TblEmployeeRequestEmployee2 = _context.TblEmployeeRequestEmployees.Find(id);
            if (TblEmployeeRequestEmployee2 != null)
            {
                string uid = HttpContext.Session.GetString("uid");
                if (uid == null)
                {
                    return RedirectToPage("../Index");
                }
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeeInterviewEndDate = null;
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeeInterviewStartDate = null;
                _context.TblEmployeeRequestEmployees.Update(TblEmployeeRequestEmployee2);
                _context.SaveChanges();
            }
            return RedirectToPage("Index");
        }

        public IActionResult OnGetRejectFromUser(string id, string description)
        {
            TblEmployeeRequestEmployee TblEmployeeRequestEmployee2 = _context.TblEmployeeRequestEmployees.Find(id);
            if (TblEmployeeRequestEmployee2 != null)
            {
                string uid = HttpContext.Session.GetString("uid");
                if (uid == null)
                {
                    return RedirectToPage("../Index");
                }
                TblEmployeeRequestEmployee2.FldEmployeeRequestPrimaryAcceptionId = 2;
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeePrimaryAcceptionDate = DateTime.Now;
                TblEmployeeRequestEmployee2.FldEmployeeRequestUserPrimaryAccepterId = Int64.Parse(uid);
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeeRejectFromUserDescription = description;
                TblEmployeeRequestEmployee2.FldEmployeeRequestFinalAcceptionId = 2;
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeeFinalAcceptionDate = DateTime.Now;
                TblEmployeeRequestEmployee2.FldEmployeeRequestUserFinalAccepterId = Int64.Parse(uid);
                _context.TblEmployeeRequestEmployees.Update(TblEmployeeRequestEmployee2);
                _context.SaveChanges();
            }
            return RedirectToPage("Index");
        }

        public IActionResult OnGetDeleteUser(string id, string description)
        {
            TblEmployeeRequestEmployee TblEmployeeRequestEmployee2 = _context.TblEmployeeRequestEmployees.Find(id);
            if (TblEmployeeRequestEmployee2 != null)
            {
                string uid = HttpContext.Session.GetString("uid");
                if (uid == null)
                {
                    return RedirectToPage("../Index");
                }

                TblEmployeeRequestEmployee2.IsDelete = true;
                TblEmployeeRequestEmployee2.DeleteDescription = description;
               
                _context.TblEmployeeRequestEmployees.Update(TblEmployeeRequestEmployee2);
                _context.SaveChanges();

                _context.TblEmployeeRequestEmployeeEditLogs.Add(new TblEmployeeRequestEmployeeEditLog
                {
                    FldEmployeeRequestUserId = Int64.Parse(uid),
                    FldEmployeeRequestEmployeeEditLogDate = DateTime.Now,
                    FldEmployeeRequestEmployeeEditLogSection = "Delete",
                    FldEmployeeRequestEmployeeId = TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeeId
                });
                _context.SaveChanges();
            }
            return RedirectToPage("Index");
        }

    }
}
