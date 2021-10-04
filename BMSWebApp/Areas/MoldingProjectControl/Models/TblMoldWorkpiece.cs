using System;
using System.Collections.Generic;

#nullable disable

namespace MoldingProjectControlWebApp.Models
{
    public partial class TblMoldWorkpiece
    {
        public Guid FldMoldWorkpieceId { get; set; }
        public Guid FldMoldId { get; set; }
        public Guid FldWorkpieceId { get; set; }

        public virtual TblMold FldMold { get; set; }
        public virtual TblWorkpiece FldWorkpiece { get; set; }
    }
}
