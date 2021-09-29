using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblEmployeeRequestIpLog
    {
        public long FldEmployeeRequestIpLogId { get; set; }
        public string FldEmployeeRequestEmployeeId { get; set; }
        public string FldEmployeeRequestIpLogIp { get; set; }
        public DateTime? FldEmployeeRequestIpLogDateTime { get; set; }

        public virtual TblEmployeeRequestEmployee FldEmployeeRequestEmployee { get; set; }
    }
}
