using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lab3
{
    class NumberGenerator
    {
        List<int> numbers;
        int progress = 0; // 0 - 100
        public NumberGenerator()
        {
            this.numbers = new List<int>();
            this.progress = 0;
        }

        private void makeProgress(int actual,int amount)
        {
            this.progress = actual * 100 / amount;
        }

        public List<int> generate(int min, int max, int amount)
        {
            if(min < max && amount > 0)
            {
                Random rnd = new Random();

                for(int i = 0; i < amount; i++)
                {
                    this.numbers.Add(rnd.Next(min, max));
                    Thread.Sleep(rnd.Next(200, 1000)); //losowy czas oczekiwania od 0.2-1s.
                    makeProgress(i, amount);
                }
            }

            return this.numbers;
        }

        public override string ToString() 
        {
            string temp ="";

            foreach(int number in  this.numbers)
            {
                temp += "" + number.ToString() + "\n";
            }
            return temp;
        }
    }
}
