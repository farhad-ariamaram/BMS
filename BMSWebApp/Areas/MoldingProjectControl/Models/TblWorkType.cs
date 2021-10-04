using System;
using System.Collections.Generic;

#nullable disable

namespace MoldingProjectControlWebApp.Models
{
    public partial class TblWorkType
    {
        public TblWorkType()
        {
            TblExecutionStrategies = new HashSet<TblExecutionStrategy>();
        }

        public short FldWorkTypeId { get; set; }
        public string FldWorkTypeTxt { get; set; }

        public virtual ICollection<TblExecutionStrategy> TblExecutionStrategies { get; set; }
    }
}
