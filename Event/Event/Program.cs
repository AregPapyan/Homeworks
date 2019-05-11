using System;
using System.Threading;

namespace Practic
{
    class Actions
    {
        
        public delegate void Act(int args);
        public event Act OnEvenNumberFound;

        public void Generator()
        {
            int num = 0;
            Random rnd = new Random();            
            while(true)
            {
                num = rnd.Next(0, 1000000);
                Console.WriteLine(num);
                if(num%2==0)
                {
                    if(this.OnEvenNumberFound != null)
                    {
                        this.OnEvenNumberFound(num);
                    }
                }
                Thread.Sleep(1000);
            }
            
        }
    }
    class Program
    {
        public static void Printer(int x)
        {
            Console.WriteLine($"New even Random Number!! {x}");
        }        
        
        static void Main(string[] args)
        {

            Actions a = new Actions();
            a.OnEvenNumberFound += Printer;
            a.Generator();
            Console.ReadKey();
        }
    }
}