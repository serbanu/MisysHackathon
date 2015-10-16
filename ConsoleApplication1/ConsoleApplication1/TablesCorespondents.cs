using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Contributions
    {
        public string IdB { get; set; }
        public string ShortUser { get; set; }
        public int Suma { get; set; }
        public bool Achitat { get; set; }
    }

    public class User
    {
        public string ShortUser { get; set; }
        public string LongUser { get; set; }
        public string Birthday { get; set; }
        public string Hobbies { get; set; }
    }

    public class User_Friends
    {
        public string ShortUser { get; set; }
        public string Friends { get; set; }
    }

    public class Birthdays
    {
        public string IdB { get; set; }
        public string ShortUser { get; set; }
        public string Bagman { get; set; }
        public string Deadline { get; set; }
        public string Sugestii { get; set; }
    }
}
