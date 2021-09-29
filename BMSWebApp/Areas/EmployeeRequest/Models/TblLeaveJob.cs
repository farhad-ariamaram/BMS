using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblLeaveJob
    {
        public TblLeaveJob()
        {
            TblWorkExperienceLeaveJobDtls = new HashSet<TblWorkExperienceLeaveJobDtl>();
            TblWorkExperiences = new HashSet<TblWorkExperience>();
        }

        public int FldLeaveJobId { get; set; }
        public string FldLeaveJobTitle { get; set; }

        public virtual ICollection<TblWorkExperienceLeaveJobDtl> TblWorkExperienceLeaveJobDtls { get; set; }
        public virtual ICollection<TblWorkExperience> TblWorkExperiences { get; set; }
    }
}
