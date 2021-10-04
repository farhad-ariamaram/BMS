using System;
using System.Collections.Generic;

#nullable disable

namespace MoldingProjectControlWebApp.Models
{
    public partial class TblSoftwareUsed
    {
        public TblSoftwareUsed()
        {
            TblSoftwareUsedProjectFileTypes = new HashSet<TblSoftwareUsedProjectFileType>();
        }

        public Guid FldSoftwareUsedId { get; set; }
        public string FldSoftwareUsedTxt { get; set; }
        public string FldSoftwareUsedManufacturer { get; set; }

        public virtual ICollection<TblSoftwareUsedProjectFileType> TblSoftwareUsedProjectFileTypes { get; set; }
    }
}
