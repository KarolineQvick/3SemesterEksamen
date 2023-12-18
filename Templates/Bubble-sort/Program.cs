using System;

public class BubbleSort
{
    public static void Main()
    {
        int[] array = { 1, 5, 2, 3, 4, 6, 7, 8, 9, 10 };

     Console.WriteLine("Usorteret array:");
        PrintArray(array);

        BubbleSortAlgorithm(array);

        Console.WriteLine("Sorteret array:");
        PrintArray(array);
    }

    public static void BubbleSortAlgorithm(int[] array)
    {
        int n = array.Length;
        bool swapped;

        // Itererer gennem alle elementer i arrayet
        // Efter hver gennemløb bliver det største tal i den rigtige ende af arrayet
        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;

            // Sammenligner hvert par af tilstødende elementer og bytter dem, hvis de er i forkert rækkefølge
            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    Swap(array, j, j + 1);
                    swapped = true;
                }
            }

            // Hvis der ikke blev foretaget nogen bytter i den indre løkke, er arrayet allerede sorteret
            // Vi kan afslutte sorteringen tidligt
            if (!swapped)
            {
                break;
            }
        }
    }

    public static void Swap(int[] array, int index1, int index2)
    {
        // Bytter placeringen af to elementer i arrayet
        int temp = array[index1];
        array[index1] = array[index2];
        array[index2] = temp;
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

// teori spørgsmål 
//Tidskompleksiteten for Bubble Sort er O(n^2), hvor n er antallet af elementer i arrayet.

//ikke velegnet til store arrays

//Optimized Bubble Sort". I denne tilgang holder man styr på, om der blev foretaget nogen bytter i den sidste gennemløb.
// Hvis der ikke blev foretaget nogen bytter, er arrayet allerede sorteret

// Bubble Sort er en stabil algoritme, da den kun bytter tilstødende elementer, hvis de er i forkert rækkefølge. Det betyder, at hvis der er to ens elementer i arrayet, 
//og det ene kommer før det andet, vil de stadig være i samme rækkefølge efter sortering med Bubble Sort.