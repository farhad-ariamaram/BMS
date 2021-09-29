using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblEmployeeRequestUserMilitary
    {
        public long FldEmployeeRequestUserMilitaryId { get; set; }
        public int? FldEmployeeRequestMilitaryId { get; set; }
        public string FldEmployeeRequestEmployeeId { get; set; }
        public DateTime? FldEmployeeRequestUserMilitaryStartDate { get; set; }
        public DateTime? FldEmployeeRequestUserMilitaryEndDate { get; set; }
        public int? FldEmployeeRequestMilitaryOrganizationId { get; set; }
        public string FldEmployeeRequestUserMilitaryCity { get; set; }
        public string FldEmployeeRequestUserMilitaryUnit { get; set; }
        public string FldEmployeeRequestUserMilitaryExemptDescription { get; set; }
        public string FldEmployeeRequestUserMilitaryDescription { get; set; }

        public virtual TblEmployeeRequestEmployee FldEmployeeRequestEmployee { get; set; }
        public virtual TblEmployeeRequestMilitary FldEmployeeRequestMilitary { get; set; }
        public virtual TblEmployeeRequestMilitaryOrganization FldEmployeeRequestMilitaryOrganization { get; set; }
    }
}
