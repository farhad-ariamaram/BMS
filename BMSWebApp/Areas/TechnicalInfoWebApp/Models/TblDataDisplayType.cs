using System;
using System.Collections.Generic;

#nullable disable

namespace TechnicalInfoWebApp.Models
{
    public partial class TblDataDisplayType
    {
        public TblDataDisplayType()
        {
            TblTechnicalInfoDataTypes = new HashSet<TblTechnicalInfoDataType>();
        }

        public short FldDataDisplayTypeId { get; set; }
        public string FldDataDisplayTypeTxt { get; set; }

        public virtual ICollection<TblTechnicalInfoDataType> TblTechnicalInfoDataTypes { get; set; }
    }
}
