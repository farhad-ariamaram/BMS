using System;
using System.Collections.Generic;

#nullable disable

namespace MoldingProjectControlWebApp.Models
{
    public partial class TblProjectFileType
    {
        public TblProjectFileType()
        {
            TblProjectFiles = new HashSet<TblProjectFile>();
            TblSoftwareUsedProjectFileTypes = new HashSet<TblSoftwareUsedProjectFileType>();
        }

        public Guid FldProjectFileTypeId { get; set; }
        public string FldProjectFileTypeTxt { get; set; }

        public virtual ICollection<TblProjectFile> TblProjectFiles { get; set; }
        public virtual ICollection<TblSoftwareUsedProjectFileType> TblSoftwareUsedProjectFileTypes { get; set; }
    }
}
