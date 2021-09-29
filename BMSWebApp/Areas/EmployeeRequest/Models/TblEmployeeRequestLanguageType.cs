using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblEmployeeRequestLanguageType
    {
        public TblEmployeeRequestLanguageType()
        {
            TblEmployeeRequestUserLanguages = new HashSet<TblEmployeeRequestUserLanguage>();
        }

        public int FldEmployeeRequestLanguageTypeId { get; set; }
        public string FldEmployeeRequestLanguageTypeLanguageType { get; set; }

        public virtual ICollection<TblEmployeeRequestUserLanguage> TblEmployeeRequestUserLanguages { get; set; }
    }
}
