using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblEmployeeRequestSkill
    {
        public TblEmployeeRequestSkill()
        {
            TblEmployeeRequestUserSkills = new HashSet<TblEmployeeRequestUserSkill>();
            Versions = new HashSet<Version>();
        }

        public int FldEmployeeRequestSkillsId { get; set; }
        public string FldEmployeeRequestSkillsSkillTitle { get; set; }
        public string FldEmployeeRequestSkillsSkillEnglishTitle { get; set; }
        public string FldEmployeeRequestSkillsSkillDescription { get; set; }
        public string FldEmployeeRequestSkillsSkillEnglishDescription { get; set; }
        public bool FldEmployeeRequestSkillsSkillActive { get; set; }
        public DateTime? FldEmployeeRequestSkillsSkillStartDate { get; set; }
        public DateTime? FldEmployeeRequestSkillsSkillEndDate { get; set; }

        public virtual ICollection<TblEmployeeRequestUserSkill> TblEmployeeRequestUserSkills { get; set; }
        public virtual ICollection<Version> Versions { get; set; }
    }
}
