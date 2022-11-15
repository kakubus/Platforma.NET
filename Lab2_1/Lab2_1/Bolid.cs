using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_1
{
    class Bolid
    {
        public void PitStop()
        {
            
            ZnakStop();
            WymianaKola(3);
            WymianaKola(1);
            WymianaKola(2);
            WymianaKola(4);
            Tankowanie(100);
            UstawSkrzydlo();
            WyczyscKask();
        }
        public async Task ZnakStop()
        {
            while (true)
            {
                Console.WriteLine("Jakies info o stanie..");
                await Task.Delay(100);
            }
            
        }

        public async Task WymianaKola(int numerKola)
        {
            Console.WriteLine($"Rozpoczynam wymiane kola nr: {numerKola}");
            await Task.Delay(2000);
            Console.WriteLine($"Wymieniono kolo nr:{numerKola}");
        }

        public async Task<int> Tankowanie(int iloscLitrow)
        {
            Console.WriteLine($"Rozpoczeto tankowanie ({iloscLitrow} l)");
            await Task.Delay(50*iloscLitrow);
            Console.WriteLine($"Zakonczono tankowanie");
            return iloscLitrow;
        }

        public async Task UstawSkrzydlo()
        {
            Console.WriteLine("Ustawiam skrzydlo");
            await Task.Delay(1000);
            Console.WriteLine($"Skrzydlo ustawione");
        }

        public async Task WyczyscKask()
        {
            Console.WriteLine("Czyszcze kask");
            await Task.Delay(500);
            Console.WriteLine("Kask lsni jak nowy!");
        }
    }
}
