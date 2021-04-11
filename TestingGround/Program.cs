using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingGround
{
    class Program
    {
        static void Main(string[] args)
        {
            double rows = 1012.0;
            double pages = rows / 100;
            Console.WriteLine(pages);
            Console.WriteLine(rows % 100);
            if (rows % 100 > 0)
            {
                ++pages;
            }
            Console.WriteLine((int)pages);
            Console.ReadKey();
        }
    }
}
