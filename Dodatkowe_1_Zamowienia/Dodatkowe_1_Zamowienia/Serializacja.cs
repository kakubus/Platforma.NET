using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Dodatkowe_1_Zamowienia
{
    class SerializationClass
    {
        private static BinaryFormatter _bin = new BinaryFormatter();
        static List<string> nameFiles = new List<string>();
        static string defaultFileExtension = "txt";

        public static void Serialize(string filePath, object objToSerial)
        {
            using (Stream stream = File.Open(filePath, FileMode.Create))
            {
                try
                {
                    _bin.Serialize(stream, objToSerial);
                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                    //throw;
                }
            }
        }

        public static T Deserialize<T>(string filePath, bool deleteFilesAfterDeserialize)
        {
            T items;
            try
            {
                using (Stream stream = File.Open(filePath, FileMode.Open))
                {
                    try
                    {
                        items = (T)_bin.Deserialize(stream);
                        if (deleteFilesAfterDeserialize == true)
                        {
                            stream.Close();
                            File.Delete(filePath);
                            Console.WriteLine($"Deleting file: {filePath} after load.");
                        }

                    }
                    catch (SerializationException e)
                    {
                        Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                        throw;
                    }
                    return items;
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Failed to open file: {filePath}: {e.Message} | not found");
                throw;
            }
        }

        public static void DeserializeFromMultipleFileSeries(ref List<double?> targetList, bool deleteFilesAfterDeserialize)
        {
            // T items;

            string[] fileNames = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory);
            CultureInfo provider = CultureInfo.InvariantCulture;
            provider = new CultureInfo("pl-PL");
            int numberOfFiles = 0;

            foreach (string filename in fileNames)
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filename);
                string[] splitFilename = fileNameWithoutExtension.Split("_PRG_DATA");

                if (splitFilename.Length > 0)
                {
                    try
                    {
                        DateTime fileDate = DateTime.ParseExact(splitFilename[0], "yyyyMMdd_HHmmss", provider);
                        string temp = fileNameWithoutExtension + "." + defaultFileExtension;
                        Console.WriteLine($"Loading file: {temp}");
                        nameFiles.Add(temp);
                        //Console.WriteLine($"{fileNameWithoutExtension}.{defaultFileExtension}\t->\t{fileDate}");
                        numberOfFiles++;
                    }
                    catch (FormatException /*e*/)
                    {
                        //Console.WriteLine(e);
                        continue;
                    }
                }
            }
            Console.WriteLine($"Found {numberOfFiles} files.");

            if (numberOfFiles > 0)
            {
                int counter = nameFiles.Count - 1;
                for (int i = 0; i < numberOfFiles; i++)
                {
                    Console.WriteLine($"Loading file: {nameFiles[counter]}");
                    var a = Deserialize<List<double?>>(nameFiles[counter], deleteFilesAfterDeserialize);
                    foreach (double? temp in a)
                    {
                        //Console.WriteLine($"{temp}");
                        targetList.Add(temp);

                    }
                    if (deleteFilesAfterDeserialize == true)
                    {
                        // Console.WriteLine($"Deleting file: {nameFiles[counter]} after load.");
                        nameFiles.RemoveAt(counter);
                    }
                    counter--;
                }

            }

        }
    }
}
