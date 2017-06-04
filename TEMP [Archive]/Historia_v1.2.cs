//Wersja do weryfikacji

//Funkcja archive otwiera dwa pliki, historię i plik wyjsciowy, na koniec usuwa plik wyjsciowy
//laczy je w jeden, wpisujac tresc pliku wyjsciowego na poczatek histori
//Przechowuje do 100 pozcji

//Funkcja save_to_file tworzy nowy plik i zapisuje otrzymany string

//Do ewentuanej zmiany: 
//                      -nazwa pliku wyjsciowego dodana jako arument wywolania
//                      -zmiana pojemnosci historii na nielimitowana
//                      -utworzenie w funkcji opcji wczytania pozycji z historii do aplikacji

using System;
using System.IO;
// Wtedy struktura funkji bedzie przebudowana 
static void archive(string path_1, string path_2)//path_1 - archiwum, path_2 - wyjscie
{
    String[] tmp_string = new String[100];
    int i;

        // Otwarcie strumieni
        StreamReader sr1 = new StreamReader(path_1);
        StreamReader sr2 = new StreamReader(path_2);

        //Odczyt po jednej linijce
        for (i = 1; i < 100; i++)
        {
            tmp_string[i] = sr1.ReadLine();
        }

        tmp_string[0] = sr2.ReadLine();


        //Zamknięcie obu plików
        sr1.Close();
        sr2.Close();

        //Zapis do pliku archiwalnego
        File.WriteAllLines(path_1, tmp_string);
    File.Delete(path_2); //Plik jest usuwany aby nie zasmiecac pamieci

}
static void save_to_file(string path_2,string tekst)
{
    File.Create(path_2);
    File.WriteAllLines(path_2, tekst);
}