using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblEmployeeRequestSmsSent
    {
        public long FldEmployeeRequestSmsSentId { get; set; }
        public string FldEmployeeRequestSmsSentPhone { get; set; }
        public DateTime? FldEmployeeRequestSmsSentDate { get; set; }
        public string FldEmployeeRequestSmsSentMessage { get; set; }
    }
}
