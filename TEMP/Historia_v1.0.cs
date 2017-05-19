//Druga wersja funkcji
//Odczyt z jednego pliku i zapis do drugiego po jednej linii

//Funkcja odczytuje wszytkie linie z jednego pliku i przepisuje je do  drugiego pliku


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
            String[] lines;
            lines = new String[11];

            // Otwarcie pliku
            StreamReader sr1 = new StreamReader("s1.txt");

            //Odczyt po jednej linijce
            for (int i = 0; i < 11; i++)
            {
                lines[i] = sr1.ReadLine();
                Console.WriteLine(lines[i]);
                File.WriteAllLines("s2.txt", lines);
            }

            sr1.Close();
            
            Console.ReadLine();

        }
    }
}
