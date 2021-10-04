using System;
using System.Collections.Generic;

#nullable disable

namespace MoldingProjectControlWebApp.Models
{
    public partial class TblProjectMoldWorkpieceCheckpoint
    {
        public Guid FldProjectMoldWorkpieceCheckpointId { get; set; }
        public Guid FldProjectMoldWorkpieceId { get; set; }
        public decimal? FldProjectMoldWorkpieceCheckpointBasePointX { get; set; }
        public decimal? FldProjectMoldWorkpieceCheckpointBasePointY { get; set; }
        public decimal? FldProjectMoldWorkpieceCheckpointBasePointZ { get; set; }

        public virtual TblProjectMoldWorkpiece FldProjectMoldWorkpiece { get; set; }
    }
}
