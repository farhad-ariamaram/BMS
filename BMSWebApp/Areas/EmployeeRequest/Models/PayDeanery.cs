using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class PayDeanery
    {
        public PayDeanery()
        {
            PayJobs = new HashSet<PayJob>();
        }

        public int DeaneryId { get; set; }
        public int DeaneryCompanyRef { get; set; }
        public string DeaneryName { get; set; }

        public virtual ICollection<PayJob> PayJobs { get; set; }
    }
}
