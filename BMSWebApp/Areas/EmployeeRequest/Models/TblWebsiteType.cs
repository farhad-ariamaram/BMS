using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblWebsiteType
    {
        public TblWebsiteType()
        {
            TblWebsites = new HashSet<TblWebsite>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TblWebsite> TblWebsites { get; set; }
    }
}
