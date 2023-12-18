
using System;

namespace M1_rekursive_funktioner {


class Program
    {
        static void Main(string[] args)
        {
            int result = opgave3.Faculty(5);
            Console.WriteLine($"Output skal være = " + result);

            int result2 = opgave4.euclid(10, 5);
            Console.WriteLine(result2);

            string result3 = opgave5.Reverse("EGAKNANAB");
             Console.WriteLine(result3);    
             
             
             
            Opgave6.ScanDir(@"/Users/rasmusmeldgaardjensen/desktop/eksamen-2023", 0);
            
            int result4 = Opgave6.ScanDirCount("");  }
    }

class opgave3
{
     //udregner fakulitet rekursivt
    public static int Faculty(int n)
    {
        if (n == 0)
        {
            return 1;
        }
        else
        {
            //rekursivt kald af funktionen Faculty 
            return n * Faculty(n - 1);
        }
    }

}

class opgave4
{
    // Udregner det største fælles divisor ved hjælp af Euklids algoritme
    public static int euclid(int a, int b)
    {
        if (a > b)
        {
            if (a % b == 0)
            {
                return b; // Hvis b er en divisor for a, returneres b som det største fælles divisor
            }
            return euclid(b, a % b); // Rekursivt kald af funktionen euclid med b og resten af divisionen a % b
        }
        if (b > a)
        {
            if (b % a == 0)
            {
                return a; // Hvis a er en divisor for b, returneres a som det største fælles divisor
            }
            return euclid(a, b % a); // Rekursivt kald af funktionen euclid med a og resten af divisionen b % a
        }
        return Math.Min(a, b); // Hvis a og b er lig med hinanden, returneres det mindste tal som det største fælles divisor
    }
}



class opgave5
{
    // Reverserer en given streng rekursivt
    public static string Reverse(string str)
    {
        if (str.Length == 1)
        {
            return str; // Base case: Hvis strengen kun består af ét tegn, returneres strengen uændret
        }
 
        return Reverse(str.Substring(1)) + str[0]; // Rekursivt kald af funktionen Reverse med substrings af strengen for at omvende den
    }
}

}


class Opgave6
{
    public static void ScanDir(string path, int depth)
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        FileInfo[] files = dir.GetFiles();

        string space = new string(' ', depth);

        // Udskriver alle filerne
        foreach (FileInfo file in files)
        {
            Console.WriteLine(space + file.Name);
        }
        DirectoryInfo[] dirs = dir.GetDirectories();

        // Kalder rekursivt på alle undermapper
        foreach (DirectoryInfo subdir in dirs)
        {
            ScanDir(subdir.FullName, depth + 1);
        }
    }


    public static int ScanDirCount(string path)
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        FileInfo[] files = dir.GetFiles();
        int value = 0;

        DirectoryInfo[] dirs = dir.GetDirectories();

        // Kalder rekursivt på alle undermapper
        foreach (DirectoryInfo subdir in dirs)
        {
            value++;
            value += ScanDirCount(subdir.FullName);
        }
        return value;
    }
}


   
