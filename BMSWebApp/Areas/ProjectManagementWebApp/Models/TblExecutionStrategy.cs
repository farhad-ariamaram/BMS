using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectManagementWebApp.Models
{
    public partial class TblExecutionStrategy
    {
        public TblExecutionStrategy()
        {
            TblImplementationSteps = new HashSet<TblImplementationStep>();
        }

        public Guid FldExecutionStrategyId { get; set; }
        public string FldExecutionStrategyTxt { get; set; }
        public short FldWorkTypeId { get; set; }

        public virtual TblWorkType FldWorkType { get; set; }
        public virtual ICollection<TblImplementationStep> TblImplementationSteps { get; set; }
    }
}
