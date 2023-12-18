namespace Sortering
{
    public class SelectionSort
    {
        // Metode til at bytte to elementer i arrayet
        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        public static void Sort(int[] array)
        {
            // Loop gennem hvert element i arrayet
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i; // Indeks for det mindste element

                // Find det mindste element i den uordnede del af arrayet
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                // Byt det mindste element med det første element i den uordnede del
                Swap(array, i, minIndex);
            }
        }
    }
}
/*

private static void Swap(int[] array, int i, int j)
{
    // Forestil dig, at du har en kasse med to bolde, en rød og en blå.
    // Du vil gerne bytte rundt på placeringen af disse bolde.
    // For at gøre det, følger du disse trin:

    // Trin 1: Gem værdien af elementet på pladsen 'i' midlertidigt
    int temp = array[i];

    // Trin 2: Overskriv værdien af pladsen 'i' med værdien fra pladsen 'j'
    array[i] = array[j];

    // Trin 3: Placer den midlertidige værdi (gemt fra pladsen 'i') på pladsen 'j'
    array[j] = temp;

    // På den måde har du byttet rundt på værdierne af de to elementer i arrayet.
}
*/