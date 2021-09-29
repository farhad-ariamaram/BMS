using System;
using System.Collections.Generic;

#nullable disable

namespace TechnicalInfoWebApp.Models
{
    public partial class TblTechnicalInfoDataType
    {
        public TblTechnicalInfoDataType()
        {
            TblTechnicalInfoDataTypesValues = new HashSet<TblTechnicalInfoDataTypesValue>();
            TblTechnicalInfos = new HashSet<TblTechnicalInfo>();
        }

        public Guid FldTechnicalInfoDataTypesId { get; set; }
        public string FldTechnicalInfoDataTypesTxt { get; set; }
        public short FldDataDisplayTypeId { get; set; }
        public int? FldTechnicalInfoDataTypesTextLength { get; set; }
        public decimal? FldTechnicalInfoDataTypesMin { get; set; }
        public decimal? FldTechnicalInfoDataTypesMax { get; set; }
        public short? FldTechnicalInfoDataTypesDecimalLength { get; set; }
        public bool? FldTechnicalInfoDataTypesHasDirection { get; set; }
        public Guid FldParametersId { get; set; }
        public bool FldTechnicalInfoDataTypesHasValues { get; set; }

        public virtual TblDataDisplayType FldDataDisplayType { get; set; }
        public virtual TblParameter FldParameters { get; set; }
        public virtual ICollection<TblTechnicalInfoDataTypesValue> TblTechnicalInfoDataTypesValues { get; set; }
        public virtual ICollection<TblTechnicalInfo> TblTechnicalInfos { get; set; }
    }
}
