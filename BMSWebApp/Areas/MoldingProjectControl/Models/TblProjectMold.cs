using System;
using System.Collections.Generic;

#nullable disable

namespace MoldingProjectControlWebApp.Models
{
    public partial class TblProjectMold
    {
        public TblProjectMold()
        {
            TblProjectMoldWorkpieces = new HashSet<TblProjectMoldWorkpiece>();
        }

        public Guid FldProjectMoldId { get; set; }
        public Guid FldProjectId { get; set; }
        public Guid FldMoldId { get; set; }

        public virtual TblMold FldMold { get; set; }
        public virtual TblProject FldProject { get; set; }
        public virtual ICollection<TblProjectMoldWorkpiece> TblProjectMoldWorkpieces { get; set; }
    }
}
