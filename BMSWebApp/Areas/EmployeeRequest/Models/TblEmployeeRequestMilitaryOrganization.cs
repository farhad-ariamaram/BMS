using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblEmployeeRequestMilitaryOrganization
    {
        public TblEmployeeRequestMilitaryOrganization()
        {
            TblEmployeeRequestUserMilitaries = new HashSet<TblEmployeeRequestUserMilitary>();
        }

        public int FldEmployeeRequestMilitaryOrganizationId { get; set; }
        public string FldEmployeeRequestMilitaryOrganizationOrganizationName { get; set; }

        public virtual ICollection<TblEmployeeRequestUserMilitary> TblEmployeeRequestUserMilitaries { get; set; }
    }
}
