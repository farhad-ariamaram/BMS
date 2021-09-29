using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeRequest.Models;
using EmployeeRequest.Utilities;
using Microsoft.AspNetCore.Http;

namespace EmployeeRequest.Pages.EmployeeRequest
{
    public class EditModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public EditModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblEmployeeRequestEmployeeRequest TblEmployeeRequestEmployeeRequest { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblEmployeeRequestEmployeeRequest = await _context.TblEmployeeRequestEmployeeRequests
                .Include(t => t.FldEmployeeRequestJobOnet)
                .Include(t => t.FldEmployeeRequestJobTamin)
                .Include(t => t.FldEmployeeRequestJobTitleFrom)
                .Include(t => t.FldEmployeeRequestJobs)
                .Include(t => t.FldEmployeeRequestUserAccepter)
                .Include(t => t.FldEmployeeRequestUserApplicant)
                .Include(t => t.FldEmployeeRequestUserSubmitter).FirstOrDefaultAsync(m => m.FldEmployeeRequestEmployeeRequestId == id);

            if (TblEmployeeRequestEmployeeRequest == null)
            {
                return NotFound();
            }

            ViewData["FldEmployeeRequestJobTitleFromId"] = new SelectList(_context.TblEmployeeRequestJobTitleFroms, "TblEmployeeRequestJobTitleFromId", "TblEmployeeRequestJobTitleFromTitle");
            ViewData["FldEmployeeRequestUserApplicantId"] = new SelectList(_context.TblEmployeeRequestUsers, "FldEmployeeRequestUserId", "FldEmployeeRequestUserUsername");
            ViewData["FldEmployeeRequestUserSubmitterId"] = new SelectList(_context.TblEmployeeRequestUsers, "FldEmployeeRequestUserId", "FldEmployeeRequestUserUsername");
            ViewData["startdate"] = TblEmployeeRequestEmployeeRequest.FldEmployeeRequestEmployeeRequestStartDate.toPersianDate();
            ViewData["enddate"] = TblEmployeeRequestEmployeeRequest.FldEmployeeRequestEmployeeRequestEndDate.toPersianDate();

            if (TblEmployeeRequestEmployeeRequest.FldEmployeeRequestJobTaminId != null)
            {
                ViewData["taminjobtitle"] = TblEmployeeRequestEmployeeRequest.FldEmployeeRequestJobTamin.FldTaminJobName;
            }

            if (TblEmployeeRequestEmployeeRequest.FldEmployeeRequestJobOnetId != null)
            {
                ViewData["onetjobtitle"] = TblEmployeeRequestEmployeeRequest.FldEmployeeRequestJobOnet.FldJobName;
            }

            if (TblEmployeeRequestEmployeeRequest.FldEmployeeRequestJobsId != null)
            {
                ViewData["jobtitle"] = TblEmployeeRequestEmployeeRequest.FldEmployeeRequestJobs.JobsName;
            }

            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["FldEmployeeRequestJobTitleFromId"] = new SelectList(_context.TblEmployeeRequestJobTitleFroms, "TblEmployeeRequestJobTitleFromId", "TblEmployeeRequestJobTitleFromTitle");
                ViewData["FldEmployeeRequestUserApplicantId"] = new SelectList(_context.TblEmployeeRequestUsers, "FldEmployeeRequestUserId", "FldEmployeeRequestUserUsername");
                ViewData["FldEmployeeRequestUserSubmitterId"] = new SelectList(_context.TblEmployeeRequestUsers, "FldEmployeeRequestUserId", "FldEmployeeRequestUserUsername");
                ViewData["startdate"] = TblEmployeeRequestEmployeeRequest.FldEmployeeRequestEmployeeRequestStartDate.toPersianDate();
                ViewData["enddate"] = TblEmployeeRequestEmployeeRequest.FldEmployeeRequestEmployeeRequestEndDate.toPersianDate();

                if (TblEmployeeRequestEmployeeRequest.FldEmployeeRequestJobTaminId != null)
                {
                    ViewData["taminjobtitle"] = TblEmployeeRequestEmployeeRequest.FldEmployeeRequestJobTamin.FldTaminJobName;
                }

                if (TblEmployeeRequestEmployeeRequest.FldEmployeeRequestJobOnetId != null)
                {
                    ViewData["onetjobtitle"] = TblEmployeeRequestEmployeeRequest.FldEmployeeRequestJobOnet.FldJobName;
                }

                if (TblEmployeeRequestEmployeeRequest.FldEmployeeRequestJobsId != null)
                {
                    ViewData["jobtitle"] = TblEmployeeRequestEmployeeRequest.FldEmployeeRequestJobs.JobsName;
                }
                return Page();
            }

            if (!string.IsNullOrEmpty(Request.Form["taminjobdropdown"].ToString()))
            {
                TblEmployeeRequestEmployeeRequest.FldEmployeeRequestJobTaminId = int.Parse(Request.Form["taminjobdropdown"].ToString());
            }
            if (!string.IsNullOrEmpty(Request.Form["jobdropdown"].ToString()))
            {
                TblEmployeeRequestEmployeeRequest.FldEmployeeRequestJobsId = int.Parse(Request.Form["jobdropdown"].ToString());
            }
            if (!string.IsNullOrEmpty(Request.Form["onetjobdropdown"].ToString()))
            {
                TblEmployeeRequestEmployeeRequest.FldEmployeeRequestJobOnetId = int.Parse(Request.Form["onetjobdropdown"].ToString());
            }

            _context.Attach(TblEmployeeRequestEmployeeRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblEmployeeRequestEmployeeRequestExists(TblEmployeeRequestEmployeeRequest.FldEmployeeRequestEmployeeRequestId))
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

        public async Task<IActionResult> OnGetJobsAsync(string jobName)
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }
            return new JsonResult(_context.TblJobTamins.Where(a => a.FldTaminJobName.Contains(jobName) || a.FldTaminJobName.Contains(jobName.Replace("ی", "ي").Replace("ک", "ك"))).Select(a => new { a.FldTaminJobId, a.FldTaminJobName }).ToList());
        }

        public async Task<IActionResult> OnGetJobsoAsync(string jobName)
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }
            return new JsonResult(_context.TblJobs.Where(a => a.FldJobName.Contains(jobName) || a.FldJobName.Contains(jobName.Replace("ی", "ي").Replace("ک", "ك"))).Select(a => new { a.FldJobId, a.FldJobName }).ToList());
        }

        public async Task<IActionResult> OnGetJobseAsync(string jobName)
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }
            return new JsonResult(_context.PayJobs.Where(a => a.JobsName.Contains(jobName) || a.JobsName.Contains(jobName.Replace("ی", "ي").Replace("ک", "ك"))).Select(a => new { a.JobsId, a.JobsName }).ToList());
        }

        private bool TblEmployeeRequestEmployeeRequestExists(long id)
        {
            return _context.TblEmployeeRequestEmployeeRequests.Any(e => e.FldEmployeeRequestEmployeeRequestId == id);
        }
    }
}
