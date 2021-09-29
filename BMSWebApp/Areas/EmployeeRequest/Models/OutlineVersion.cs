using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class OutlineVersion
    {
        public long Id { get; set; }
        public int? Score { get; set; }
        public bool ActiveScore { get; set; }
        public bool ActiveUser { get; set; }
        public long? VersionId { get; set; }
        public long? OutlineId { get; set; }
        public long? TopicId { get; set; }

        public virtual Outline Outline { get; set; }
        public virtual Topic Topic { get; set; }
        public virtual Version Version { get; set; }
    }
}
