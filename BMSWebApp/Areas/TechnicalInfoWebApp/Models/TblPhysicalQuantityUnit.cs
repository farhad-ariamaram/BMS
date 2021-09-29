using System;
using System.Collections.Generic;

#nullable disable

namespace TechnicalInfoWebApp.Models
{
    public partial class TblPhysicalQuantityUnit
    {
        public Guid FldPhysicalQuantityUnitsId { get; set; }
        public Guid FldPhysicalQuantityId { get; set; }
        public Guid FldUnitId { get; set; }

        public virtual TblPhysicalQuantity FldPhysicalQuantity { get; set; }
        public virtual TblUnit FldUnit { get; set; }
    }
}
