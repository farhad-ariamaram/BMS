using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectManagementWebApp.Models
{
    public partial class TblWorkpiece
    {
        public TblWorkpiece()
        {
            TblMoldWorkpieces = new HashSet<TblMoldWorkpiece>();
            TblProjectFiles = new HashSet<TblProjectFile>();
            TblProjectMoldWorkpieces = new HashSet<TblProjectMoldWorkpiece>();
            TblWorkpieceDtlFldWorkpieceCompositionComponents = new HashSet<TblWorkpieceDtl>();
            TblWorkpieceDtlFldWorkpieces = new HashSet<TblWorkpieceDtl>();
        }

        public Guid FldWorkpieceId { get; set; }
        public string FldWorkpieceTxt { get; set; }
        public bool FldWorkpieceIsCombination { get; set; }

        public virtual ICollection<TblMoldWorkpiece> TblMoldWorkpieces { get; set; }
        public virtual ICollection<TblProjectFile> TblProjectFiles { get; set; }
        public virtual ICollection<TblProjectMoldWorkpiece> TblProjectMoldWorkpieces { get; set; }
        public virtual ICollection<TblWorkpieceDtl> TblWorkpieceDtlFldWorkpieceCompositionComponents { get; set; }
        public virtual ICollection<TblWorkpieceDtl> TblWorkpieceDtlFldWorkpieces { get; set; }
    }
}
