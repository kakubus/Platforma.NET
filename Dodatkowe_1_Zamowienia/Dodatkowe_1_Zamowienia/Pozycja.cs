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

        public Pozycja(string nazwaTowaru, int ileSztuk, double cena)
        {
            _nazwaTowaru = nazwaTowaru;
            if (ileSztuk >= 0) _ileSztuk = ileSztuk;
            else _ileSztuk = 0;

            if (cena >= 0) _cena = cena;
            else _cena = 0;
        }

        public double obliczWartosc()
        {
            return _ileSztuk*_cena;
        }

        public override string ToString()
        {
            string temp = ($"{_nazwaTowaru}\t\t{ _cena.ToString():4c} PLN\t{_ileSztuk.ToString():4} szt.\t{obliczWartosc().ToString():f10c} PLN");
               

            return temp;
        }

    }
}
