using System;
using System.Collections.Generic;

#nullable disable

namespace LoggerWebApp.Models
{
    public partial class TblIlogDbIp
    {
        public TblIlogDbIp()
        {
            TblIlogDbLogs = new HashSet<TblIlogDbLog>();
        }

        public int FldIlogDbIpId { get; set; }
        public string FldIlogDbIpTitle { get; set; }
        public string FldIlogDbIpAddress { get; set; }
        public int FldIlogDbLogTypeId { get; set; }

        public virtual TblIlogDbType FldIlogDbLogType { get; set; }
        public virtual ICollection<TblIlogDbLog> TblIlogDbLogs { get; set; }
    }
}
