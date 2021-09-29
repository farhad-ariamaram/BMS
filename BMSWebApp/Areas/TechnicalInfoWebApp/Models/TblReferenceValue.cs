using System;
using System.Collections.Generic;

#nullable disable

namespace TechnicalInfoWebApp.Models
{
    public partial class TblReferenceValue
    {
        public Guid FldReferenceValuesId { get; set; }
        public Guid FldReferenceTechnicalInfoGroupId { get; set; }
        public Guid FldTechnicalInfoId { get; set; }
        public string FldReferenceValuesValue { get; set; }
        public string FldReferenceValuesDirection { get; set; }

        public virtual TblReferenceTechnicalInfoGroup FldReferenceTechnicalInfoGroup { get; set; }
        public virtual TblTechnicalInfo FldTechnicalInfo { get; set; }
    }
}
