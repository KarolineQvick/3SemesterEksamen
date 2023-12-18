using System;
using System.Collections.Generic;

public class HashSetExample
{
    public static void Main()
    {
        HashSet<string> hashSet = new HashSet<string>();

        // Tilføj elementer til hashsettet
        hashSet.Add("jens");
        hashSet.Add("Klaus");
        

        // Udskriv elementerne i hashsettet
        foreach (string element in hashSet)
        {
            Console.Write(element + " ");
        }

        Console.WriteLine();
    }
}
/*
int[] array = { 5, 2, 8, 1, 4 };

HashSet<int> hashSet = new HashSet<int>();
hashSet.AddRange(array);

foreach (int element in hashSet)
{
    Console.Write(element + " ");
}

Console.WriteLine();
*/

/*
List<int> list = new List<int> { 5, 2, 8, 1, 4 };

HashSet<int> hashSet = new HashSet<int>();
hashSet.UnionWith(list);

foreach (int element in hashSet)
{
    Console.Write(element + " ");
}

Console.WriteLine();
*/