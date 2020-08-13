using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    delegate double Function(double x);    
    class Program
    {
        static List<Function> functions = new List<Function>()
    {
        delegate(double x) { return x*x; },
        delegate(double x) { return Math.Pow(x,3); },
        delegate(double x) { return Math.Sin(x); },
        delegate(double x) { return Math.Cos(x); }

    };
        public static void SaveFunc(Function f, string fileName, double start, double end, double step)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create,
            FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = start;
            while (x <= end)
            {
                bw.Write(f(x));
                x += step;
            }
            bw.Close();
            fs.Close();
        }

        public static List<double> Load(string fileName, out double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            
            List<double> arr = new List<double>();
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                arr.Add(bw.ReadDouble());
            }
            min = arr.Min();
            bw.Close();
            fs.Close();
            return arr;
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"Данная программа позволяет получить множество значений функции и ее минимум.\nВыберите функцию: введите число с клавиатуры");
            Console.WriteLine($"0 - квадратичная функция \n1 - функция 3й степени \n2 - Синусоида \n3 - Косинусоида");
            int choice = Convert.ToInt32(Console.ReadLine());
            SaveFunc(functions[choice], "f.txt", -100, 100, 1);

            List<double> result = Load("f.txt", out double minimum);
            foreach (var item in result)
            {
                Console.Write($"{item:f2} ");
            }
            Console.WriteLine();
            Console.WriteLine($"Минимальное значение функции: {minimum:f2}");

            Console.ReadKey();
        }
    }
}
