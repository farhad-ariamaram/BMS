using System;
using System.Collections.Generic;

#nullable disable

namespace TechnicalInfoWebApp.Models
{
    public partial class TblTypeOfPhysicalQuantity
    {
        public TblTypeOfPhysicalQuantity()
        {
            TblPhysicalQuantities = new HashSet<TblPhysicalQuantity>();
        }

        public Guid FldTypeOfPhysicalQuantityId { get; set; }
        public string FldTypeOfPhysicalQuantityTxt { get; set; }

        public virtual ICollection<TblPhysicalQuantity> TblPhysicalQuantities { get; set; }
    }
}
