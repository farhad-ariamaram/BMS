using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblEmployeeRequestPrimaryAcception
    {
        public TblEmployeeRequestPrimaryAcception()
        {
            TblEmployeeRequestEmployees = new HashSet<TblEmployeeRequestEmployee>();
            TblEmployeeRequestInterviewSessions = new HashSet<TblEmployeeRequestInterviewSession>();
        }

        public int FldEmployeeRequestPrimaryAcceptionId { get; set; }
        public string FldEmployeeRequestPrimaryAcceptionStatus { get; set; }

        public virtual ICollection<TblEmployeeRequestEmployee> TblEmployeeRequestEmployees { get; set; }
        public virtual ICollection<TblEmployeeRequestInterviewSession> TblEmployeeRequestInterviewSessions { get; set; }
    }
}
