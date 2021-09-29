using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblWebsite
    {
        public int Id { get; set; }
        public int? DefinitionId { get; set; }
        public int? WebsiteTypeId { get; set; }
        public int? SubDefinationId { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }

        public virtual TblDefinition Definition { get; set; }
        public virtual TblWebsiteType WebsiteType { get; set; }
    }
}
