using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblEmployeeRequestSmsReceived
    {
        public long FldEmployeeRequestSmsReceivedId { get; set; }
        public string FldEmployeeRequestSmsReceivedPhone { get; set; }
        public DateTime? FldEmployeeRequestSmsReceivedDate { get; set; }
        public string FldEmployeeRequestSmsReceivedMessage { get; set; }
        public bool? FldEmployeeRequestSmsReceivedIsVisit { get; set; }
    }
}
