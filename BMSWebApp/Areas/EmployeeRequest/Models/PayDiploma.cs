using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class PayDiploma
    {
        public PayDiploma()
        {
            TblCustomerDegrees = new HashSet<TblCustomerDegree>();
        }

        public int DiplomaId { get; set; }
        public string DiplomaName { get; set; }
        public int DiplomaCode { get; set; }

        public virtual ICollection<TblCustomerDegree> TblCustomerDegrees { get; set; }
    }
}
