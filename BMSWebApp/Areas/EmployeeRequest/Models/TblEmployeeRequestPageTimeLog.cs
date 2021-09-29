using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblEmployeeRequestPageTimeLog
    {
        public long FldEmployeeRequestPageTimeLogId { get; set; }
        public string FldEmployeeRequestPageTimeLogPageLevel { get; set; }
        public string FldEmployeeRequestEmployeeId { get; set; }
        public DateTime? FldEmployeeRequestPageTimeLogStartTime { get; set; }
        public DateTime? FldEmployeeRequestPageTimeLogEndTime { get; set; }

        public virtual TblEmployeeRequestEmployee FldEmployeeRequestEmployee { get; set; }
    }
}
