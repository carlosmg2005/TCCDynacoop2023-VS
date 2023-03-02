using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Testes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rd = new Random();
            int num = rd.Next(10000, 30000);

            var ultimoNumGerado = num;
            if (num == ultimoNumGerado)
            {
                num = rd.Next(20000, 50000);
            }

            Console.WriteLine(num);

            Console.ReadKey();
        }
    }
}
