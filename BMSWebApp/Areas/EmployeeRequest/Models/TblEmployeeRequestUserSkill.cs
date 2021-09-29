using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblEmployeeRequestUserSkill
    {
        public long FldEmployeeRequestUserSkillId { get; set; }
        public int? FldEmployeeRequestSkillsId { get; set; }
        public string FldEmployeeRequestEmployeeId { get; set; }
        public string FldEmployeeRequestUserSkillSkillTitle { get; set; }
        public string FldEmployeeRequestUserSkillDescription { get; set; }
        public string FldEmployeeRequestUserSkillLocation { get; set; }
        public DateTime? FldEmployeeRequestUserSkillDate { get; set; }
        public string FldEmployeeRequestUserSkillSkillType { get; set; }
        public int? FldEmployeeRequestUserSkillSkillLevel { get; set; }
        public string FldEmployeeRequestUserSkillLicenseNo { get; set; }
        public string FldEmployeeRequestUserSkillLicenseReference { get; set; }
        public bool FldEmployeeRequestUserSkillIsSelfTaught { get; set; }

        public virtual TblEmployeeRequestEmployee FldEmployeeRequestEmployee { get; set; }
        public virtual TblEmployeeRequestSkill FldEmployeeRequestSkills { get; set; }
    }
}
