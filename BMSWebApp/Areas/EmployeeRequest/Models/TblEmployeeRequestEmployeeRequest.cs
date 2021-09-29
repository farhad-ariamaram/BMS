using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblEmployeeRequestEmployeeRequest
    {
        public long FldEmployeeRequestEmployeeRequestId { get; set; }
        public long? FldEmployeeRequestUserApplicantId { get; set; }
        public long? FldEmployeeRequestUserAccepterId { get; set; }
        public long? FldEmployeeRequestUserSubmitterId { get; set; }
        public int? FldEmployeeRequestJobTaminId { get; set; }
        public int? FldEmployeeRequestJobOnetId { get; set; }
        public DateTime? FldEmployeeRequestEmployeeRequestStartDate { get; set; }
        public DateTime? FldEmployeeRequestEmployeeRequestEndDate { get; set; }
        public bool FldEmployeeRequestEmployeeRequestIsAccept { get; set; }
        public bool FldEmployeeRequestEmployeeRequestNeedMan { get; set; }
        public bool FldEmployeeRequestEmployeeRequestNeedWoman { get; set; }
        public bool FldEmployeeRequestEmployeeRequestIsTransfered { get; set; }
        public DateTime? FldEmployeeRequestEmployeeRequestTransferDate { get; set; }
        public DateTime? FldEmployeeRequestEmployeeRequestAcceptDate { get; set; }
        public string FldEmployeeRequestEmployeeRequestInternalDescription { get; set; }
        public string FldEmployeeRequestEmployeeRequestPublishDescription { get; set; }
        public string FldEmployeeRequestEmployeeRequestJobDescription { get; set; }
        public int? FldEmployeeRequestJobsId { get; set; }
        public DateTime? FldEmployeeRequestEmployeeRequestApplicationDate { get; set; }
        public int? FldEmployeeRequestJobTitleFromId { get; set; }
        public bool IsPublished { get; set; }

        public virtual TblJob FldEmployeeRequestJobOnet { get; set; }
        public virtual TblJobTamin FldEmployeeRequestJobTamin { get; set; }
        public virtual TblEmployeeRequestJobTitleFrom FldEmployeeRequestJobTitleFrom { get; set; }
        public virtual PayJob FldEmployeeRequestJobs { get; set; }
        public virtual TblEmployeeRequestUser FldEmployeeRequestUserAccepter { get; set; }
        public virtual TblEmployeeRequestUser FldEmployeeRequestUserApplicant { get; set; }
        public virtual TblEmployeeRequestUser FldEmployeeRequestUserSubmitter { get; set; }
    }
}
