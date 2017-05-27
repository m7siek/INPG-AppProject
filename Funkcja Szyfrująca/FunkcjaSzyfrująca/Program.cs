using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
 
namespace FunkcjaSzyfrująca
{
    public class Program
    {
        public static long[] kodowanie_RSA(int[] kod, long e, long mod, int dlugosc) //funkcja otrzymuje tablicę znaków zamienionych 
        {                                                                            // na odpowiadające im kody ASCII i długość tablicy 
            long pot;                                                                //je przechowującej oraz klucz w postaci dwóch liczb
            var wyn = new long[dlugosc];
            for (int j = 0; j < dlugosc; j++)
            {
                pot = kod[j]; wyn[j] = 1;
                for (long i = e; i > 0; i /= 2)
                {
                    if ((i % 2) == 1)
                        wyn[j] = (wyn[j] * pot) % mod;
                    pot = (pot * pot) % mod;
                }
            }
            return wyn; //jak wynik funkcja zwraca tablicę zakodowanych liter 
        }
        public static int[] zmien_na_ascii(char[] a, int dlugosc) //funkcja zamienia otrzymaną tablicę liter na odpowiadające im kody ASCII
        {
            var kod = new int[dlugosc];

            for (int i = 0; i < dlugosc; i++)
            {
                kod[i] = (int)a[i];
            }

            return kod;
        }
    }
}
