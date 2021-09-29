using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblEmployeeRequestMedicalRecord
    {
        public long FldEmployeeRequestMedicalRecordId { get; set; }
        public bool FldEmployeeRequestMedicalRecordHasProblem { get; set; }
        public string FldEmployeeRequestMedicalRecordProblemDes { get; set; }
        public bool FldEmployeeRequestMedicalRecordIsAddict { get; set; }
        public string FldEmployeeRequestMedicalRecordDescription { get; set; }
        public string FldEmployeeRequestEmployeeId { get; set; }
        public string FldEmployeeRequestMedicalRecordDisease { get; set; }
        public DateTime? FldEmployeeRequestMedicalRecordStartDate { get; set; }
        public DateTime? FldEmployeeRequestMedicalRecordEndDate { get; set; }
        public bool FldEmployeeRequestMedicalRecordHasComplications { get; set; }
        public string FldEmployeeRequestMedicalRecordComplicationsDes { get; set; }

        public virtual TblEmployeeRequestEmployee FldEmployeeRequestEmployee { get; set; }
    }
}
