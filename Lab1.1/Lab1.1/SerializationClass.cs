using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Lab1._1
{
    class SerializationClass
    {
        private static BinaryFormatter _bin = new BinaryFormatter();

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
    }
}
