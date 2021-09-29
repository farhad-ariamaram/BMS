using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRequest.Models
{
    public class TblWebsiteMD
    {
        [Required]
        [RegularExpression(@"^.{1,4000}$", ErrorMessage = "طول فیلد حداکثر 4000 کاراکتر میباشد")]
        public string Website { get; set; }

        [RegularExpression(@"^.{1,4000}$", ErrorMessage = "طول فیلد حداکثر 4000 کاراکتر میباشد")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }

    [ModelMetadataType(typeof(TblWebsiteMD))]
    public partial class TblWebsite
    {
    }
}
