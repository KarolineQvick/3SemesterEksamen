namespace Sortering
{
    public static class QuickSort
    {
        // Metode til at bytte to elementer i arrayet
        private static void Swap(int[] array, int k, int j)
        {
            int tmp = array[k];
            array[k] = array[j];
            array[j] = tmp;
        }

        // Metode til partitionering af arrayet
        private static int Partition(int[] array, int low, int high)
        {
            // Vælg en pivotværdi (f.eks. den midterste værdi)
            int pivot = array[(low + high) / 2];

            int i = low - 1; // Indeks for venstre del (elementer mindre end pivot)
            int j = high + 1; // Indeks for højre del (elementer større end pivot)

            while (true)
            {
                // Find et element i venstre del, der er større end eller lig med pivotværdien
                do
                {
                    i++;
                } while (array[i] < pivot);

                // Find et element i højre del, der er mindre end eller lig med pivotværdien
                do
                {
                    j--;
                } while (array[j] > pivot);

                // Hvis i og j krydser hinanden, er partitioneringen færdig
                if (i >= j)
                {
                    return j;
                }

                // Byt værdierne for elementerne på position i og j
                Swap(array, i, j);
            }
        }

        // Rekursiv metode til QuickSort-algoritmen
        private static void _quickSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                // Udfør partitionering og få pivotindeks
                int pivot = Partition(array, low, high);

                // Rekursivt udfør QuickSort på venstre del af partitionen
                _quickSort(array, low, pivot);

                // Rekursivt udfør QuickSort på højre del af partitionen
                _quickSort(array, pivot + 1, high);
            }
        }

        // Offentlig metode til at starte QuickSort-algoritmen
        public static void Sort(int[] array)
        {
            // Kald den rekursive QuickSort-metode med start- og slutindeks
            _quickSort(array, 0, array.Length - 1);
        }
    }
}
