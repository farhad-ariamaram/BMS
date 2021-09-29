using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblEmployeeRequestInterviewSession
    {
        public long FldEmployeeRequestInterviewSessionId { get; set; }
        public long FldEmployeeRequestUserId { get; set; }
        public string FldEmployeeRequestEmployeeId { get; set; }
        public int? FldEmployeeRequestPrimaryAcceptionId { get; set; }
        public int? FldEmployeeRequestInterviewSessionResultPoint { get; set; }
        public int? FldEmployeeRequestInterviewSessionMaxPoint { get; set; }
        public DateTime? FldEmployeeRequestInterviewSessionDate { get; set; }

        public virtual TblEmployeeRequestEmployee FldEmployeeRequestEmployee { get; set; }
        public virtual TblEmployeeRequestPrimaryAcception FldEmployeeRequestPrimaryAcception { get; set; }
        public virtual TblEmployeeRequestUser FldEmployeeRequestUser { get; set; }
    }
}
