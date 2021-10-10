using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectManagementWebApp.Models
{
    public partial class TblImplementationStep
    {
        public TblImplementationStep()
        {
            TblCommunicationStepFldImplementationSteps = new HashSet<TblCommunicationStep>();
            TblCommunicationStepFldImplementationStepsRelateds = new HashSet<TblCommunicationStep>();
        }

        public Guid FldImplementationStepsId { get; set; }
        public string FldImplementationStepsTxt { get; set; }
        public Guid FldProjectId { get; set; }
        public Guid FldExecutionStrategyId { get; set; }

        public virtual TblExecutionStrategy FldExecutionStrategy { get; set; }
        public virtual TblProject FldProject { get; set; }
        public virtual ICollection<TblCommunicationStep> TblCommunicationStepFldImplementationSteps { get; set; }
        public virtual ICollection<TblCommunicationStep> TblCommunicationStepFldImplementationStepsRelateds { get; set; }
    }
}
