using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectManagementWebApp.Models
{
    public partial class TblCommunicationStep
    {
        public Guid FldCommunicationStepId { get; set; }
        public short FldTypeOfCommunicationStepId { get; set; }
        public Guid FldImplementationStepsId { get; set; }
        public Guid FldImplementationStepsRelatedId { get; set; }

        public virtual TblImplementationStep FldImplementationSteps { get; set; }
        public virtual TblImplementationStep FldImplementationStepsRelated { get; set; }
        public virtual TblTypeOfCommunicationStep FldTypeOfCommunicationStep { get; set; }
    }
}
