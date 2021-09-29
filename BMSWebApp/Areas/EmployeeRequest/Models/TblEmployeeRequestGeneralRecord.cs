using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblEmployeeRequestGeneralRecord
    {
        public long FldEmployeeRequestGeneralRecordId { get; set; }
        public string FldEmployeeRequestGeneralRecordCriminalTiltle { get; set; }
        public string FldEmployeeRequestGeneralRecordCriminalDes { get; set; }
        public string FldEmployeeRequestEmployeeId { get; set; }
        public string FldEmployeeRequestGeneralRecordDescription { get; set; }

        public virtual TblEmployeeRequestEmployee FldEmployeeRequestEmployee { get; set; }
    }
}
