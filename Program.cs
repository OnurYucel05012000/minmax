using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Game w = new Game();
            w.Start();
            Console.WriteLine("Oyun Bitti !");
            Console.ReadKey();
            
        }
    }
}