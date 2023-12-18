using System;

public class InsertionSort
{
    public static void Main()
    {
        int[] array = { 1, 5, 2, 3, 4, 6, 7, 8, 9, 10 };

        

        Console.WriteLine("Usorteret array:");
        PrintArray(array);

        InsertionSortAlgorithm(array);

        Console.WriteLine("Sorteret array:");
        PrintArray(array);
    }
    //Key er det element der bliver sammenlignet med de andre elementer i arrayet

    public static void InsertionSortAlgorithm(int[] array)
    {
        int n = array.Length;

        // Gennemløber arrayet fra andet element til det sidste element
        for (int i = 1; i < n; i++)
        {
            int key = array[i];
            int j = i - 1;

            // Flytter elementer større end key til højre for key
            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j--;
            }

            // Indsætter key på den rigtige position
            array[j + 1] = key;
        }
    }

    public static void PrintArray(int[] array)
    {
        // Udskriver elementerne i arrayet
        foreach (int element in array)
        {
            Console.Write(element + " ");
        }

        Console.WriteLine();
    }
}
