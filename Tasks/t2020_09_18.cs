using System;

namespace Tasks
{
    class T18_09_2020
    {
        public static int read(string s)
        {
            Console.Write($"{s} = ");
            return Convert.ToInt32(Console.ReadLine());
        }

        static double Amean(int a, int b)
        {
            double res = 0;
            if (b > a)
            {
                int count = b - a + 1;
                for (; a <= b; a++) res += a;
                return res / count;
            } else
            {
                int count = a - b + 1;
                for (; a >= b; a--) res += a;
                return res / count;
            }
        }

        static void T1_2()
        {
            int a = -41, b = -121;
            Console.WriteLine(Amean(a, b));

        }
        static void T2_20()
        {
            int A = read("A");
            int n = read("n");

            long res = 1;

            for (; n > 0; n--) res += (int)Math.Pow(A, n);

            Console.WriteLine(res);
        }

        
        public static void Main_()
        {
            while (true)
            {
                Console.Write("Введите задание: ");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1: T1_2(); break;
                    case 2: T2_20(); break;
                }
                if (1 == 0) { Console.ReadKey(); Console.Clear(); } else Console.WriteLine();
            }
        }
    }
}
