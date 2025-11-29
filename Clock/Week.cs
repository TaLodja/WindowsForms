using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    internal class Week
    {
        public static readonly string[] weekdays = new string[] { "Пн", "Вт", "Ср", "Чт", "Пт", "Сб", "Вс" };
        byte week;
        public Week(bool[] days)
        {
            CompressWeekDays(days);
        }
        public void CompressWeekDays(bool[] days)
        {
            for (int i = 0; i < days.Length; i++)
            {
                int day = 1;
                if (days[i]) week &= (byte)(day << i);
            }
        }
        public override string ToString()
        {
            string weekdays = "";
            for (int i = 0; i < weekdays.Length; i++)
            {
                int day = 1;
                if ((day << i & week) == (byte)1) weekdays += weekdays[i];
            }
            return weekdays;
        }
    }
}
