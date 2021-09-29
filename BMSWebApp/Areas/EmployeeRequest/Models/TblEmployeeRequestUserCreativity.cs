using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblEmployeeRequestUserCreativity
    {
        public long FldEmployeeRequestUserCreativityId { get; set; }
        public string FldEmployeeRequestUserCreativityTitle { get; set; }
        public int? FldEmployeeRequestCreativityTypeId { get; set; }
        public string FldEmployeeRequestUserCreativityExplanation { get; set; }
        public DateTime? FldEmployeeRequestUserCreativityDate { get; set; }
        public string FldEmployeeRequestUserCreativityDescription { get; set; }
        public string FldEmployeeRequestEmployeeId { get; set; }

        public virtual TblEmployeeRequestCreativityType FldEmployeeRequestCreativityType { get; set; }
        public virtual TblEmployeeRequestEmployee FldEmployeeRequestEmployee { get; set; }
    }
}
