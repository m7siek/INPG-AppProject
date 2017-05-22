using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace FunkcjaSzyfrująca
{
    class Program
    {
        public int dzialanie(int a, int w, int n) //funkcja wykonuje działanie szyfrujące otrzymując klucz i znak w postaci kodu ASCII
        {
            int pot, wyn, q;

            pot = a; wyn = 1;
            for (q = w; q > 0; q /= 2)
            {
                if (q % 2) wyn = (wyn * pot) % n;
                pot = (pot * pot) % n;
            }
            return wyn;
        }

        public void kodowanie_RSA(int e, int n, int kod) //funckja otrzymuje jako parametry klucz w postaci dwóch liczb oraz literę zamienioną na kod ASCII
        {
            int wynik = dzialanie(e, n, kod);
            Console.WriteLine("\nWynik kodowania = {1}", wynik);

        }
        public int zmien_na_ascii(char a) //funkcja zamienia otrzymaną literę na odpowiadający jej kod ASCII
        {
            int kod = (int)a;
            return kod;
        }

        static void Main(string[] args)
        {
            Program n = new Program();
            int kod = n.zmien_na_ascii('n');
            n.kodowanie_RSA(x, y, kod); //x i y są przykładowymi liczbami klucza

        }
    }
}
