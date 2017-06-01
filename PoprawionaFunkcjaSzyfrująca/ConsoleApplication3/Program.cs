using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            string Napis = "Jestem napisem do zakodowania";                        // Przykładowy tekst do zakodowania
            char[] napis = Napis.ToCharArray();
            int[] napisASCII;                                                      // robocza tablica przechiwująca napis w postaci znaków ASCI (1 znak -> trzy komórki)
            long[] ASCI;
            int i = 0, j = 0, tmp; ;

            int OriginalSize = napis.Length;                                        // rzeczywista liczba znaków
            int size = (1 + 3 * OriginalSize / 5) * 5;                                    // rozmiar tablicy przechowującej napis w postaci znaków ASCI
            int sizeASCI = size / 5;                                                // rozmiar dwuwymiarowej tablicy szyfrującej

            Console.WriteLine("\nSize = " + OriginalSize + "\tAcsi:" + size);        // sprawdzenie , do usunięcia

            napisASCII = new int[size];                                             // stworzenie 3*n elementowej tablicy cyfr


            while (napis[i] != '\0' && i < OriginalSize - 1)
            {
                tmp = (Int16)napis[i];

                napisASCII[i * 3] = tmp / 100;
                napisASCII[i * 3 + 1] = (tmp % 100) / 10;
                napisASCII[i * 3 + 2] = tmp % 10;
                i++;
            }

            while (3 * i + j < size)
            {
                napisASCII[3 * i + j] = 0;
                j++;
            }

            Console.WriteLine("\n\nTablica ASCI:");

            for (i = 0; i < size; i++)
                Console.Write("\t" + napisASCII[i]);                                     // sprawdzenie . Jak na razie program działa .

            Console.WriteLine("\n\n tablica liczb do zakodowania");

            ASCI = new long[sizeASCI];

            for (i = 0; i < sizeASCI; i++)
            {
                ASCI[i] = napisASCII[i] + 10 * napisASCII[i + 1] + 100 * napisASCII[i + 2] + 1000 * napisASCII[i + 3] + 10000 * napisASCII[+4];
                Console.Write(ASCI[i] + "\t");
            }


        }
    }
}