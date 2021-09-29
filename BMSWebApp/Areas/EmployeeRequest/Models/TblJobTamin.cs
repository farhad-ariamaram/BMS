using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblJobTamin
    {
        public TblJobTamin()
        {
            TblEmployeeRequestEmployeeRequests = new HashSet<TblEmployeeRequestEmployeeRequest>();
            TblWorkExperiences = new HashSet<TblWorkExperience>();
        }

        public int FldTaminJobId { get; set; }
        public string FldTaminJobCode { get; set; }
        public string FldTaminJobName { get; set; }
        public bool? FldTaminJobStatus { get; set; }
        public string FldTaminJobStatusDate { get; set; }

        public virtual ICollection<TblEmployeeRequestEmployeeRequest> TblEmployeeRequestEmployeeRequests { get; set; }
        public virtual ICollection<TblWorkExperience> TblWorkExperiences { get; set; }
    }
}
