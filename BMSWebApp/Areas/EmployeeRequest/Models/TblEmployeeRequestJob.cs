using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblEmployeeRequestJob
    {
        public TblEmployeeRequestJob()
        {
            TblEmployeeRequestUserJobs = new HashSet<TblEmployeeRequestUserJob>();
        }

        public int FldEmployeeRequestJobsId { get; set; }
        public DateTime? FldEmployeeRequestJobsStartDate { get; set; }
        public DateTime? FldEmployeeRequestJobsEndDate { get; set; }
        public bool? FldEmployeeRequestJobsIsActive { get; set; }
        public string FldEmployeeRequestJobsJobTitle { get; set; }
        public bool FldEmployeeRequestJobsNeedMan { get; set; }
        public bool FldEmployeeRequestJobsNeedWoman { get; set; }
        public string FldEmployeeRequestJobsDescription { get; set; }

        public virtual ICollection<TblEmployeeRequestUserJob> TblEmployeeRequestUserJobs { get; set; }
    }
}
