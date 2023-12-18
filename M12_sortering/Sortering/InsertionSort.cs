namespace Sortering
{
    public class InsertionSort
    {
        // Metode til at sortere et array ved hjælp af Insertion Sort-algoritmen
        public static void Sort(int[] array)
        {
            // Gennemløb arrayet fra indeks 1 til indeks array.Length - 1
            for (int i = 1; i < array.Length; i++)
            {
                int j = i;
                // Find den korrekte position for det aktuelle element i den delvist sorteret del af arrayet
                while (j > 0 && array[j - 1] > array[j])
                {
                    // Byt elementerne om for at flytte det mindre element til venstre
                    int temp = array[j];
                    array[j] = array[j - 1];
                    array[j - 1] = temp;

                    j--; // Dekrementer j for at fortsætte sammenligningen med tidligere elementer
                }
            }
            // Arrayet er nu sorteret i stigende orden
            return;
        }
    }
}


/*
Du tager det første kort og holder det i din hånd.
Nu kigger du på det næste kort i bunken. Hvis det kort er mindre end det kort, du holder i hånden, sætter du det nye kort først og det gamle kort efter. Ellers lader du det nye kort være, hvor det er.
Nu tager du det næste kort i bunken og gentager trin 2: Hvis kortet er mindre end kortet i din hånd, indsætter du det først og skubber det gamle kort længere til højre. Hvis det ikke er mindre, lader du det være, hvor det er.
Du fortsætter med at gentage trin 2 og 3 for hvert kort i bunken, indtil du har kigget på alle kortene.
Til sidst vil alle kortene være sorteret i rækkefølge fra den mindste til den største værdi.
*/