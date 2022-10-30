using System;
using System.Collections.Generic;
using System.Text;

namespace Dodatkowe_1_Zamowienia
{
    class Pozycja
    {
        public string _nazwaTowaru;
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

        public double obliczWartoscZRabatem()
        {
            if(this._ileSztuk>=5 && this._ileSztuk <= 10)
            {
                return (_ileSztuk * _cena)*0.05; //5% rabatu
            }
            else if (this._ileSztuk > 10 && this._ileSztuk <= 20)
            {
                return (_ileSztuk * _cena) * 0.1; //10% rabatu
            }
            else if (this._ileSztuk > 20)
            {
                return (_ileSztuk * _cena) * 0.15; //15% rabatu
            }
            else
            {
                return _ileSztuk * _cena;
            }

        }

        public override string ToString()
        {
            string temp = ($"{_nazwaTowaru}\t\t{ _cena.ToString():4C} PLN\t{_ileSztuk.ToString():4} szt.\t{obliczWartosc().ToString():f10c} PLN");
            return temp;
        }

        public static Pozycja operator +(Pozycja a, Pozycja b)
        {
           return new Pozycja(a._nazwaTowaru, a._ileSztuk + b._ileSztuk, b._cena);
        }
    }
}
