using System;
using System.Collections.Generic;

#nullable disable

namespace TechnicalInfoWebApp.Models
{
    public partial class TblReferenceTechnicalInfoGroup
    {
        public TblReferenceTechnicalInfoGroup()
        {
            TblReferenceValues = new HashSet<TblReferenceValue>();
        }

        public Guid FldReferenceTechnicalInfoGroupId { get; set; }
        public Guid FldTechnicalInfoGroupId { get; set; }
        public short FldReferenceId { get; set; }
        public string FldReferenceTechnicalInfoGroupReferenceId { get; set; }

        public virtual TblReference FldReference { get; set; }
        public virtual TblTechnicalInfoGroup FldTechnicalInfoGroup { get; set; }
        public virtual ICollection<TblReferenceValue> TblReferenceValues { get; set; }
    }
}
