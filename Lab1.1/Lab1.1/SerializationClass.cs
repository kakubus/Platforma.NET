using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Lab1._1
{
    class SerializationClass
    {
        private static BinaryFormatter _bin = new BinaryFormatter();
        static List<string> nameFiles;
        static string defaultFileExtension = "txt";

        public static void Serialize(string filePath, object objToSerial)
        {
            using (Stream stream = File.Open(filePath, FileMode.Create))
            {
                try
                {
                    _bin.Serialize(stream, objToSerial);
                }
                catch(SerializationException e)
                {
                    Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                    throw;
                }
            }
        }

        public static T Deserialize<T>(string filePath)
        {
            T items;
           
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                try
                {
                    items = (T)_bin.Deserialize(stream);
                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                    throw;
                }
                return items;
            }
        }

 /*       public static void DeserializeFromMultipleFileSeries(bool deleteFilesAfterDeserialize)
        {
            T items;

            string[] fileNames = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory);
            CultureInfo provider = CultureInfo.InvariantCulture;
            provider = new CultureInfo("pl-PL");
            int numberOfFiles = 0;
            Console.WriteLine("File name\t|\tCreation datetime");
            foreach (string filename in fileNames)
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filename);
                string[] splitFilename = fileNameWithoutExtension.Split("_PRG_DATA");

                if (splitFilename.Length > 0)
                {
                    try
                    {
                        DateTime fileDate = DateTime.ParseExact(splitFilename[0], "yyyyMMdd_HHmmss", provider);
                        nameFiles.Add(fileNameWithoutExtension+"."+defaultFileExtension);
                        //Console.WriteLine($"{fileNameWithoutExtension}.{defaultFileExtension}\t->\t{fileDate}");
                        numberOfFiles++;
                    }
                    catch (FormatException /*e*//*)
                    {
                        //Console.WriteLine(e);
                        continue;
                    }
                }
            }
            Console.WriteLine($"Found {numberOfFiles} files.");
            
            if (numberOfFiles > 0)
            {
                var a = var a = SerializationClass.Deserialize<List<double?>>(nameFiles);
            }

        }*/
    }
  

    
}
