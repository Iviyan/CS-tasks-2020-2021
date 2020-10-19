using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    class T11_09_2020
    {
        public static double read(string s)
        {
            Console.Write($"{s}: ");
            return Convert.ToDouble(Console.ReadLine());
        }

        public static void Main_()
        {
            while (true)
            {
                Console.WriteLine("Введите числа:");
                double a = read("a"), c = read("c"), d = read("d");
                Console.Write("Введите номер задания: ");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 8: Console.WriteLine(); break;
                    default: Console.WriteLine("Такого задания не существует"); break;
                }
                Console.WriteLine();
            }
        }
    }
}
