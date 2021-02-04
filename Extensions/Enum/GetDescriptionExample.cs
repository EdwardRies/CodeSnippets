using System;
using System.ComponentModel;
using HTH.Extensions;

namespace HTH.Extensions.Examples.GetDescription
{  
    /// 
    /// Examples of using the GetDescription extension.
    /// 
    class Program
    {
        static void Main(string[] args)
        {
            var day = 4; // Wed
            dayOfWeek = GetDayOfWeek(day);
            Console.WriteLine(dayOfWeek.GetDescription()); // Returns "Wednesday"

            day = 0; // Unknown
            dayOfWeek = GetDayOfWeek(day);
            Console.WriteLine(dayOfWeek.GetDescription()); // Returns empty string
            
            day = 7; // Sat
            dayOfWeek = GetDayOfWeek(day);
            Console.WriteLine(dayOfWeek.GetDescription()); // Returns "Sat"
        }

        private DayOfWeek GetDayOfWeek(int day)
        {
            return (DayOfWeek)Enum.ToObject(typeof(DayOfWeek), day);
        }

    }
    
    /// 
    /// Example Enum with Description Attributes
    /// 
    public enum DayOfWeek
    {
        [Description("")]
        Unknown = 0,
        [Description("Sunday")]
        Sun = 1,
        [Description("Monday")]
        Mon = 2,
        [Description("Tuesday")]
        Tue = 3,
        [Description("Wednesday")]
        Wed = 4,
        [Description("Thursday")]
        Thu = 5,
        [Description("Friday")]
        Fri = 6,
        Sat = 7
    }
}
