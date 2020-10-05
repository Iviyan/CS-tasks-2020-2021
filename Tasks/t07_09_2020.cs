using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    class T07_09_2020
    {
        public static double read(string s)
        {
            Console.Write($"{s}: ");
            return Convert.ToDouble(Console.ReadLine());
        }
        //Иван
        public static double T8(double a, double c, double d) => (Math.Tan(c) - d * 23) / (2 * a - 1);
        public static double T12(double a, double c, double d) => (Math.Sqrt(25 / c) - d + 2) / (d + a * a - 1);
        //Игорь
        public static double T14(double a, double c, double d) => (4 * Math.Log10(c) - d / 2 + 23) / (a * a - 1);
        public static double T17(double a, double c, double d) => (2 * c + Math.Log10(d) * 51) / (d - a - 1);

        //Соня
        public static double T7(double a, double c, double d) => (2 * c - Math.Log10(d / 4)) / (a * a - 1);
        public static double T20(double a, double c, double d) => (Math.Atan(2 * c) / d + 2) / (d - a * a - 1);

        public static void Main_()
        {
            while (true)
            {
                Console.WriteLine("Введите числа:");
                double a = read("a"), c = read("c"), d = read("d");
                Console.Write("Введите номер задания: ");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 8: Console.WriteLine(T8(a, c, d)); break;
                    case 12: Console.WriteLine(T12(a, c, d)); break;
                    case 14: Console.WriteLine(T14(a, c, d)); break;
                    case 17: Console.WriteLine(T17(a, c, d)); break;
                    case 7: Console.WriteLine(T7(a, c, d)); break;
                    case 20: Console.WriteLine(T20(a, c, d)); break;
                    default: Console.WriteLine("Такого задания не существует"); break;
                }
                Console.WriteLine();
            }
        }
    }
}
