using System;
using System.Collections.Generic;

#nullable disable

namespace MoldingProjectControlWebApp.Models
{
    public partial class TblMold
    {
        public TblMold()
        {
            TblMoldWorkpieces = new HashSet<TblMoldWorkpiece>();
            TblProjectMolds = new HashSet<TblProjectMold>();
        }

        public Guid FldMoldId { get; set; }
        public string FldMoldTxt { get; set; }
        public int FldModelId { get; set; }

        public virtual ICollection<TblMoldWorkpiece> TblMoldWorkpieces { get; set; }
        public virtual ICollection<TblProjectMold> TblProjectMolds { get; set; }
    }
}
