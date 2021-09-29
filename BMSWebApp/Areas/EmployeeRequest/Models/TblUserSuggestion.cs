using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblUserSuggestion
    {
        public int Id { get; set; }
        public string Suggestion { get; set; }
        public string UserId { get; set; }

        public virtual TblEmployeeRequestEmployee User { get; set; }
    }
}
