using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarLib
{
    public class Person
    {
        public string Name { get; }

        public List<Goal> goals { get; } = new List<Goal>();

        public Person(string name) {
            Name = name;

        }
    }
}
