using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblEmployeeRequestUserJob
    {
        public long FldEmployeeRequestUserJobId { get; set; }
        public string FldEmployeeRequestUserJobTitle { get; set; }
        public string FldEmployeeRequestEmployeeId { get; set; }
        public int? FldEmployeeRequestJobsId { get; set; }
        public string FldEmployeeRequestUserJobDescription { get; set; }
        public string FldEmployeeRequestUserJobRequestMoney { get; set; }
        public string FldEmployeeRequestUserJobWhatKnowAbout { get; set; }

        public virtual TblEmployeeRequestEmployee FldEmployeeRequestEmployee { get; set; }
        public virtual TblEmployeeRequestJob FldEmployeeRequestJobs { get; set; }
    }
}
