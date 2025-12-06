using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    public class Alarm:IComparable<Alarm>
    {
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public byte Weekdays { get; set; }
        public string Filename { get; set; }
        public Alarm()
        {

        }
        public Alarm(Alarm other)
        {
            this.Date = other.Date;
            this.Time = other.Time;
            this.Weekdays = other.Weekdays;
            this.Filename = other.Filename;
        }
        public int CompareTo(Alarm other)
        {
            return this.Time.CompareTo(other.Time);
        }
        public void WeekdaysFromArray(int[] days)
        {
            if (days.Length > 7) return;
            for (int i=0; i< days.Length; i++)
            {
                Weekdays |= (byte)(1 << days[i]);
            }
            Console.WriteLine(Weekdays);
        }
        public override string ToString()
        {
            return $"{Date.ToString("yyyy.MM.dd")}-{Time.ToString("hh:mm:ss tt")}-{Weekdays}-{Filename.Split('\\').Last()}";
        }
    }
}
