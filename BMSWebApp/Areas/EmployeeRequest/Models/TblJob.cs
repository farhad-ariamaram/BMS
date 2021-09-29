using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblJob
    {
        public TblJob()
        {
            TblEmployeeRequestEmployeeRequests = new HashSet<TblEmployeeRequestEmployeeRequest>();
        }

        public int FldJobId { get; set; }
        public string FldJobName { get; set; }
        public string FldJobNameEn { get; set; }
        public string FldDes { get; set; }
        public string FldDesEn { get; set; }
        public DateTime? FldStartDate { get; set; }
        public DateTime? FldEndDate { get; set; }
        public bool? FldIsactive { get; set; }
        public string FldDesDeActive { get; set; }
        public string FldOnetId { get; set; }
        public string FldOnetAddress { get; set; }
        public string FldBehinyabId { get; set; }
        public string FldBehinyabAddress { get; set; }
        public int FldTaminJobId { get; set; }
        public int LevelId { get; set; }
        public int JobsId { get; set; }
        public string FldMiniCode { get; set; }

        public virtual ICollection<TblEmployeeRequestEmployeeRequest> TblEmployeeRequestEmployeeRequests { get; set; }
    }
}
