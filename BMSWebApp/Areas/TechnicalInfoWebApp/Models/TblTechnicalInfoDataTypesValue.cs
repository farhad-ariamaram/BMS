using System;
using System.Collections.Generic;

#nullable disable

namespace TechnicalInfoWebApp.Models
{
    public partial class TblTechnicalInfoDataTypesValue
    {
        public Guid FldTechnicalInfoDataTypesValuesId { get; set; }
        public Guid FldTechnicalInfoDataTypesId { get; set; }
        public string FldTechnicalInfoDataTypesValuesTxt { get; set; }

        public virtual TblTechnicalInfoDataType FldTechnicalInfoDataTypes { get; set; }
    }
}
