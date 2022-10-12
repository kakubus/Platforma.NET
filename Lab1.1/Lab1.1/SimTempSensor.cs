using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;


//test komentarza
namespace Lab1._1
{
    class SimTempSensor
    {
        List<double?> sensorValues;
        private double min_range;
        private double max_range;
        private double error_point;

        public SimTempSensor()
        {
            sensorValues = new List<double?>();
            min_range = -10.0;
            max_range = 10.0;
            error_point = -5.0;
        }

        public SimTempSensor(double min, double max, double error)
        {
            if(min > max)
            {
                sensorValues = new List<double?>();
                min_range = -10.0;
                max_range = 10.0;
                error_point = -5.0;
                Console.WriteLine("Wrong configuration values! -> Setting default properties.");
            }
            else
            {
                sensorValues = new List<double?>();
                min_range = min;
                max_range = max;
                error_point = error;
                Console.WriteLine("Temperature sensor created correctly.\n");
            }
            
        }

        public override string ToString()
        {
            int i = 0;
            String s = "-------------------------------\nTemperature readings:";

            foreach (double? temp in sensorValues)
            {
                i++;
                if(temp == null)
                {
                    s += String.Format("\n[{0}]:\tnull", i);
                }
                else
                {
                    s += String.Format("\n[{0}]:\t{1:N2} °C", i, temp);
                }
            }
            return s;
        }

        public double? GenerateSingleReadings()
        {
            // sensorValues.Clear(); nwm czy potrzebne w sumie
            var rand = new Random();
            double temp = rand.NextDouble();
            temp *= (max_range - min_range) + min_range;

            if(temp <= error_point)
            {
                sensorValues.Add(null);
                return null;
            }
            else
            {
                sensorValues.Add(temp);
                return temp;
            }
            
        }

        public void GenerateMultipleReadings(int number)
        {
            var rand = new Random();

            if (number <= 0) return; //bledna ilosc

            double temp = 0;

            for (int i = 0; i < number; i++)
            {
                temp = rand.NextDouble() * (max_range - min_range) + min_range;
                if (temp <= error_point)
                {
                    sensorValues.Add(null);
                }
                else
                {
                    sensorValues.Add(temp);
                }

            }

        }

        public void ShowNReadings()
        {
            Console.Write("Insert a number of readings to show: ");
            int x; 
            bool success = int.TryParse(Console.ReadLine(), out x);
            if (success)
            {
                if (x > 0)
                {
                    int i = 0;
                    String s = $"------------------------------ -\nShowing {x} readings:";
                    foreach (double? temp in sensorValues)
                    {
                        i++;
                        s += String.Format("\n[{0}]:\t{1:N2} °C", i, temp);

                        if (i >= x) break;
                    }
                    Console.WriteLine(s);
                }
            }
            else
            {
                Console.WriteLine("Wrong number!");
            }

        }

        public void SaveReadingsToFile()
        {
            using (StreamWriter sw = new StreamWriter("readings.txt")) //IDisposable
            {
                string data = "";
                foreach (double? temp in sensorValues)
                {
                    if (temp == null)
                    {
                        data = String.Format("null");
                    }
                    else
                    {
                        data = String.Format("{0:N2}", temp);
                    }
                    
                    sw.WriteLine(data);
                }
                sw.Close();
            }
        }

        public void SerializeReadings()
        {
            String timestamp = string.Format("{0:yyyyMMdd_HHmmss}_PRG_DATA", DateTime.Now);
            SerializationClass.Serialize($"{timestamp}.txt", sensorValues);
        }

        public void DeserializeReadings()
        {
          /*  if(SelectLastFile(true))
            {
                Console.WriteLine("Files exists! (_PRG_DATA)");
            }
            else
            {
                Console.WriteLine("Files doesn't exists! (_PRG_DATA)");
            }*/
            var a = SerializationClass.Deserialize<List<double?>> ("readings_series.txt");
            foreach(double? temp in a)
            {
                sensorValues.Add(temp);
            }
        }

        bool SelectLastFile(bool deleteFilesAfterDeserialize)
        {
            string[] fileNames = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory);
            CultureInfo provider = CultureInfo.InvariantCulture;
            provider = new CultureInfo("pl-PL");
            int numberOfFiles = 0;

            foreach (string filename in fileNames)
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filename);
                string[] splitFilename = fileNameWithoutExtension.Split("_PRG_DATA");

                if(splitFilename.Length > 0)
                {
                    try
                    {
                        DateTime fileDate = DateTime.ParseExact(splitFilename[0], "yyyyMMdd_HHmmss", provider);
                        Console.WriteLine(fileDate);
                        numberOfFiles++;
                    }
                    catch(FormatException /*e*/)
                    {
                        //Console.WriteLine(e);
                        continue;
                    }
                }
            }
            Console.WriteLine($"Found {numberOfFiles} files.");
            if (numberOfFiles > 0) return true;
            else return false;
           
        }

        public void ClearAll() //do testow 
        {
            sensorValues.Clear();
        }


    }
}
