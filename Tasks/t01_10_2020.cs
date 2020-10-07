using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    class T01_10_2020
    {
        public static int fact(int n)
        {
            for (int i = n - 1; i > 0; n *= i, i--) { }
            return n;
        }
        public static string ArrayToStr<T>(T[] arr)
        {
            string s = "[";
            foreach (T i in arr) s += i.ToString() + ", ";
            s = s.Substring(0, s.Length - 2) + "]";
            return s;
        }

        public static void T1()
        {
            Console.WriteLine("Введите значения (0 - закончить)");
            int[] a1 = new int[] { };
            for (int i = 0; ; i++)
            {
                int n = helper.ask($"[{i}] > ");
                if (n == 0) break;
                Array.Resize(ref a1, i + 1);
                a1[i] = n;

            }
            int[] a2 = new int[a1.Length];
            for (int i = 0; i < a1.Length; i++) a2[i] = fact(a1[i]);

            string s = "[";
            foreach (int i in a2) s += i + ", ";
            s = s.Substring(0, s.Length - 2) + "]";
            Console.WriteLine(s);
        }
        public static void T2()
        {
            Random rnd = new Random();
            int size = helper.ask("Введите размер массива: ", default_: 5);
            int[] a = new int[size];
            helper.ArrayFillRnd(ref a);

            Console.WriteLine(ArrayToStr(a));

            int from = helper.ask("Введите интервал:\n от: ") - 1;
            int to = helper.ask(" до: ") - 1;

            int sum = 0;
            for (int i = from; i <= to; i++) sum += a[i];

            Console.WriteLine($"Sum: {sum}");
        }
        public static void Main_()
        {
            // Console.WriteLine($"{fact(5)}"); return;
            T2();
            
        }
    }
}
