using System;

namespace Dodatkowe_1_Zamowienia
{
    class Program
    {
        static void Main(string[] args)
        {


            Pozycja p1 = new Pozycja("Chleb", 1, 3.5);
            Pozycja p2 = new Pozycja("Cukier", 3, 4);
            Pozycja p3 = new Pozycja("Rzepak", 22, 1.30);
            Pozycja p4 = new Pozycja("Chleb", 22, 3.50);
           // Console.WriteLine(p1);
           // Console.WriteLine(p2);

            Zamowienie z = new Zamowienie(20);
            z.dodajPozycje(p1);
            z.dodajPozycje(p2);
            z.dodajPozycje(p3);
            z.dodajPozycje(p4);
            String timestamp = string.Format("{0:yyyyMMdd_HHmmss}_PRG_DATA", DateTime.Now);
            // SerializationClass.Serialize("serializacja.txt", z.ToString());

            var a = SerializationClass.Deserialize<Zamowienie>("serializacja.txt", false);

            Console.WriteLine(a.ToString());

            //Console.WriteLine(z);
            //z.usunPozycje(2);
            // Console.WriteLine(z);
            //  z.edytujPozycje(1);
            Console.WriteLine(z);
        }
    }
}
