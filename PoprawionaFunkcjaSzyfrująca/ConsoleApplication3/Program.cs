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
            string Napis = "Hello Milva";                                                // Przykładowy tekst do zakodowania
            char[] napis = Napis.ToCharArray();
            int[] napisASCII;                                                      // robocza tablica przechiwująca napis w postaci znaków ASCI (1 znak -> trzy komórki)
            long[] ASCI;
            int i = 0, j = 0, tmp;
            long n,p = 179425373, q =179425537;                                      // klucz prywatny, pobrany z biblioteki
            long e = 15486209;
            n= p * q;                                                              // nie wiem dlaczego , ale bezpośrednia definicja "n" nie zadziałała (n nie wykracza poza zasięg long)
            

            int OriginalSize = napis.Length;                                        // rzeczywista liczba znaków
            int size = (1 + 3 * OriginalSize / 5) * 5;                              // rozmiar tablicy przechowującej napis w postaci znaków ASCI
            int sizeASCI = size / 5;                                                // rozmiar dwuwymiarowej tablicy szyfrującej

            Console.WriteLine("\nSize = " + OriginalSize + "\tAcsi:" + size+"\tASCI:"+sizeASCI);       // sprawdzenie , do usunięcia

            napisASCII = new int[size+2];                                             // stworzenie 3*n elementowej tablicy cyfr


            while (i < OriginalSize)
            {
                tmp = (Int16)napis[i];

                napisASCII[i * 3] = tmp / 100;
                napisASCII[i * 3 + 1] = (tmp % 100) / 10;
                napisASCII[i * 3 + 2] = tmp % 10;
                i++;
            }

            while (3 * i +3+ j < size)
            {
                napisASCII[3 * i + j] = 0;
                j++;
            }

            Console.WriteLine("\n\nTablica ASCI:");

            for (i = 0; i < size; i++)
                Console.Write(" " + napisASCII[i]);                                     // sprawdzenie . Jak na razie program działa .

            Console.WriteLine("\n\n tablica liczb do zakodowania");

            ASCI = new long[sizeASCI];

            for (i = 0; i < sizeASCI; i++)
            {
                ASCI[i] = napisASCII[i*5+4] + 10 * napisASCII[i*5 + 3] + 100 * napisASCII[i*5 + 2] + 1000 * napisASCII[i*5 + 1] + 10000 * napisASCII[5*i];
                Console.Write("Przed:\t" + ASCI[i] + "\tPo:\t");
                ASCI[i] = ((ASCI[i]) ^ e) % n;
                Console.Write(ASCI[i]+"\n");
            }


        }
    }
}