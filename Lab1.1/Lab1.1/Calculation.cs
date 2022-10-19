using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1._1
{
    class Calculation : SimTempSensor
    {
        public Calculation(List<double?> values)
        {
            sensorValues = values;
        }

        public double CalcMean()
        {
            double sum = 0;
            if(sensorValues.Count>0)
            {
                foreach (double val in sensorValues)
                {
                    sum += val;
                }
                return sum / (double)sensorValues.Count;
            }
            else
            {
                return 0;
            }
        }
    }
}
