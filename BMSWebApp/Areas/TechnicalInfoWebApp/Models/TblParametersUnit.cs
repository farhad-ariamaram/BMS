using System;
using System.Collections.Generic;

#nullable disable

namespace TechnicalInfoWebApp.Models
{
    public partial class TblParametersUnit
    {
        public Guid FldParametersUnitsId { get; set; }
        public Guid FldParametersId { get; set; }
        public Guid FldUnitId { get; set; }

        public virtual TblParameter FldParameters { get; set; }
        public virtual TblUnit FldUnit { get; set; }
    }
}
