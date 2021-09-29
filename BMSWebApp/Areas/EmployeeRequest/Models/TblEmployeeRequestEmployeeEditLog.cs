using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblEmployeeRequestEmployeeEditLog
    {
        public long FldEmployeeRequestEmployeeEditLogId { get; set; }
        public string FldEmployeeRequestEmployeeId { get; set; }
        public long? FldEmployeeRequestUserId { get; set; }
        public DateTime? FldEmployeeRequestEmployeeEditLogDate { get; set; }
        public string FldEmployeeRequestEmployeeEditLogSection { get; set; }

        public virtual TblEmployeeRequestEmployee FldEmployeeRequestEmployee { get; set; }
        public virtual TblEmployeeRequestUser FldEmployeeRequestUser { get; set; }
    }
}
