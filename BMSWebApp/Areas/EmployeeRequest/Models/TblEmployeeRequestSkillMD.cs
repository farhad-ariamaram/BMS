using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRequest.Models
{
    public class TblEmployeeRequestSkillMD
    {
        [RegularExpression(@"^.{1,100}$",ErrorMessage ="طول فیلد حداکثر 100 کاراکتر میباشد")]
        [Required(ErrorMessage = "فیلد اجباری می‌باشد")]
        public string FldEmployeeRequestSkillsSkillTitle { get; set; }

        [RegularExpression(@"^.{1,100}$", ErrorMessage = "طول فیلد حداکثر 100 کاراکتر میباشد")]
        [Required(ErrorMessage = "فیلد اجباری می‌باشد")]
        public string FldEmployeeRequestSkillsSkillEnglishTitle { get; set; }

        [RegularExpression(@"^.{1,4000}$", ErrorMessage = "طول فیلد حداکثر 4000 کاراکتر میباشد")]
        [DataType(DataType.MultilineText)]
        public string FldEmployeeRequestSkillsSkillDescription { get; set; }

        [RegularExpression(@"^.{1,4000}$", ErrorMessage = "طول فیلد حداکثر 4000 کاراکتر میباشد")]
        [DataType(DataType.MultilineText)]
        public string FldEmployeeRequestSkillsSkillEnglishDescription { get; set; }
    }

    [ModelMetadataType(typeof(TblEmployeeRequestSkillMD))]
    public partial class TblEmployeeRequestSkill
    {
    }
}
