using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRequest.Models
{
    public class VersionMD
    {
        [RegularExpression(@"^.{1,50}$", ErrorMessage = "طول فیلد حداکثر 50 کاراکتر میباشد")]
        [Required(ErrorMessage = "فیلد اجباری می‌باشد")]
        public string Version1 { get; set; }

        [RegularExpression(@"^.{1,50}$", ErrorMessage = "طول فیلد حداکثر 50 کاراکتر میباشد")]
        public string PersianVersion { get; set; }

        [RegularExpression(@"^.{1,4000}$", ErrorMessage = "طول فیلد حداکثر 4000 کاراکتر میباشد")]
        public string Description { get; set; }

        [RegularExpression(@"^.{1,4000}$", ErrorMessage = "طول فیلد حداکثر 4000 کاراکتر میباشد")]
        public string EnglishDescription { get; set; }

    }

    [ModelMetadataType(typeof(VersionMD))]
    public partial class Version
    {
    }
}
