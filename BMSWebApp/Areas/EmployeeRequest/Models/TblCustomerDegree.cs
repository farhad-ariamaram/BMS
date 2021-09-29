using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblCustomerDegree
    {
        public long FldCustomerDegreeId { get; set; }
        public string CustomerName { get; set; }
        public int? DiplomaId { get; set; }
        public int? EducationId { get; set; }
        public string FldEducationName { get; set; }
        public DateTime? FldStartDate { get; set; }
        public DateTime? FldEndDate { get; set; }
        public string FldExportNo { get; set; }
        public DateTime? FldExportDate { get; set; }
        public string FldPoint { get; set; }
        public string FldDes { get; set; }
        public string UserId { get; set; }
        public string FldStudyPlace { get; set; }
        public string FldStudyCity { get; set; }

        public virtual PayDiploma Diploma { get; set; }
        public virtual PayEducation Education { get; set; }
        public virtual TblEmployeeRequestEmployee User { get; set; }
    }
}
