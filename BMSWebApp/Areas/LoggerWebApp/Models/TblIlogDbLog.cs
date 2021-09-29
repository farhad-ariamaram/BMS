using System;
using System.Collections.Generic;

#nullable disable

namespace LoggerWebApp.Models
{
    public partial class TblIlogDbLog
    {
        public long FldIlogDbLogId { get; set; }
        public DateTime FldIlogDbLogDateTime { get; set; }
        public int FldIlogDbIpId { get; set; }

        public virtual TblIlogDbIp FldIlogDbIp { get; set; }
    }
}
