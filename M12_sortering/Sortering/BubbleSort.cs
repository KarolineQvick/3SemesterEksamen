namespace Sortering;

public class BubbleSort
{
    private static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
// Laver sortering på array med Bubble Sort.


    public static void Sort(int[] array)
    {
        for (int i = array.Length - 1; i >= 0; i--)
        {
            for (int j = 0; j <= i - 1; j++)
            {
                // Laver en ombytning, hvis to personer står forkert sorteret
                if (array[j] > array[j + 1])
                {
        
                    Swap(array, j, j + 1);
                }
            }
        }
        return;
    }
}
