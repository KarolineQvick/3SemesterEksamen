using System;

public class BubbleSort
{
    public static void Main()
    {
        string[] array = { "banana", "apple", "pear", "orange", "grape" };

        Console.WriteLine("Usorteret array:");
        PrintArray(array);

        BubbleSortAlgorithm(array);

        Console.WriteLine("Sorteret array:");
        PrintArray(array);
    }

    public static void BubbleSortAlgorithm(string[] array)
    {
        int n = array.Length;
        bool swapped;

        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;

            for (int j = 0; j < n - i - 1; j++)
            {
                if (string.Compare(array[j], array[j + 1]) > 0)
                {
                    Swap(array, j, j + 1);
                    swapped = true;
                }
            }

            if (!swapped)
            {
                break;
            }
        }
    }

    public static void Swap(string[] array, int index1, int index2)
    {
        string temp = array[index1];
        array[index1] = array[index2];
        array[index2] = temp;
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
