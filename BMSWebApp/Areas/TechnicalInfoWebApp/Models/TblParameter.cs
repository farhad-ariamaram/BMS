using System;
using System.Collections.Generic;

#nullable disable

namespace TechnicalInfoWebApp.Models
{
    public partial class TblParameter
    {
        public TblParameter()
        {
            TblParametersUnits = new HashSet<TblParametersUnit>();
            TblTechnicalInfoDataTypes = new HashSet<TblTechnicalInfoDataType>();
        }

        public Guid FldParametersId { get; set; }
        public Guid FldPhysicalQuantityId { get; set; }
        public string FldParametersText { get; set; }

        public virtual TblPhysicalQuantity FldPhysicalQuantity { get; set; }
        public virtual ICollection<TblParametersUnit> TblParametersUnits { get; set; }
        public virtual ICollection<TblTechnicalInfoDataType> TblTechnicalInfoDataTypes { get; set; }
    }
}
