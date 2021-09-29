using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblEmployeeRequestUserCompilation
    {
        public long FldEmployeeRequestUserCompilationId { get; set; }
        public string FldEmployeeRequestEmployeeId { get; set; }
        public int? FldEmployeeRequestCompilationTypeId { get; set; }
        public string FldEmployeeRequestUserCompilationTitle { get; set; }
        public string FldEmployeeRequestUserCompilationExplanation { get; set; }
        public DateTime? FldEmployeeRequestUserCompilationDate { get; set; }
        public string FldEmployeeRequestUserCompilationAuthor { get; set; }
        public string FldEmployeeRequestUserCompilationDescription { get; set; }

        public virtual TblEmployeeRequestCompilationType FldEmployeeRequestCompilationType { get; set; }
        public virtual TblEmployeeRequestEmployee FldEmployeeRequestEmployee { get; set; }
    }
}
