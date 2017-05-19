//Druga wersja funkcji
//Odczyt z pliku i dodanie jednej linii z drugiego pliku


//Funkcja odczytuje linie z pliku i przesuwa je o jedna linie w dol
//w miejsce pierwszej linii wstawiajac pierwsza linie z drugiego plik
//s1 - plik archiwum
//s2 - plik wyjsciowy



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Historia_Konsolowo
{
    class Program
    {
        static void Main()
        {
            String[] line, tmp_string;
            line = new String[11];
            tmp_string = new String[11];
            int i;

            // Otwarcie pliku
            StreamReader sr1 = new StreamReader("s1.txt");
            StreamReader sr2 = new StreamReader("s2.txt");

            //Odczyt po jednej linijce
            for (i = 1; i < 10; i++)
            {
                tmp_string[i] = sr1.ReadLine();
            }
            tmp_string[0] = sr2.ReadLine();

            for (i = 0; i < 10; i++) Console.WriteLine(tmp_string[i]);
            sr1.Close();

            File.WriteAllLines("s1.txt", tmp_string);

            sr2.Close();
            // Console.ReadLine();

        }
    }
}
