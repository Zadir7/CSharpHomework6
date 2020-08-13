using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    delegate double Function(double a, double x);
    class Program
    {
        public static void Table(Function f, double a, double x, double lim)
        {
            Console.WriteLine("----- A ----- X ----- Y -----");
            while (x <= lim)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} | {2,8:0.000} |", a, x, f(a,x));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }
        public static double F1(double a, double x)
        {
            return a * x * x;
        }
        public static double F2(double a, double x)
        {
            return a * Math.Sin(x);
        }

        static void Main(string[] args)
        {
            Table(F1, 2, 0, 100);
            Table(F2, 2, 0, 100);
            Console.ReadKey();
        }
    }
}
