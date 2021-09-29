using System;
using System.Collections.Generic;

#nullable disable

namespace TechnicalInfoWebApp.Models
{
    public partial class TblTechnicalInfo
    {
        public TblTechnicalInfo()
        {
            TblReferenceValues = new HashSet<TblReferenceValue>();
        }

        public Guid FldTechnicalInfoId { get; set; }
        public string FldTechnicalInfoTxt { get; set; }
        public Guid FldTechnicalInfoGroupId { get; set; }
        public Guid FldTechnicalInfoDataTypesId { get; set; }
        public int? FldTechnicalInfoTextLength { get; set; }
        public decimal? FldTechnicalInfoMin { get; set; }
        public decimal? FldTechnicalInfoMax { get; set; }
        public short? FldTechnicalInfoDecimalLength { get; set; }

        public virtual TblTechnicalInfoDataType FldTechnicalInfoDataTypes { get; set; }
        public virtual TblTechnicalInfoGroup FldTechnicalInfoGroup { get; set; }
        public virtual ICollection<TblReferenceValue> TblReferenceValues { get; set; }
    }
}
