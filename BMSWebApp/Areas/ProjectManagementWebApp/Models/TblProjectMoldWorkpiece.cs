using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectManagementWebApp.Models
{
    public partial class TblProjectMoldWorkpiece
    {
        public TblProjectMoldWorkpiece()
        {
            TblProjectMoldWorkpieceCheckpoints = new HashSet<TblProjectMoldWorkpieceCheckpoint>();
        }

        public Guid FldProjectMoldWorkpieceId { get; set; }
        public Guid FldProjectMoldId { get; set; }
        public Guid FldWorkpieceId { get; set; }
        public decimal FldProjectMoldWorkpieceLength { get; set; }
        public decimal FldProjectMoldWorkpieceWidth { get; set; }
        public decimal FldProjectMoldWorkpieceHeight { get; set; }
        public decimal? FldProjectMoldWorkpieceBasePointX { get; set; }
        public decimal? FldProjectMoldWorkpieceBasePointY { get; set; }
        public decimal? FldProjectMoldWorkpieceBasePointZ { get; set; }

        public virtual TblProjectMold FldProjectMold { get; set; }
        public virtual TblWorkpiece FldWorkpiece { get; set; }
        public virtual ICollection<TblProjectMoldWorkpieceCheckpoint> TblProjectMoldWorkpieceCheckpoints { get; set; }
    }
}
