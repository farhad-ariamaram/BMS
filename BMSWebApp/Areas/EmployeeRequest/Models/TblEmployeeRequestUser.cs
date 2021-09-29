using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblEmployeeRequestUser
    {
        public TblEmployeeRequestUser()
        {
            TblEmployeeRequestEmployeeEditLogs = new HashSet<TblEmployeeRequestEmployeeEditLog>();
            TblEmployeeRequestEmployeeFldEmployeeRequestUserFinalAccepters = new HashSet<TblEmployeeRequestEmployee>();
            TblEmployeeRequestEmployeeFldEmployeeRequestUserPrimaryAccepters = new HashSet<TblEmployeeRequestEmployee>();
            TblEmployeeRequestEmployeeRequestFldEmployeeRequestUserAccepters = new HashSet<TblEmployeeRequestEmployeeRequest>();
            TblEmployeeRequestEmployeeRequestFldEmployeeRequestUserApplicants = new HashSet<TblEmployeeRequestEmployeeRequest>();
            TblEmployeeRequestEmployeeRequestFldEmployeeRequestUserSubmitters = new HashSet<TblEmployeeRequestEmployeeRequest>();
            TblEmployeeRequestInterviewSessions = new HashSet<TblEmployeeRequestInterviewSession>();
            TblEmployeeRequestUserSettings = new HashSet<TblEmployeeRequestUserSetting>();
        }

        public long FldEmployeeRequestUserId { get; set; }
        public string FldEmployeeRequestUserUsername { get; set; }
        public string FldEmployeeRequestUserPassword { get; set; }
        public string FldEmployeeRequestUserName { get; set; }

        public virtual ICollection<TblEmployeeRequestEmployeeEditLog> TblEmployeeRequestEmployeeEditLogs { get; set; }
        public virtual ICollection<TblEmployeeRequestEmployee> TblEmployeeRequestEmployeeFldEmployeeRequestUserFinalAccepters { get; set; }
        public virtual ICollection<TblEmployeeRequestEmployee> TblEmployeeRequestEmployeeFldEmployeeRequestUserPrimaryAccepters { get; set; }
        public virtual ICollection<TblEmployeeRequestEmployeeRequest> TblEmployeeRequestEmployeeRequestFldEmployeeRequestUserAccepters { get; set; }
        public virtual ICollection<TblEmployeeRequestEmployeeRequest> TblEmployeeRequestEmployeeRequestFldEmployeeRequestUserApplicants { get; set; }
        public virtual ICollection<TblEmployeeRequestEmployeeRequest> TblEmployeeRequestEmployeeRequestFldEmployeeRequestUserSubmitters { get; set; }
        public virtual ICollection<TblEmployeeRequestInterviewSession> TblEmployeeRequestInterviewSessions { get; set; }
        public virtual ICollection<TblEmployeeRequestUserSetting> TblEmployeeRequestUserSettings { get; set; }
    }
}
