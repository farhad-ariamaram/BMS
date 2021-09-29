using System;
using System.Collections.Generic;

#nullable disable

namespace TechnicalInfoWebApp.Models
{
    public partial class TblPhysicalQuantity
    {
        public TblPhysicalQuantity()
        {
            TblParameters = new HashSet<TblParameter>();
            TblPhysicalQuantityUnits = new HashSet<TblPhysicalQuantityUnit>();
        }

        public Guid FldPhysicalQuantityId { get; set; }
        public Guid FldTypeOfPhysicalQuantityId { get; set; }
        public string FldPhysicalQuantityTxt { get; set; }
        public decimal? FldPhysicalQuantityMin { get; set; }
        public decimal? FldPhysicalQuantityMax { get; set; }
        public bool FldPhysicalQuantityHasDirection { get; set; }

        public virtual TblTypeOfPhysicalQuantity FldTypeOfPhysicalQuantity { get; set; }
        public virtual ICollection<TblParameter> TblParameters { get; set; }
        public virtual ICollection<TblPhysicalQuantityUnit> TblPhysicalQuantityUnits { get; set; }
    }
}
