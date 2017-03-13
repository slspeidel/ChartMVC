using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChartingMVC
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string[] GoalLevels { get; set; }
        public string[] GoalDates { get; set; }
        public string[] NeedDescriptions {get; set; }
        public string StudentWholeName { get; set; }
        public string[] NeedTypeNames { get; set; }
    }
}