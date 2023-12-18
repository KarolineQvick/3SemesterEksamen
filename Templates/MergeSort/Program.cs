using System;

class MergeSort
{
    static void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] leftArr = new int[n1];
        int[] rightArr = new int[n2];

        // Kopier elementerne til midten af venstre og højre array
        for (int i = 0; i < n1; ++i)
            leftArr[i] = arr[left + i];
        for (int j = 0; j < n2; ++j)
            rightArr[j] = arr[mid + 1 + j];

        // Saml de to arrays tilbage i det oprindelige array i sorteret rækkefølge
        int k = left;
        int p = 0;
        int q = 0;
        while (p < n1 && q < n2)
        {
            if (leftArr[p] <= rightArr[q])
            {
                arr[k] = leftArr[p];
                p++;
            }
            else
            {
                arr[k] = rightArr[q];
                q++;
            }
            k++;
        }

        // Kopier de resterende elementer fra venstre array, hvis der er nogen tilbage
        while (p < n1)
        {
            arr[k] = leftArr[p];
            p++;
            k++;
        }

        // Kopier de resterende elementer fra højre array, hvis der er nogen tilbage
        while (q < n2)
        {
            arr[k] = rightArr[q];
            q++;
            k++;
        }
    }

    static void Sort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;

            // Opdel og sortér venstre halvdel
            Sort(arr, left, mid);

            // Opdel og sortér højre halvdel
            Sort(arr, mid + 1, right);

            // Saml de to sorterende halvdele
            Merge(arr, left, mid, right);
        }
    }

    static void Main()
    {
        int[] arr = { 12, 11, 13, 5, 6, 7 };
        Console.WriteLine("Oprindelig liste:");
        PrintArray(arr);

        // Udfør Merge Sort
        Sort(arr, 0, arr.Length - 1);

        Console.WriteLine("\nSorteret liste:");
        PrintArray(arr);
    }

    static void PrintArray(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n; ++i)
            Console.Write(arr[i] + " ");
        Console.WriteLine();
    }
}
