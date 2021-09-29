using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblEmployeeRequestPrimaryInformation
    {
        public long FldEmployeeRequestPrimaryInformationId { get; set; }
        public string FldEmployeeRequestEmployeeId { get; set; }
        public string FldEmployeeRequestPrimaryInformationNationalCode { get; set; }
        public string FldEmployeeRequestPrimaryInformationPhoneNo { get; set; }
        public string FldEmployeeRequestPrimaryInformationFirstName { get; set; }
        public string FldEmployeeRequestPrimaryInformationLastName { get; set; }
        public DateTime? FldEmployeeRequestPrimaryInformationBirthDate { get; set; }
        public string FldEmployeeRequestPrimaryInformationGender { get; set; }
        public int? FldEmployeeRequestPrimaryInformationChildrenNo { get; set; }
        public string FldEmployeeRequestPrimaryInformationMarital { get; set; }
        public int? FldEmployeeRequestPrimaryInformationTutelage { get; set; }
        public string FldEmployeeRequestPrimaryInformationTrackNo { get; set; }
        public string FldEmployeeRequestPrimaryInformationPostalCode { get; set; }
        public string FldEmployeeRequestPrimaryInformationAddress { get; set; }
        public string FldEmployeeRequestPrimaryInformationAddress2 { get; set; }

        public virtual TblEmployeeRequestEmployee FldEmployeeRequestEmployee { get; set; }
    }
}
