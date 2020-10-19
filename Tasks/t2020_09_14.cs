#define switch
using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    class T14_09_2020
    {
        public static double read(string s)
        {
            Console.Write($"{s} = ");
            return Convert.ToDouble(Console.ReadLine());
        }
        public static double T1_10_1(double p, double x) => (3 / 5 * p * Math.Pow(x, 2)) - Math.Pow(Math.Cos(x), 2);
        public static double T1_10_2(double p, double x, double c) => c * Math.Pow(Math.E, p * x + 1);
        public static double T1_10_3(double x, double c) => Math.Pow(c * Math.Log(x * x + 1), 1 / 3d);
        public static void T1_10()
        {
            Console.WriteLine("Введите:");
            double p = read("p");

            if (p > 0)
            {
                double x = read("x");
                Console.WriteLine($" = {T1_10_1(p, x)}");
            }
            else if (p < 0)
            {
                double x = read("x");
                double c = read("c");
                Console.WriteLine($" = {T1_10_2(p, x, c)}");
            }
            else if (p == 0)
            {
                double x = read("x");
                double c = read("c");
                Console.WriteLine($" = {T1_10_3(x, c)}");
            }
        }

        public static Dictionary<int, int> month_days = new Dictionary<int, int>
        {
            [1] = 31,
            [2] = 28,
            [3] = 31,
            [4] = 30,
            [5] = 31,
            [6] = 30,
            [7] = 31,
            [8] = 31,
            [9] = 30,
            [10] = 31,
            [11] = 30,
            [12] = 31
        };

        public static int getDays(int month)
        {
#if (!switch)
            int days;
            bool hasValue = month_days.TryGetValue(month, out days);
            if (hasValue) return days; else return 0;
#else
            switch (month)
            {
                case 1: return 31;
                case 2: return 28;
                case 3: return 31;
                case 4: return 30;
                case 5: return 31;
                case 6: return 30;
                case 7: return 31;
                case 8: return 31;
                case 9: return 30;
                case 10: return 31;
                case 11: return 30;
                case 12: return 31;
                default: return 0;
            }
#endif
        }
        public static void T2_4()
        {
            Console.Write("Введите месяц: ");
            int month = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Кол-во дней: {getDays(month)}");
        }
        public static void Main_()
        {
            while (true)
            {
                Console.Write("Введите задание: ");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1: T1_10(); break;
                    case 2: T2_4(); break;
                }
                if (1 == 0) { Console.ReadKey(); Console.Clear(); } else Console.WriteLine();
            }
        }
    }
}
