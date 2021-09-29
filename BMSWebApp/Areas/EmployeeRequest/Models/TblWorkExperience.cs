using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblWorkExperience
    {
        public TblWorkExperience()
        {
            TblWorkExperienceLeaveJobDtls = new HashSet<TblWorkExperienceLeaveJobDtl>();
        }

        public long FldWorkExperienceId { get; set; }
        public string FldCustomerName { get; set; }
        public string FldCompanyName { get; set; }
        public DateTime? FldStartDate { get; set; }
        public DateTime? FldEndDate { get; set; }
        public string FldDescription { get; set; }
        public string FldContactNumberOfCompany { get; set; }
        public string FldContactInnerNumberOfCompany { get; set; }
        public string FldRelatedPeople { get; set; }
        public int? FldTaminJobId { get; set; }
        public string FldJobTitle { get; set; }
        public string FldEarlySalary { get; set; }
        public string FldLateSalary { get; set; }
        public string FldReasonsToLeaveJob { get; set; }
        public int? FldLeaveJobId { get; set; }
        public string FldAmountOfDailyInsurance { get; set; }
        public string FldWorkTime { get; set; }
        public string FldWorkDay { get; set; }
        public string FldUnitName { get; set; }
        public string UserId { get; set; }
        public bool? IsWorking { get; set; }
        public bool HasInsurance { get; set; }
        public string InsuranceNo { get; set; }
        public string WhyWantChangeJob { get; set; }
        public string PreviousJobAchievements { get; set; }
        public string FieldOfWork { get; set; }

        public virtual TblLeaveJob FldLeaveJob { get; set; }
        public virtual TblJobTamin FldTaminJob { get; set; }
        public virtual TblEmployeeRequestEmployee User { get; set; }
        public virtual ICollection<TblWorkExperienceLeaveJobDtl> TblWorkExperienceLeaveJobDtls { get; set; }
    }
}
