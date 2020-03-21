using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polinom
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] koef1 = { 1, 2, 3 };
            int[] koef2 = { 4, 5, 6, 7 };

            Mnogochlen A = new Mnogochlen(koef1);
            Mnogochlen B = new Mnogochlen(koef2);


            //вывод многочленов
            Console.Write("A= ");
            A.show();
            Console.WriteLine();

            Console.Write("B= ");
            B.show();
            Console.WriteLine();

            try
            {
                Mnogochlen C = A + B;
                Console.Write("A+B= ");
                C.show();
                Console.WriteLine();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            try
            {
                Mnogochlen D = A - B;
                Console.Write("A-B= ");
                D.show();
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Mnogochlen E = A * B;
                Console.Write("A*B= ");
                E.show();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

           

          
            
           

           
        }
    }
}
