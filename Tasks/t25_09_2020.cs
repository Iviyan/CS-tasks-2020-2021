using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    class T25_09_2020
    {
        public delegate double Task(double a, double c, double d);
        public static double Eval(Task task)
        {
            Console.WriteLine("Ввдите значения:");
            double a = helper.read("a = "),
                   c = helper.read("c = "),
                   d = helper.read("d = ");
            return task(a, c, d);
        }
        public static double T1(double a, double c, double d) => (2 * c - d + Math.Sqrt(23)) / (a / 4 - a);
        public static double T2(double a, double c, double d) => (c + 4 * d - Math.Sqrt(123)) / (1 - a / 2);
        public static void Main_()
        {
            while (true)
            {
                int sel = helper.ask("Введите задание (0 - выход): ");
                if (sel == 0) break;
                switch (sel)
                {
                    case 1: Console.WriteLine($"= {Eval(T1)}"); break;
                    case 2: Console.WriteLine($"= {Eval(T1)}"); break;
                    default: Console.WriteLine("Такого задания не существует"); break;
                }
                Console.WriteLine();
            }
        }
    }
}
