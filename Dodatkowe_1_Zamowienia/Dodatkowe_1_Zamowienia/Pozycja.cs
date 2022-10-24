using System;
using System.Collections.Generic;
using System.Text;

namespace Dodatkowe_1_Zamowienia
{
    class Pozycja
    {
        string _nazwaTowaru;
        int _ileSztuk;
        double _cena;

        Pozycja(string nazwaTowaru, int ileSztuk, double cena)
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
