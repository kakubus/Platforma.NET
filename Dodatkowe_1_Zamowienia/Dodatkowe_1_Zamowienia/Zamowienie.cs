using System;
using System.Collections.Generic;
using System.Text;

namespace Dodatkowe_1_Zamowienia
{
    class Zamowienie
    {
        Pozycja[] _pozycje;
        int _ileDodanych;
        int _maksRozmiar;

        public Zamowienie()
        {
            _maksRozmiar = 10;
            _ileDodanych = 0;
            _pozycje = new Pozycja[_maksRozmiar];
        }

        public Zamowienie(int maksPozycji)
        {
            if(maksPozycji > 0)
            {
                _maksRozmiar = maksPozycji;
            }
            else
            {
                _maksRozmiar = 10;
                Console.WriteLine("Error in max parameter. Set to default (10)");
            }
            _pozycje = new Pozycja[_maksRozmiar];
            _ileDodanych = 0;
        }

        public void dodajPozycje(Pozycja p)
        {
            bool isExist = false;
            foreach (Pozycja i_pozycja in _pozycje)
            {
                int indeks = 0;
                if (i_pozycja == null) break;
                if(p._nazwaTowaru == i_pozycja._nazwaTowaru)
                {
                    isExist = true;
                    Console.WriteLine($"This product (Named as: {p._nazwaTowaru}) already exsits. Modifying amount. Price is also modified.");
                    _pozycje[indeks] += p;
                    indeks++;
                }
                else
                {
                    indeks++;
                    continue;
                }

            }
            if (!isExist)
            {
                _pozycje[_ileDodanych] = p;
                _ileDodanych++;
            }
        
        }

        public void edytujPozycje(int indeks)
        {
            if (indeks >= 0 && indeks < _maksRozmiar && indeks < _ileDodanych)
            {
                string nowaNazwa = "";
                int nowaIleSztuk = 0;
                double nowaCena = 0;
                Console.WriteLine($"Edycja pozycji: {_pozycje[indeks]}");

                Console.Write("Podaj nazwe: ");
                nowaNazwa = Console.ReadLine();

                Console.Write("Podaj ilosc sztuk: ");
                nowaIleSztuk = int.Parse(Console.ReadLine());

                Console.Write("Podaj cene: ");

                try
                {
                    nowaCena = double.Parse(Console.ReadLine()); 
                }
                catch(System.FormatException e){
                    Console.WriteLine(e);
                }

                if (nowaCena >= 0 && nowaIleSztuk >= 0)
                {
                    _pozycje[indeks] = new Pozycja(nowaNazwa, nowaIleSztuk, nowaCena);
                }
                else
                {
                    Console.WriteLine("Wrong values to edit. Aborting..");
                }

            }
        }

        public void usunPozycje(int indeks)
        {
            if (indeks >= 0 && indeks < _maksRozmiar && indeks <_ileDodanych)
            {
                for(int i = indeks; i<_maksRozmiar-1; i++)
                {
                    if (i == indeks) _ileDodanych--;
                    _pozycje[i] = _pozycje[i + 1];     
                }
            }
            else Console.WriteLine("Wrong index to delete!\n");
        }

        public double obliczWartosc()
        {
            double sum = 0;

            for(int i = 0; i < _ileDodanych; i++)
            {
                sum += _pozycje[i].obliczWartosc();
            }

            return sum;
        }

        public override string ToString()
        {
            string temp = "Zamowienie:\n";
            for (int i = 0; i < _ileDodanych; i++)
            {
               temp+=_pozycje[i].ToString()+"\n";
            }
            temp+=($"\nRazem: {obliczWartosc().ToString():C} PLN" );
            return temp;
        }
    }
}
