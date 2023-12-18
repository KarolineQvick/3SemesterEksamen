Person[] people = new Person[]
{
    new Person { Name = "Jens Hansen", Age = 45, Phone = "+4512345678" },
    new Person { Name = "Jane Olsen", Age = 22, Phone = "+4543215687" },
    new Person { Name = "Tor Iversen", Age = 35, Phone = "+4587654322" },
    new Person { Name = "Sigurd Nielsen", Age = 31, Phone = "+4512345673" },
    new Person { Name = "Viggo Nielsen", Age = 28, Phone = "+4543217846" },
    new Person { Name = "Rosa Jensen", Age = 23, Phone = "+4543217846" },
};


//Bruger linq function sum til at finde den samlede antal alder
//Opgave 1.1
int Totalage = people.Sum(p => p.Age);
Console.WriteLine($"Den samlede antal alder " + Totalage);

Console.WriteLine("");

//Opgave 1.2
//Bruger linq count og contains til at finde hvor mange der hedder Nielsen
int TotalNielsen = people.Count(p => p.Name.Contains("Nielsen"));
Console.WriteLine($"hvor mange der hedder Nielsen " + TotalNielsen);

//Opgave 1.2,5 - ekstra opgave
//Bruger linq count og contains til at finde hvor mange der hedder Nielsen og er over 30 år
int TotalNielsen2 = people.Count(p => p.Name.Contains("Nielsen") && p.Age > 30);
Console.WriteLine($"hvor mange der hedder Nielsen og er over 30 år = " + TotalNielsen2);


//Opgave 1.3
//Bruger var fordi det er en string
//Bruger linq function maxby til at finde den ældste person
//
var ÆldestePerson = people.MaxBy(p => p.Age).Name;
Console.WriteLine($"Ældeste person er " + ÆldestePerson + " og er " + people.MaxBy(p => p.Age).Age + " år gammel");


Console.WriteLine("   Opgave 2   ");
Console.WriteLine(" ");

//Opgave 2.1

var FindTelefonnr = people.Where(p => p.Phone.Contains("+4543215687")).Select(p => p.Name).FirstOrDefault();
Console.WriteLine($"Personen  er " + FindTelefonnr + " og har telefonnummer " + people.Where(p => p.Phone.Contains("+4543215687")).Select(p => p.Phone).FirstOrDefault());

//Opgave 2.2
var AlleOver30 = people.Where(p => p.Age > 30).Select(p => p.Name).ToList();

foreach (var item in AlleOver30)
{
    Console.WriteLine(item);
}

//Kan også gøres på den her måde, men ikke ligeså pænt
//Console.WriteLine($"Alle over 30 er " + AlleOver30[0] + ", " + AlleOver30[1] + " og " + AlleOver30[2]);


//opgave 2.3

/*Lav et nyt array med de samme personer, men hvor “+45” er fjernet fra alle telefonnumre. */
var PeopleNew = people.Select(p => new Person 
{
    Name = p.Name,
    Age = p.Age,
    Phone = p.Phone.Replace("+45", "")
});
foreach (Person personerne in PeopleNew)
{
    Console.WriteLine(personerne.Phone);


}
    Console.WriteLine("");
//Opgave 2.4
//Generér en string med navn og telefonnummer på de personer, der er yngre end 30, adskilt med komma

var PeopleUnder30 = people.Where(p => p.Age < 30).Select(p => p.Name + ", " + p.Phone).ToList();
foreach (var item in PeopleUnder30)
{
    Console.WriteLine(item);
}

//opgave 3

// et array
var ord = new string[] { "Liverpool" };


//Et input parameter - det er et array af strings
//højere ordens funktion
var CreateWordFilterFn = (string[] words) =>
{
    return (string str) => // Her returneres den nye funktion (det er det som gør at det er en højere ordens)
    {
        string temp = str;
        foreach (var word in words)
        {
            temp = temp.Replace(word, "Chelsea");
        }
        return temp;
    };
};


//variable som kalder funktionen
var filter = CreateWordFilterFn(ord);

//udskriver funktionen
Console.WriteLine(filter("Liverpool, vinder mesterskabet, solen skinner, kagen er god "));


//OPGAVE 4 BOUBLE SORT /////////////////////////////////////////////////////////////////////

/*
Bubbelsorteringsalgoritmen fungerer ved at sammenligne hvert par af elementer i en liste og bytte dem rundt, hvis de er i den forkerte rækkefølge.
Denne proces gentages, indtil listen er sorteret.
Tidskompleksiteten for denne algoritme er O(n^2), da den skal gennemgå listen og sammenligne hvert par elementer n gange.
 */


//Funktion man gemme i en variable: Bruges til at sortere efter alder. Hvis person1 er ældst = true / positiv tal, hvis person2 er ældst = false/ negativ tal
Func<Person, Person, int> bubbelSortAlder = (person1, person2) => person1.Age - person2.Age;

//Funktion man gemme i en variable: Bruges til at sorter efter alfabetisk rækkefølge
Func<Person, Person, int> bubbelSortAlfabet = (person1, person2) => {
if (person1.Name.CompareTo(person2.Name) > 0) { return 1; }
else
{
return -1;
}
};

//Funktion man gemme i en variable: Bruges til at sorter efter telefon nr med den mindste først. Man laver en int.Parse fordi det er en streng som parses til int for at kunne sammenligne
Func<Person, Person, int> bubbelSortPhone = (person1, person2) => { return int.Parse(person1.Phone.Replace("+45", "")) - int.Parse(person2.Phone.Replace("+45", "")); };


//Sorter efter alder - bruger BubbleSort klassen og tager people som indput samt funktionen bubbelSortAlder
BubbleSort.Sort(people, bubbelSortAlder);
foreach (Person person in people)
{
Console.WriteLine(person.Name + person.Age);
}

//Sorter efter telefon nr. med det mindste først
/*BubbleSort.Sort(people, bubbelSortPhone);
foreach (Person person in people)
{
    Console.WriteLine(person.Name + person.Phone);
}
*/

//Sorter efter alfabet
/*BubbleSort.Sort(people, bubbelSortAlfabet);
foreach (Person person in people)
{
    Console.WriteLine(person.Name + person.Age);
}
*/


//Klassen til BubbleSort som indeholder metoden swap 
public class BubbleSort
{
    // Bytter om på to elementer i et array
    private static void Swap(Person[] array, int i, int j)
    {
        Person temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    // Laver sortering på array med Bubble Sort. 
    // compareFn bruges til at sammeligne to personer med.
    public static void Sort(Person[] array, Func<Person, Person, int> compareFn)
    {
        for (int i = array.Length - 1; i >= 0; i--)
        {
            for (int j = 0; j <= i - 1; j++)
            {
                // Laver en ombytning, hvis to personer står forkert sorteret
                if (compareFn(array[j], array[j + 1]) > 0)
                {
                    Swap(array, j, j + 1);
                }
            }
        }
    }
}


public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Phone { get; set; }
}


