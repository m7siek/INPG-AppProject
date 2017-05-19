//Druga wersja funkcji
//Odczyt z pliku i dodanie jednej linii z drugiego pliku


//Funkcja odczytuje linie z pliku i przesuwa je o jedna linie w dol
//w miejsce pierwszej linii wstawiajac pierwsza linie z drugiego plik
//s1 - plik archiwum
//s2 - plik wyjsciowy

//Zmiana: Historia może przechowywać do 100 pozycji



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
            String[] tmp_string;

            tmp_string = new String[100];
            int i;

            // Otwarcie strumieni
            StreamReader sr1 = new StreamReader("s1.txt");
            StreamReader sr2 = new StreamReader("s2.txt");

            //Odczyt po jednej linijce
            for (i = 1; i < 100; i++)
            {
                tmp_string[i] = sr1.ReadLine();

            }
            tmp_string[0] = sr2.ReadLine();

            //Zapis do pliku
            for (i = 0; i < 100; i++) Console.WriteLine(tmp_string[i]);

            //Zamknięcie obu plików
            sr1.Close();
            sr2.Close();

            //Zapis do pliku archiwalnego
            File.WriteAllLines("s1.txt", tmp_string);

            Console.ReadLine();

        }
    }
}
