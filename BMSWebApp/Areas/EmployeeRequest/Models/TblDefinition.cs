using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblDefinition
    {
        public TblDefinition()
        {
            TblWebsites = new HashSet<TblWebsite>();
        }

        public int Id { get; set; }
        public string Definition { get; set; }

        public virtual ICollection<TblWebsite> TblWebsites { get; set; }
    }
}
