namespace Sortering
{
    public static class MergeSort
    {
        // Metode til at starte MergeSort-algoritmen
        public static void Sort(int[] array)
        {
            _mergeSort(array, 0, array.Length - 1);
        }

        // Hjælpemetode til rekursivt at udføre MergeSort
        private static void _mergeSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                // Find midtpunktet af arrayet
                int mid = (low + high) / 2;

                // Rekursivt udfør MergeSort på den venstre del af arrayet
                _mergeSort(array, low, mid);

                // Rekursivt udfør MergeSort på den højre del af arrayet
                _mergeSort(array, mid + 1, high);

                // Flet de to delvist sorteret dele af arrayet
                Merge(array, low, mid, high);
            }
        }

        // Hjælpemetode til at flette to delvist sorteret dele af arrayet
        private static void Merge(int[] array, int low, int middle, int high)
        {
            int[] temp = new int[array.Length]; // Hjælpearray til midlertidig lagring af værdier under sammenlægningen
            int i = low; // Indeks for den første del
            int j = middle + 1; // Indeks for den anden del
            int k = low; // Indeks for hjælpearrayet og samtidig indeks for det samlede array

            // Sammenlign værdierne i de to delvist sorteret dele og placer dem i den korrekte rækkefølge i hjælpearrayet
            while (i <= middle && j <= high)
            {
                if (array[i] <= array[j])
                {
                    temp[k] = array[i];
                    i++;
                }
                else
                {
                    temp[k] = array[j];
                    j++;
                }
                k++;
            }

            // Kopier de resterende elementer fra den første del til hjælpearrayet, hvis der er nogen tilbage
            while (i <= middle)
            {
                temp[k] = array[i];
                i++;
                k++;
            }

            // Kopier de resterende elementer fra den anden del til hjælpearrayet, hvis der er nogen tilbage
            while (j <= high)
            {
                temp[k] = array[j];
                j++;
                k++;
            }

            // Kopier elementerne fra hjælpearrayet tilbage til det oprindelige array mellem low og high indekserne
            for (k = low; k <= high; k++)
            {
                array[k] = temp[k];
            }
        }
    }
}
