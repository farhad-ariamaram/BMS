using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectManagementWebApp.Models
{
    public partial class TblProjectType
    {
        public TblProjectType()
        {
            TblProjects = new HashSet<TblProject>();
        }

        public short FldProjectTypeId { get; set; }
        public string FldProjectTypeTxt { get; set; }

        public virtual ICollection<TblProject> TblProjects { get; set; }
    }
}
