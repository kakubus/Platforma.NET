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

        Zamowienie()
        {
            _maksRozmiar = 10;
        }

        Zamowienie(int maksPozycji)
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
        }

        public void dodajPozycje(Pozycja p)
        {

        }

        public double obliczWartosc()
        {
            return 0;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
