using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarLib
{
    public interface IStorage
    {
        void SavePerson(Person person);
        Person? FindPerson(string name);
        void DeletePerson(Person person);
        
    }
}
