using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectManagementWebApp.Models
{
    public partial class TblTypeOfCommunicationStep
    {
        public TblTypeOfCommunicationStep()
        {
            TblCommunicationSteps = new HashSet<TblCommunicationStep>();
        }

        public short FldTypeOfCommunicationStepId { get; set; }
        public string FldTypeOfCommunicationStepTxt { get; set; }

        public virtual ICollection<TblCommunicationStep> TblCommunicationSteps { get; set; }
    }
}
