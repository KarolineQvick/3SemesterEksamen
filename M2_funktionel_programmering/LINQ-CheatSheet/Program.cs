using System;
using System.Linq;
using System.Collections.Generic;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
        List<Person> people = new List<Person>
        {
            new Person { Name = "Alice", Age = 25 },
            new Person { Name = "Bob", Age = 30 },
            new Person { Name = "Charlie", Age = 35 },
            new Person { Name = "David", Age = 40 },
            new Person { Name = "Eve", Age = 45 }
        };

        // Where: Filtrer personer over en bestemt alder
        var filteredPeople = people.Where(person => person.Age >= 30);
        Console.WriteLine("Filtered People:");
        foreach (var person in filteredPeople)
        {
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
        }
        Console.WriteLine();

        // Select: Transformér personnavne til store bogstaver
        var upperCaseNames = people.Select(person => person.Name.ToUpper());
        Console.WriteLine("Upper Case Names:");
        foreach (var name in upperCaseNames)
        {
            Console.WriteLine(name);
        }
        Console.WriteLine();

        // OrderBy: Sortér personer efter alder i stigende rækkefølge
        var sortedPeople = people.OrderBy(person => person.Age);
        Console.WriteLine("Sorted People by Age:");
        foreach (var person in sortedPeople)
        {
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
        }
        Console.WriteLine();

        // First: Returnér den første person med en alder over 30
        var firstPerson = people.First(person => person.Age > 30);
        Console.WriteLine($"First Person over 30: Name: {firstPerson.Name}, Age: {firstPerson.Age}");
        Console.WriteLine();

        // Any: Tjek om der er mindst én person under 20 år
        bool anyUnder20 = people.Any(person => person.Age < 20);
        Console.WriteLine($"Any Person under 20: {anyUnder20}");
        Console.WriteLine();

        // Count: Tæl antallet af personer mellem 30 og 40 år
        int countBetween30And40 = people.Count(person => person.Age >= 30 && person.Age <= 40);
        Console.WriteLine($"Count of People between 30 and 40: {countBetween30And40}");
        Console.WriteLine();

        // Sum: Summer alderen for alle personer
        int totalAge = people.Sum(person => person.Age);
        Console.WriteLine($"Total Age of People: {totalAge}");
        Console.WriteLine();

        // Max: Find den ældste person
        var oldestPerson = people.MaxBy(person => person.Age);
        Console.WriteLine($"Oldest Person: Name: {oldestPerson.Name}, Age: {oldestPerson.Age}");
        Console.WriteLine();

        // Distinct: Fjern duplikerede aldre fra listen
        var uniqueAges = people.Select(person => person.Age).Distinct();
        Console.WriteLine("Unique Ages:");
        foreach (var age in uniqueAges)
        {
            Console.WriteLine(age);
        }
        Console.WriteLine();
    }
}
