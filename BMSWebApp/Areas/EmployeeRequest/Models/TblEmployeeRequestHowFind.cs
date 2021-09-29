using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblEmployeeRequestHowFind
    {
        public long FldEmployeeRequestHowFindId { get; set; }
        public string FldEmployeeRequestHowFindTitle { get; set; }
        public string FldEmployeeRequestHowFindAdditionalDes { get; set; }
        public string FldEmployeeRequestEmployeeId { get; set; }

        public virtual TblEmployeeRequestEmployee FldEmployeeRequestEmployee { get; set; }
    }
}
