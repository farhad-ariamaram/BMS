using System;
using System.Collections.Generic;

#nullable disable

namespace GuardWebApp.Models
{
    public partial class Check
    {
        public Check()
        {
            CheckLocations = new HashSet<CheckLocation>();
            LocationDetails = new HashSet<LocationDetail>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CheckLocation> CheckLocations { get; set; }
        public virtual ICollection<LocationDetail> LocationDetails { get; set; }
    }
}
