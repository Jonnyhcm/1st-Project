using CalendarCli;
using CalendarLib;

IStorage storage = new OnDiskStorage();

void AddGoals (Person person)
{
    while (true)
    {
        Console.WriteLine("what is your goal?");
        var goalName = Console.ReadLine();

        if (string.IsNullOrEmpty(goalName)) { break; }
        var goal = new Goal(goalName);
        person.goals.Add(goal);
    }
}

Console.WriteLine("who are you?");
var personName = Console.ReadLine();
var person = storage.FindPerson(personName);
if (person is null)
{
    person = new Person(personName);
}
AddGoals(person);

var goalstr = string.Join(',', person.goals.Select(g => g.Name));
Console.WriteLine($"you are {person.Name} and your goals are {goalstr}");

storage.SavePerson(person);