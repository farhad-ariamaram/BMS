using System;
using System.Collections.Generic;

#nullable disable

namespace LoggerWebApp.Models
{
    public partial class TblIlogDbType
    {
        public TblIlogDbType()
        {
            TblIlogDbIps = new HashSet<TblIlogDbIp>();
        }

        public int FldIlogDbTypeId { get; set; }
        public string FldIlogDbTypeTitle { get; set; }

        public virtual ICollection<TblIlogDbIp> TblIlogDbIps { get; set; }
    }
}
