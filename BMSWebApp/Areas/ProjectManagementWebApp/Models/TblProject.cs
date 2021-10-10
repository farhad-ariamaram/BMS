using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectManagementWebApp.Models
{
    public partial class TblProject
    {
        public TblProject()
        {
            TblImplementationSteps = new HashSet<TblImplementationStep>();
            TblProjectFiles = new HashSet<TblProjectFile>();
            TblProjectMolds = new HashSet<TblProjectMold>();
        }

        public Guid FldProjectId { get; set; }
        public short FldProjectTypeId { get; set; }
        public string FldProjectTxt { get; set; }
        public DateTime? FldProjectDeadlineForCompletion { get; set; }
        public int FldProjectRegistrarId { get; set; }
        public DateTime FldProjectRegistrarDate { get; set; }
        public int? FldProjectExecutorId { get; set; }
        public DateTime? FldProjectExecutorDate { get; set; }
        public int? FldProjectVerifierId { get; set; }
        public DateTime? FldProjectVerifierDate { get; set; }

        public virtual TblProjectType FldProjectType { get; set; }
        public virtual ICollection<TblImplementationStep> TblImplementationSteps { get; set; }
        public virtual ICollection<TblProjectFile> TblProjectFiles { get; set; }
        public virtual ICollection<TblProjectMold> TblProjectMolds { get; set; }
    }
}
