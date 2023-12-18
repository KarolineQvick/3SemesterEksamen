using System;

public class InsertionSort
{
    public static void Main()
    {
        string[] array = { "banana", "apple", "pear", "orange", "grape" };

        Console.WriteLine("Usorteret array:");
        PrintArray(array);

        InsertionSortAlgorithm(array);

        Console.WriteLine("Sorteret array:");
        PrintArray(array);
    }

    public static void InsertionSortAlgorithm(string[] array)
    {
        int n = array.Length;

        for (int i = 1; i < n; i++)
        {
            string key = array[i];
            int j = i - 1;

            while (j >= 0 && string.Compare(array[j], key) > 0)
            {
                array[j + 1] = array[j];
                j--;
            }

            array[j + 1] = key;
        }
    }

    public static void PrintArray(string[] array)
    {
        foreach (string element in array)
        {
            Console.Write(element + " ");
        }

        Console.WriteLine();
    }
}
