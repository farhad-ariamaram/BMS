using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class PayWorkPlace
    {
        public PayWorkPlace()
        {
            InverseWorkPlaceWorkPlaceRefNavigation = new HashSet<PayWorkPlace>();
            PayJobs = new HashSet<PayJob>();
        }

        public int WorkPlaceId { get; set; }
        public int WorkPlaceCompanyRef { get; set; }
        public int? WorkPlaceWorkPlaceRef { get; set; }
        public string WorkPlaceName { get; set; }

        public virtual PayWorkPlace WorkPlaceWorkPlaceRefNavigation { get; set; }
        public virtual ICollection<PayWorkPlace> InverseWorkPlaceWorkPlaceRefNavigation { get; set; }
        public virtual ICollection<PayJob> PayJobs { get; set; }
    }
}
