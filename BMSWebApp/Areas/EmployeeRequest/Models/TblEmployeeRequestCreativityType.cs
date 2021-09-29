using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblEmployeeRequestCreativityType
    {
        public TblEmployeeRequestCreativityType()
        {
            TblEmployeeRequestUserCreativities = new HashSet<TblEmployeeRequestUserCreativity>();
        }

        public int FldEmployeeRequestCreativityTypeId { get; set; }
        public string FldEmployeeRequestCreativityTypeCreativityType { get; set; }

        public virtual ICollection<TblEmployeeRequestUserCreativity> TblEmployeeRequestUserCreativities { get; set; }
    }
}
