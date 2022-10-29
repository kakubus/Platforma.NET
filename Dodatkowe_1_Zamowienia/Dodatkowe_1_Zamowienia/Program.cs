using System;

namespace Dodatkowe_1_Zamowienia
{
    class Program
    {
        static void Main(string[] args)
        {
            Pozycja p1 = new Pozycja("Chleb", 1, 3.5);
            Pozycja p2 = new Pozycja("Cukier", 3, 4);
            Console.WriteLine(p1);
            Console.WriteLine(p2);

            Zamowienie z = new Zamowienie(20);
            z.dodajPozycje(p1);
            z.dodajPozycje(p2);
            Console.WriteLine(z);
        }
    }
}
