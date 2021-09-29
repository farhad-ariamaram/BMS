using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRequest.Models
{
    public class TblEmployeeRequestEmployeeRequestMD
    {
        [Required(ErrorMessage ="تاریخ شروع درج شغل در سیستم نمی‌تواند خالی باشد")]
        public DateTime? FldEmployeeRequestEmployeeRequestStartDate { get; set; }

        [Required(ErrorMessage = "تاریخ خاتمه درج شغل در سیستم نمی‌تواند خالی باشد")]
        public DateTime? FldEmployeeRequestEmployeeRequestEndDate { get; set; }

        [StringLength(1000, ErrorMessage = "طول توضیحات حداکثر 1000 کاراکتر می‌باشد")]
        public string FldEmployeeRequestEmployeeRequestInternalDescription { get; set; }

        [StringLength(1000, ErrorMessage = "طول توضیحات حداکثر 1000 کاراکتر می‌باشد")]
        public string FldEmployeeRequestEmployeeRequestPublishDescription { get; set; }

        [StringLength(1000, ErrorMessage = "طول توضیحات حداکثر 1000 کاراکتر می‌باشد")]
        public string FldEmployeeRequestEmployeeRequestJobDescription { get; set; }
    }

    [ModelMetadataType(typeof(TblEmployeeRequestEmployeeRequestMD))]
    public partial class TblEmployeeRequestEmployeeRequest
    {
    }
}
