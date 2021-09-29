using System;
using System.Collections.Generic;

#nullable disable

namespace TechnicalInfoWebApp.Models
{
    public partial class TblTechnicalInfoGroup
    {
        public TblTechnicalInfoGroup()
        {
            TblReferenceTechnicalInfoGroups = new HashSet<TblReferenceTechnicalInfoGroup>();
            TblTechnicalInfos = new HashSet<TblTechnicalInfo>();
        }

        public Guid FldTechnicalInfoGroupId { get; set; }
        public short FldReferenceId { get; set; }
        public string FldTechnicalInfoGroupTxt { get; set; }

        public virtual TblReference FldReference { get; set; }
        public virtual ICollection<TblReferenceTechnicalInfoGroup> TblReferenceTechnicalInfoGroups { get; set; }
        public virtual ICollection<TblTechnicalInfo> TblTechnicalInfos { get; set; }
    }
}
