using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int k;
            long p, q, n, d, e ;

            k = 3;

            p = 179424673;

            q = 179424691;

            n = p*q;

            e = 15485863;

            d = (1 + k*(p-1)*(q-1) ) / e;




            Console.BackgroundColor = ConsoleColor.DarkGray;

            Console.WriteLine("RSA: Key generator\n\np:"+p+"\nq:"+q+"\nn:"+n+"\ne:"+e+"\nd:"+d);


            Console.ReadKey(); 


        }
    }
}
