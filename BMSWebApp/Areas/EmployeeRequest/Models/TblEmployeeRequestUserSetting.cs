using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblEmployeeRequestUserSetting
    {
        public long FldEmployeeRequestUserSettingId { get; set; }
        public long? FldEmployeeRequestUserId { get; set; }
        public bool? FldEmployeeRequestUserSettingIsShowGreen { get; set; }
        public bool? FldEmployeeRequestUserSettingIsShowRed { get; set; }
        public bool? FldEmployeeRequestUserSettingIsCollaps { get; set; }
        public int FldEmployeeRequestUserSettingPageSize { get; set; }

        public virtual TblEmployeeRequestUser FldEmployeeRequestUser { get; set; }
    }
}
