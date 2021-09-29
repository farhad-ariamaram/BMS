using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class Topic
    {
        public Topic()
        {
            OutlineVersions = new HashSet<OutlineVersion>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string EnglishTitle { get; set; }
        public string Description { get; set; }
        public string EnglishDescription { get; set; }
        public bool Active { get; set; }
        public int? Number { get; set; }
        public long? VersionId { get; set; }

        public virtual Version Version { get; set; }
        public virtual ICollection<OutlineVersion> OutlineVersions { get; set; }
    }
}
