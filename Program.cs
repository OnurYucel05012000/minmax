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
            int i = 0;
            int gamelength = 20;
            while (i<gamelength)
            {                                              
                    w.Start();
                    Console.WriteLine("Oyun Bitti !");
                i++;
               
            }
            Console.WriteLine("=========");
            Console.WriteLine("Owin :" + w.getOwin());
            Console.WriteLine("Xwin :" + w.getXwin());
            Console.WriteLine("Tie  :" + (gamelength - (w.getOwin() + w.getXwin()) )   );
            Console.WriteLine("=========");
            Console.ReadKey();
            
        }
    }
}
