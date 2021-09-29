using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblEmployeeRequestUserLanguage
    {
        public long FldEmployeeRequestUserLanguageId { get; set; }
        public string FldEmployeeRequestEmployeeId { get; set; }
        public int? FldEmployeeRequestUserLanguageLanguageTypeId { get; set; }
        public int? FldEmployeeRequestUserLanguageReadingLevel { get; set; }
        public int? FldEmployeeRequestUserLanguageWritingLevel { get; set; }
        public int? FldEmployeeRequestUserLanguageListeningLevel { get; set; }
        public int? FldEmployeeRequestUserLanguageSpeakingLevel { get; set; }
        public string FldEmployeeRequestUserLanguageDescription { get; set; }
        public bool FldEmployeeRequestUserLanguageIsNative { get; set; }

        public virtual TblEmployeeRequestEmployee FldEmployeeRequestEmployee { get; set; }
        public virtual TblEmployeeRequestLanguageType FldEmployeeRequestUserLanguageLanguageType { get; set; }
    }
}
