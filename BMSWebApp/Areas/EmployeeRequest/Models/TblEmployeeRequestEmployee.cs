using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblEmployeeRequestEmployee
    {
        public TblEmployeeRequestEmployee()
        {
            TblCustomerDegrees = new HashSet<TblCustomerDegree>();
            TblEmployeeRequestEmergencyCalls = new HashSet<TblEmployeeRequestEmergencyCall>();
            TblEmployeeRequestEmployeeEditLogs = new HashSet<TblEmployeeRequestEmployeeEditLog>();
            TblEmployeeRequestGeneralRecords = new HashSet<TblEmployeeRequestGeneralRecord>();
            TblEmployeeRequestHowFinds = new HashSet<TblEmployeeRequestHowFind>();
            TblEmployeeRequestInterviewSessions = new HashSet<TblEmployeeRequestInterviewSession>();
            TblEmployeeRequestIpLogs = new HashSet<TblEmployeeRequestIpLog>();
            TblEmployeeRequestMedicalRecords = new HashSet<TblEmployeeRequestMedicalRecord>();
            TblEmployeeRequestPageTimeLogs = new HashSet<TblEmployeeRequestPageTimeLog>();
            TblEmployeeRequestPrimaryInformations = new HashSet<TblEmployeeRequestPrimaryInformation>();
            TblEmployeeRequestUserCompilations = new HashSet<TblEmployeeRequestUserCompilation>();
            TblEmployeeRequestUserCreativities = new HashSet<TblEmployeeRequestUserCreativity>();
            TblEmployeeRequestUserJobs = new HashSet<TblEmployeeRequestUserJob>();
            TblEmployeeRequestUserLanguages = new HashSet<TblEmployeeRequestUserLanguage>();
            TblEmployeeRequestUserMilitaries = new HashSet<TblEmployeeRequestUserMilitary>();
            TblEmployeeRequestUserSkills = new HashSet<TblEmployeeRequestUserSkill>();
            TblUserSuggestions = new HashSet<TblUserSuggestion>();
            TblWorkExperiences = new HashSet<TblWorkExperience>();
        }

        public string FldEmployeeRequestEmployeeId { get; set; }
        public string FldEmployeeRequestEmployeeUsername { get; set; }
        public string FldEmployeeRequestEmployeePassword { get; set; }
        public string FldEmployeeRequestEmployeeCurrentLevel { get; set; }
        public long? FldEmployeeRequestPagesSequenceId { get; set; }
        public int FldEmployeeRequestEmployeeResultPoint { get; set; }
        public int? FldEmployeeRequestEmployeeMaxPoint { get; set; }
        public DateTime? FldEmployeeRequestEmployeeInterviewEndDate { get; set; }
        public DateTime? FldEmployeeRequestEmployeeInterviewStartDate { get; set; }
        public int? FldEmployeeRequestFinalAcceptionId { get; set; }
        public int? FldEmployeeRequestPrimaryAcceptionId { get; set; }
        public DateTime? FldEmployeeRequestEmployeePrimaryAcceptionDate { get; set; }
        public DateTime? FldEmployeeRequestEmployeeFinalAcceptionDate { get; set; }
        public long? FldEmployeeRequestUserPrimaryAccepterId { get; set; }
        public long? FldEmployeeRequestUserFinalAccepterId { get; set; }
        public string FldEmployeeRequestEmployeeFinalAcceptDescription { get; set; }
        public string FldEmployeeRequestEmployeeFinalRejectDescription { get; set; }
        public string FldEmployeeRequestEmployeePrimaryAcceptDescription { get; set; }
        public string FldEmployeeRequestEmployeePrimaryRejectDescription { get; set; }
        public string FldEmployeeRequestEmployeeRejectFromUserDescription { get; set; }
        public DateTime? TransferedDate { get; set; }
        public bool? IsDelete { get; set; }
        public string DeleteDescription { get; set; }

        public virtual TblEmployeeRequestFinalAcception FldEmployeeRequestFinalAcception { get; set; }
        public virtual TblEmployeeRequestPagesSequence FldEmployeeRequestPagesSequence { get; set; }
        public virtual TblEmployeeRequestPrimaryAcception FldEmployeeRequestPrimaryAcception { get; set; }
        public virtual TblEmployeeRequestUser FldEmployeeRequestUserFinalAccepter { get; set; }
        public virtual TblEmployeeRequestUser FldEmployeeRequestUserPrimaryAccepter { get; set; }
        public virtual ICollection<TblCustomerDegree> TblCustomerDegrees { get; set; }
        public virtual ICollection<TblEmployeeRequestEmergencyCall> TblEmployeeRequestEmergencyCalls { get; set; }
        public virtual ICollection<TblEmployeeRequestEmployeeEditLog> TblEmployeeRequestEmployeeEditLogs { get; set; }
        public virtual ICollection<TblEmployeeRequestGeneralRecord> TblEmployeeRequestGeneralRecords { get; set; }
        public virtual ICollection<TblEmployeeRequestHowFind> TblEmployeeRequestHowFinds { get; set; }
        public virtual ICollection<TblEmployeeRequestInterviewSession> TblEmployeeRequestInterviewSessions { get; set; }
        public virtual ICollection<TblEmployeeRequestIpLog> TblEmployeeRequestIpLogs { get; set; }
        public virtual ICollection<TblEmployeeRequestMedicalRecord> TblEmployeeRequestMedicalRecords { get; set; }
        public virtual ICollection<TblEmployeeRequestPageTimeLog> TblEmployeeRequestPageTimeLogs { get; set; }
        public virtual ICollection<TblEmployeeRequestPrimaryInformation> TblEmployeeRequestPrimaryInformations { get; set; }
        public virtual ICollection<TblEmployeeRequestUserCompilation> TblEmployeeRequestUserCompilations { get; set; }
        public virtual ICollection<TblEmployeeRequestUserCreativity> TblEmployeeRequestUserCreativities { get; set; }
        public virtual ICollection<TblEmployeeRequestUserJob> TblEmployeeRequestUserJobs { get; set; }
        public virtual ICollection<TblEmployeeRequestUserLanguage> TblEmployeeRequestUserLanguages { get; set; }
        public virtual ICollection<TblEmployeeRequestUserMilitary> TblEmployeeRequestUserMilitaries { get; set; }
        public virtual ICollection<TblEmployeeRequestUserSkill> TblEmployeeRequestUserSkills { get; set; }
        public virtual ICollection<TblUserSuggestion> TblUserSuggestions { get; set; }
        public virtual ICollection<TblWorkExperience> TblWorkExperiences { get; set; }
    }
}
