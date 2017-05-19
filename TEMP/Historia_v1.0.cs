//Podstawowy składnik do funkcji obsługi historii
//Odczyt z pliku

//Na tym etapie funkcja odczytuje tekst po jedej linijce i każdą linię przepisuje do osobnej zmiennej



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
            lines = new String[10];
           
                // Otwarcie pliku
                StreamReader sr = new StreamReader("s1.txt");

            //Odczyt po jednej linijce
            for (int i = 0; i < 10; i++)
            {
                lines[i] = sr.ReadLine();
                Console.WriteLine(lines[i]);
            }
             
                sr.Close();
                Console.ReadLine();
            
        }
    }
}
