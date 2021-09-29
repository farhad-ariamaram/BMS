using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblEmployeeRequestLink
    {
        public string FldEmployeeRequestLinkId { get; set; }
        public DateTime? FldEmployeeRequestLinkExpireDate { get; set; }
        public string FldEmployeeRequestLinkPhone { get; set; }
    }
}
