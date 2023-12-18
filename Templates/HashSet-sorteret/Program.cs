using System;
using System.Collections.Generic;

public class HashSetExample
{
    public static void Main()
    {
        HashSet<int> hashSet = new HashSet<int>();

        // Tilføj elementer til hashsettet
        hashSet.Add(5);
        hashSet.Add(2);
        hashSet.Add(8);
        hashSet.Add(1);
        hashSet.Add(4);
        hashSet.Add(2); // Ignoreres, da det allerede findes i sættet

        // Udskriv elementerne i hashsettet
        foreach (int element in hashSet)
        {
            Console.Write(element + " ");
        }

        Console.WriteLine();
    }
}
