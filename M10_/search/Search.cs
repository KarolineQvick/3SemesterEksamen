namespace SearchMethods
{
    public class Search
    {
        /// <summary>
        /// Finder tallet i arrayet med en lineær søgning.
        /// </summary>
        /// <param name="array">Det array der søges i.</param>
        /// <param name="tal">Det tal der skal findes.</param>
        /// <returns></returns>
        //laver en linær søgning, hvilket betyder den skal gå hele arrayet igennen, så derfor er den O(n) og et for loop
        public static int FindNumberLinear(int[] array, int tal)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == tal)
                {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// Finder tallet i arrayet med en binær søgning.
        /// </summary>
        /// <param name="array">Det array der søges i.</param>
        /// <param name="tal">Det tal der skal findes.</param>
        /// <returns></returns>
        public static int FindNumberBinary(int[] array, int tal)
        {
            //lav en binær søgning 
            //O(log n) fordi den halverer arrayet hver gang den ikke finder tallet
            int min = 0;
            int max = array.Length - 1;

            while (min <= max)
            {
                int mid = (min + max) / 2;

                if (tal == array[mid])
                {
                    // Tallet blev fundet, så returner indekset for tallet
                    return mid;
                }
                else if (tal < array[mid])
                {
                    // Tallet er mindre end midtpunktet, så opdater 'max' til at være venstre for midtpunktet
                    max = mid - 1;
                }
                else if (tal > array[mid])
                {
                    // Tallet er større end midtpunktet, så opdater 'min' til at være højre for midtpunktet
                    min = mid + 1;
                }
            }

            // Tallet blev ikke fundet i arrayet, så returner -1
            return -1;
        }

        private static int[] sortedArray { get; set; } =
            new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
        private static int next = 0;

        /// <summary>
        /// Indsætter et helt array. Arrayet skal være sorteret på forhånd.
        /// </summary>
        /// <param name="sortedArray">Array der skal indsættes.</param>
        /// <param name="next">Den næste ledige plads i arrayet.</param>
        public static void InitSortedArray(int[] sortedArray, int next)
        {
            // Gemmer det sorteret array og den næste ledige plads i den statiske klasse Search
            Search.sortedArray = sortedArray;
            Search.next = next;
        }

        /// <summary>
        /// Indsætter et tal i et sorteret array. En kopi af arrayet returneres.
        /// Arrayet er fortsat sorteret efter det nye tal er indsat.
        /// </summary>
        /// <param name="tal">Tallet der skal indsættes</param>
        /// <returns>En kopi af det sorterede array med det nye tal i.</returns>
        public static int[] InsertSorted(int tal)
        {
            int[] array = sortedArray;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[0] > tal)
                {
                    // Forskyder alle elementer i arrayet en position til højre fra det givne index 'i'
                    for (int j = array.Length - 1; j > i; j--)
                    {
                        array[j] = array[j - 1];
                    }
                    // Indsætter det nye tal i den første position i arrayet
                    array[0] = tal;
                    return array;
                }
                else if (array[i] == -1)
                {
                    // Forskyder alle elementer i arrayet en position til højre fra det givne index 'i'
                    for (int j = array.Length - 1; j >= i; j--)
                    {
                        array[j] = array[j - 1];
                    }
                    // Indsætter det nye tal i den aktuelle position i arrayet
                    array[i] = tal;
                    return array;
                }
                else if (array[i] == array[array.Length - 1])
                {
                    // Returnerer arrayet uændret, da det allerede er fyldt med elementer
                    return array;
                }
                else if (array[i] <= tal && array[i + 1] >= tal)
                {
                    // Forskyder alle elementer i arrayet en position til højre fra det givne index 'i'
                    for (int j = array.Length - 1; j > i; j--)
                    {
                        array[j] = array[j - 1];
                    }
                    // Indsætter det nye tal i den næste position efter 'i' i arrayet
                    array[i + 1] = tal;
                    return array;
                }
            }

            return sortedArray;
        }

    }
}


