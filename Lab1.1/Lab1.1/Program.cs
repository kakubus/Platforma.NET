using System;

namespace Lab1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podstawy .NET\tJakub K\t2022\tV.0.1\n");

            SimTempSensor DS18B20 = new SimTempSensor(-100.0, 100.0, -80.0);
            DS18B20.GenerateSingleReadings();
            Console.WriteLine(DS18B20.ToString());
            DS18B20.GenerateMultipleReadings(5);
            DS18B20.SerializeReadings();
            Console.WriteLine(DS18B20.ToString());

          //  DS18B20.ShowNReadings();
          //  DS18B20.SaveReadingsToFile();

            DS18B20.SerializeReadings();
          //  DS18B20.GenerateMultipleReadings(3);
          //  DS18B20.SaveReadingsToFile();
            Console.WriteLine(DS18B20.ToString());

            DS18B20.ClearAll();
            Console.WriteLine(DS18B20.ToString());
            DS18B20.DeserializeReadings();
            Console.WriteLine(DS18B20.ToString());


            DS18B20.ClearAll();
            DS18B20.SelectAllFiles(true);
            Console.WriteLine(DS18B20.ToString());

        }
    }
}
