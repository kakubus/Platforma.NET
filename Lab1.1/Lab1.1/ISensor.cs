using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1._1
{
    interface ISensor
    {
        
        public double? GenerateSingleReadings();
        public void GenerateMultipleReadings(int number);
        public void ShowNReadings();
        public void SaveReadingsToFile();
        public void SerializeReadings();
        public void DeserializeReadings();
        public bool SelectLastFile();
        public void SelectAllFiles(bool deleteFilesAfterDeserialize);
        public void ClearAll();

    }
}
