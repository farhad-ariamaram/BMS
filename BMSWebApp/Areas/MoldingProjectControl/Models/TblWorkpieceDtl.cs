using System;
using System.Collections.Generic;

#nullable disable

namespace MoldingProjectControlWebApp.Models
{
    public partial class TblWorkpieceDtl
    {
        public Guid FldWorkpieceDtlId { get; set; }
        public Guid FldWorkpieceId { get; set; }
        public Guid FldWorkpieceCompositionComponentsId { get; set; }

        public virtual TblWorkpiece FldWorkpiece { get; set; }
        public virtual TblWorkpiece FldWorkpieceCompositionComponents { get; set; }
    }
}
