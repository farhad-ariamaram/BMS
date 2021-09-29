using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class PayJob
    {
        public PayJob()
        {
            TblEmployeeRequestEmployeeRequests = new HashSet<TblEmployeeRequestEmployeeRequest>();
        }

        public int JobsId { get; set; }
        public int JobsCompanyRef { get; set; }
        public int JobsWorkPlaceRef { get; set; }
        public int JobsDeaneryRef { get; set; }
        public string JobsCode { get; set; }
        public string JobsName { get; set; }

        public virtual PayDeanery JobsDeaneryRefNavigation { get; set; }
        public virtual PayWorkPlace JobsWorkPlaceRefNavigation { get; set; }
        public virtual ICollection<TblEmployeeRequestEmployeeRequest> TblEmployeeRequestEmployeeRequests { get; set; }
    }
}
