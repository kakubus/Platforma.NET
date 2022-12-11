using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using static Lab3.MainWindow;

namespace Lab3
{
    class NumberGenerator
    {
        List<int> numbers;

        public int progress { get; private set; } // 0 - 100
        public event Action<int> ProgressChanged;
        public event Action GenerationFinished;
        public ProgramStatus Status { get; private set; } = ProgramStatus.Ready;

        public NumberGenerator()
        {
            this.numbers = new List<int>();
            progress = 0;
            Status = ProgramStatus.Ready;
            
        }

        private void makeProgress(int actual,int amount)
        {
            progress = actual * 100 / amount;
            ProgressChanged.Invoke(progress);
            if(progress >= 100)
            {
                Status = ProgramStatus.Finished;
            }
        }

        public async Task generate(int min, int max, int amount)
        {
            Random rnd = new Random();
            if (min < max && amount > 0)
            {
                numbers.Clear();

                for(int i = 0; i < amount; i++)
                {
                    Status = ProgramStatus.Working;
                    this.numbers.Add(rnd.Next(min, max));
                    await Task.Delay(rnd.Next(100, 1000));
                    makeProgress(i + 1, amount);
                }
                Status = ProgramStatus.Finished;
                GenerationFinished.Invoke();
            }
            else
            {
              GenerationFinished.Invoke();
            }
        }

        public override string ToString() 
        {
            string temp ="";

            foreach(int number in this.numbers)
            {
                temp += "" + number.ToString() + "\n";
            }
            return temp;
        }
    }
}
