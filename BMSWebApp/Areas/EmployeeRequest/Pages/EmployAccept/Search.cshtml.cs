using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRequest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequest.Pages.EmployAccept
{
    public class SearchModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public SearchModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        public List<TblEmployeeRequestJob> TblEmployeeRequestJob { get; set; }
        public List<TblEmployeeRequestLanguageType> TblEmployeeRequestLanguageType { get; set; }
        public List<TblEmployeeRequestMilitary> TblEmployeeRequestMilitary { get; set; }
        public List<TblEmployeeRequestMilitaryOrganization> TblEmployeeRequestMilitaryOrganization { get; set; }

        public IActionResult OnGet()
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }

            TblEmployeeRequestJob = _context.TblEmployeeRequestJobs.ToList();
            TblEmployeeRequestLanguageType = _context.TblEmployeeRequestLanguageTypes.ToList();
            TblEmployeeRequestMilitary = _context.TblEmployeeRequestMilitaries.ToList();
            TblEmployeeRequestMilitaryOrganization = _context.TblEmployeeRequestMilitaryOrganizations.ToList();

            return Page();
        }

        public async Task<IActionResult> OnGetSearchAsync()
        {
            return new JsonResult(new { data = await _context.TblEmployeeRequestEmployees.Include(a => a.TblEmployeeRequestPrimaryInformations).Select(a => new { a.FldEmployeeRequestEmployeeId, a.TblEmployeeRequestPrimaryInformations.FirstOrDefault().FldEmployeeRequestPrimaryInformationFirstName, a.TblEmployeeRequestPrimaryInformations.FirstOrDefault().FldEmployeeRequestPrimaryInformationLastName, a.TblEmployeeRequestPrimaryInformations.FirstOrDefault().FldEmployeeRequestPrimaryInformationNationalCode, a.TblEmployeeRequestPrimaryInformations.FirstOrDefault().FldEmployeeRequestPrimaryInformationPhoneNo }).ToListAsync() });
        }

        public async Task<IActionResult> OnGetFilterSearchAsync(bool active_rdate, string rdate, string rdate2,
                                                                bool active_gender, string gender,
                                                                bool active_child, string childNo,
                                                                bool active_marital, string marital,
                                                                bool active_tutelage, string tutelage,
                                                                bool active_birthdate, string birthDate,
                                                                bool active_degree, string degree,
                                                                bool active_degreeField, string degreeField,
                                                                bool active_compile,
                                                                bool active_general,
                                                                bool active_medical,
                                                                bool active_addict,
                                                                bool active_creative,
                                                                bool active_job, string job,
                                                                bool active_language, string language,
                                                                bool active_military, string military,
                                                                bool active_militaryOrg, string militaryOrg,
                                                                bool active_skill, string skill,
                                                                bool active_exp, string exp)
        {
            var result = _context.TblEmployeeRequestEmployees
                .Include(a => a.TblEmployeeRequestPrimaryInformations)
                .Include(a => a.TblCustomerDegrees)
                .Include(a => a.TblEmployeeRequestUserCompilations)
                .Include(a => a.TblEmployeeRequestGeneralRecords)
                .Include(a => a.TblEmployeeRequestMedicalRecords)
                .Include(a => a.TblEmployeeRequestUserCreativities)
                .Include(a => a.TblEmployeeRequestUserJobs)
                .Include(a => a.TblEmployeeRequestUserLanguages)
                .Include(a => a.TblEmployeeRequestUserMilitaries)
                .Include(a => a.TblEmployeeRequestUserSkills)
                .Include(a => a.TblWorkExperiences)
                .Include(a => a.TblEmployeeRequestPageTimeLogs)
                .Where(_ => true);

            #region Based On Primary Informations
            if (active_rdate)
            {
                if (rdate != null && rdate2 != null)
                {
                    result = result.Where(a => a.TblEmployeeRequestPageTimeLogs.FirstOrDefault().FldEmployeeRequestPageTimeLogStartTime >= DateTime.Parse(rdate)
                    && a.TblEmployeeRequestPageTimeLogs.FirstOrDefault().FldEmployeeRequestPageTimeLogStartTime < DateTime.Parse(rdate2)
                    );
                }

                if(rdate != null && rdate2 == null)
                {
                    result = result.Where(a => a.TblEmployeeRequestPageTimeLogs.FirstOrDefault().FldEmployeeRequestPageTimeLogStartTime >= DateTime.Parse(rdate));
                }

                if (rdate == null && rdate2 != null)
                {
                    result = result.Where(a => a.TblEmployeeRequestPageTimeLogs.FirstOrDefault().FldEmployeeRequestPageTimeLogStartTime <= DateTime.Parse(rdate2));
                }
            }

            if (active_gender)
            {
                result = result.Where(a => a.TblEmployeeRequestPrimaryInformations.FirstOrDefault().FldEmployeeRequestPrimaryInformationGender == gender);
            }

            if (active_child)
            {
                result = result.Where(a => a.TblEmployeeRequestPrimaryInformations.FirstOrDefault().FldEmployeeRequestPrimaryInformationChildrenNo == int.Parse(childNo));
            }

            if (active_marital)
            {
                result = result.Where(a => a.TblEmployeeRequestPrimaryInformations.FirstOrDefault().FldEmployeeRequestPrimaryInformationMarital == marital);
            }

            if (active_tutelage)
            {
                result = result.Where(a => a.TblEmployeeRequestPrimaryInformations.FirstOrDefault().FldEmployeeRequestPrimaryInformationTutelage == int.Parse(tutelage));
            }

            if (active_birthdate)
            {
                result = result.Where(a => a.TblEmployeeRequestPrimaryInformations.FirstOrDefault().FldEmployeeRequestPrimaryInformationBirthDate >= DateTime.Parse(birthDate));
            }
            #endregion

            #region Based On Degree
            if (active_degree)
            {
                result = result.Where(a => a.TblCustomerDegrees.Any(a => a.DiplomaId == int.Parse(degree)));
            }

            if (active_degreeField)
            {
                result = result.Where(a => a.TblCustomerDegrees.Any(a => a.FldEducationName.Contains(degreeField)));
            }
            #endregion

            #region Based On Compilations
            if (active_compile)
            {
                result = result.Where(a => a.TblEmployeeRequestUserCompilations.Any(a => a.FldEmployeeRequestUserCompilationTitle != null));
            }
            #endregion

            #region Based On GeneralRecords
            if (active_general)
            {
                result = result.Where(a => a.TblEmployeeRequestGeneralRecords.Any(a => a.FldEmployeeRequestGeneralRecordCriminalTiltle != null));
            }
            #endregion

            #region Based On Medical
            if (active_medical)
            {
                result = result.Where(a => a.TblEmployeeRequestMedicalRecords.All(a => a.FldEmployeeRequestMedicalRecordDisease == null));
            }
            if (active_addict)
            {
                result = result.Where(a => a.TblEmployeeRequestMedicalRecords.All(a => a.FldEmployeeRequestMedicalRecordIsAddict == false));
            }
            #endregion

            #region Based On Creatives
            if (active_creative)
            {
                result = result.Where(a => a.TblEmployeeRequestUserCreativities.Any(a => a.FldEmployeeRequestUserCreativityTitle != null));
            }
            #endregion

            #region Based On Job
            if (active_job)
            {
                result = result.Where(a => a.TblEmployeeRequestUserJobs.Any(a => a.FldEmployeeRequestJobsId == int.Parse(job)));
            }
            #endregion

            #region Based On Language
            if (active_language)
            {
                result = result.Where(a => a.TblEmployeeRequestUserLanguages.Any(a => a.FldEmployeeRequestUserLanguageLanguageTypeId == int.Parse(language)));
            }
            #endregion

            #region Based On Military
            if (active_military)
            {
                result = result.Where(a => a.TblEmployeeRequestUserMilitaries.Any(a => a.FldEmployeeRequestMilitaryId == int.Parse(military)));
            }

            if (active_militaryOrg)
            {
                result = result.Where(a => a.TblEmployeeRequestUserMilitaries.Any(a => a.FldEmployeeRequestMilitaryOrganizationId == int.Parse(militaryOrg)));
            }
            #endregion

            #region Based On Skill
            if (active_skill)
            {
                result = result.Where(a => a.TblEmployeeRequestUserSkills.Any(a => a.FldEmployeeRequestUserSkillSkillTitle.Contains(skill)));
            }
            #endregion

            #region Based On WorkExperience
            if (active_exp)
            {
                result = result.Where(a => a.TblWorkExperiences.Any(a => a.FldJobTitle.Contains(exp)));
            }
            #endregion

            var finalResult = await result.Select(a => new
            {
                a.FldEmployeeRequestEmployeeId,
                a.TblEmployeeRequestPrimaryInformations
                .FirstOrDefault().FldEmployeeRequestPrimaryInformationFirstName,
                a.TblEmployeeRequestPrimaryInformations
                .FirstOrDefault().FldEmployeeRequestPrimaryInformationLastName,
                a.TblEmployeeRequestPrimaryInformations
                .FirstOrDefault().FldEmployeeRequestPrimaryInformationNationalCode,
                a.TblEmployeeRequestPrimaryInformations
                .FirstOrDefault().FldEmployeeRequestPrimaryInformationPhoneNo,
                a.TblEmployeeRequestPageTimeLogs.FirstOrDefault(b => b.FldEmployeeRequestEmployeeId == a.FldEmployeeRequestEmployeeId).FldEmployeeRequestPageTimeLogStartTime,
            }).ToListAsync();

            return new JsonResult(new { data = finalResult });
        }
    }
}