using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public static class globalClass
    {
        public static int Id { get; set; }
        public static int Age { get; set; }
        public static int HandPreference{ get; set; }

        public static string Email { get; set; }

        public static int Level { get; set; }

        public static DateTime quizStartTime { get; set; }

        public static TimeSpan quizDuration { get; set; }
    }
}
