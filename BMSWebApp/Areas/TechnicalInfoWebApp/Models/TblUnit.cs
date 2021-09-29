using System;
using System.Collections.Generic;

#nullable disable

namespace TechnicalInfoWebApp.Models
{
    public partial class TblUnit
    {
        public TblUnit()
        {
            TblParametersUnits = new HashSet<TblParametersUnit>();
            TblPhysicalQuantityUnits = new HashSet<TblPhysicalQuantityUnit>();
        }

        public Guid FldUnitId { get; set; }
        public string FldUnitName { get; set; }
        public string FldUnitSimbol { get; set; }
        public string FldUnitDes { get; set; }

        public virtual ICollection<TblParametersUnit> TblParametersUnits { get; set; }
        public virtual ICollection<TblPhysicalQuantityUnit> TblPhysicalQuantityUnits { get; set; }
    }
}
