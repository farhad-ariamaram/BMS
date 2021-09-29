using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRequest.Utilities
{
    public static class Extensions
    {
        public static string toPersianDate(this DateTime? datetime)
        {
            if (datetime==null)
            {
                return "";
            }
            PersianCalendar pc = new PersianCalendar();
            DateTime date = (DateTime)datetime;
            return string.Format("{0}/{1}/{2}", pc.GetYear(date), pc.GetMonth(date), pc.GetDayOfMonth(date));
        }

        public static string toPersianDate(this DateTime datetime)
        {
            PersianCalendar pc = new PersianCalendar();
            DateTime date = (DateTime)datetime;
            return string.Format("{0}/{1}/{2}", pc.GetYear(date), pc.GetMonth(date), pc.GetDayOfMonth(date));
        }

    }
}
