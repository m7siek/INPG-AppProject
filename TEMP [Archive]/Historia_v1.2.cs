//Wersja do weryfikacji

//Funkcja otwiera dwa pliki, historię i plik wyjsciowy
//laczy je w jeden, wpisujac tresc pliku wyjsciowego na poczatek histori
//Przechowuje do 100 pozcji

//Do ewentuanej zmiany: 
//                      -nazwa pliku wyjsciowego dodana jako arument wywolania
//                      -zmiana pojemnosci historii na nielimitowana
//                      -utworzenie w funkcji opcji wczytania pozycji z historii do aplikacji

using System;
using System.IO;
// Funkcja nie otrzymuje nic na wejsciu, do poprawy w momencie gdy gotowa będzie obsługa pliku wyjsciowego
// Wtedy struktura funkji bedzie przebudowana 
static void archive()
{
    String[] tmp_string = new String[100];
    int i;

        // Otwarcie strumieni
        StreamReader sr1 = new StreamReader("archive.txt");
        StreamReader sr2 = new StreamReader("application_output.txt");

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
        File.WriteAllLines("archive.txt", tmp_string);
}