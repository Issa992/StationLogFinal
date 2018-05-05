using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationLogFinal.Converter
{
    public class DateTimeConverter
    {
        public static DateTime DTOfset(DateTimeOffset date)
        {
            return new DateTime(date.Year, date.Month, date.Day);
        }
    }
}
