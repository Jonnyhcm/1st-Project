using CalendarLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarCli
{
    internal class OnDiskStorage : IStorage
    {
        private static readonly string BaseDir = "C:\\jz";
        
        public void DeletePerson(Person person)
        {
            string fileName = GetFileName(person.Name);

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

        public Person? FindPerson(string name)
        {
            string fileName = GetFileName(name);
            if (File.Exists(fileName))
            {
                var lines = File.ReadAllLines(fileName);
                var result = new Person(name);
                foreach (var line in lines)
                {
                    result.goals.Add(new Goal(line));
                }
                return result;
            }
            return null;
        }

        public void SavePerson(Person person)
        {
            string fileName = GetFileName(person.Name);
            
            string content = string.Join('\n', person.goals.Select(g  => g.Name));
            Directory.CreateDirectory(BaseDir);
            File.WriteAllText(fileName, content);
        }

        private string GetFileName(string name) {
            string fileName = Path.Combine(BaseDir, name);
            fileName += ".txt";
            return fileName;
        }
    }
}
