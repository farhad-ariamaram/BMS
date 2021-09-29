using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class Outline
    {
        public Outline()
        {
            OutlineVersions = new HashSet<OutlineVersion>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string EnglishTitle { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
        public string EnglishDescription { get; set; }

        public virtual ICollection<OutlineVersion> OutlineVersions { get; set; }
    }
}
