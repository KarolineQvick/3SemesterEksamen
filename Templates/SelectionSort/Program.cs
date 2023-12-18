using System;

public class SelectionSort
{
    public static void Main()
    {
        int[] array = { 1, 5, 2, 3, 4, 6, 7, 10, 9, 8 };

        Console.WriteLine("Usorteret array:");
        PrintArray(array);

        SelectionSortAlgorithm(array);

        Console.WriteLine("Sorteret array:");
        PrintArray(array);
    }

    public static void SelectionSortAlgorithm(int[] array)
    {
        int n = array.Length;

        // Gennemløber arrayet fra start til næstsidste element
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;

            // Finder det mindste element i den resterende usorterede del af arrayet
            for (int j = i + 1; j < n; j++)
            {
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }

            // Bytter det mindste element med det første element i den usorterede del
            Swap(array, i, minIndex);
        }
    }

    public static void Swap(int[] array, int i, int j)
    {
        // Bytter positionen af to elementer i arrayet
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
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
