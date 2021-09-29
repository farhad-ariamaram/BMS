using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblWorkExperienceLeaveJobDtl
    {
        public long FldWorkExperienceLeaveJobDtlId { get; set; }
        public long FldWorkExperienceId { get; set; }
        public int? FldLeaveJobId { get; set; }
        public string FldLeaveJob { get; set; }
        public int FldLeaveJobPercent { get; set; }

        public virtual TblLeaveJob FldLeaveJobNavigation { get; set; }
        public virtual TblWorkExperience FldWorkExperience { get; set; }
    }
}
