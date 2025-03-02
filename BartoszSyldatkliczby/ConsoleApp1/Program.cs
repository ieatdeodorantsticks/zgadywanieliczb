using System.Diagnostics;

Random radom = new Random(); 
int Liczba = 0;
Console.WriteLine("1. Łatwy - zakres 1 - 50 (5 prób) \n2. Średni - zakres 1 - 100 (10 prób) \n3. Trudny - zakres 1 - 500 (20 prób)");
string Poziom;
int Diff = 0;
int Pozostale = 0;

Console.Write("Wybierz poziom trudności: ");
do{
    Poziom = Console.ReadLine();
    switch (Poziom){
        case "1":
            Diff = 51;
            Pozostale = 7;
            break;
        case "2":
            Diff = 101;
            Pozostale = 10;
            break;
        case "3":
            Diff = 501;
            Pozostale = 20;
            break;
        default:
            Poziom = String.Empty;
            Console.Write("Wpisz poprawną liczbę: ");
            continue;
    }
} while(Poziom == string.Empty);
Liczba = radom.Next(1, Diff);
Console.WriteLine($"Zgadnij wylosowaną liczbę z zakresu 1 - {Diff - 1}"); 
 
int x = 0; 
int Proby = 0;

//licznik czasu
Stopwatch czas = new Stopwatch();
czas.Start();

while (x != Liczba){ 
    Console.Write("Podaj swoją propozycję: "); 
    if (!int.TryParse(Console.ReadLine(), out x)) { 
        Console.WriteLine("Podaj porawną liczbę całkowitą"); 
        continue; 
    }
    Proby++;
    Pozostale--; 

    //podpowiedzi
    if(x < Liczba) { 
        Console.WriteLine("Za mało! Spróbuj większej liczby.");
        if (Math.Abs(Liczba - x) > 20){
            Console.WriteLine("Daleko");
        }
        else if (Math.Abs(Liczba - x) <= 5){
            Console.WriteLine("Blisko");
        }
    } 
    else if (x > Liczba){ 
        Console.WriteLine("Za dużo! Spróbuj mniejszej liczby"); 
        if (Math.Abs(x - Liczba) > 20){
            Console.WriteLine("Daleko");
        }
        else if (Math.Abs(x - Liczba) <=5){
            Console.WriteLine("Blisko");
        }
    }

    //sprawdzanie pozostalych prob
    if (x != Liczba) {
        if (Pozostale == 0) {
        Console.WriteLine("Brak prób");
        break;
        }
    else{
                Console.WriteLine($"Pozostało {Pozostale} prób");
        }
    }
}
czas.Stop();
string a = (x == Liczba) ? $"Zgadłeś liczbę {Liczba} w {Proby} próbach i {czas.Elapsed.Seconds} sekund" : $"Przegrałeś, liczba to {Liczba}";
Console.WriteLine(a);
