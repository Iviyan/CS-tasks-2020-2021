using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    class T12_10_2020
    {
        public static void T1()
        {
            Console.Write("Введите строку:\n > ");
            string s = Console.ReadLine();

            string s1 = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLower(s[i])) s1 += char.ToUpper(s[i]); else s1 += char.ToLower(s[i]);
            }

            Console.WriteLine($"> {s1}");
        }

        public static void T2()
        {
            Console.Write("Введите строку:\n > ");
            string s = Console.ReadLine();

            int min = int.MaxValue;
            string minStr = "";
            string temp = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ') { temp += s[i]; continue; }
                else
                {
                    if (temp == "") continue;
                    if (temp.Length < min)
                    {
                        minStr = temp;
                        min = temp.Length;
                        temp = "";
                    }
                }
            }
            if (temp.Length > 0 && temp.Length < min)
            {
                minStr = temp;
                min = temp.Length;
            }

            Console.WriteLine($"> {minStr} ({min})");
        }

        public static void T3()
        {
            Console.Write("Введите строку S:\n > ");
            string s = Console.ReadLine();
            Console.Write("Введите строку S0:\n > ");
            string s0 = Console.ReadLine();

            string sr = s.Replace(s0, "");

            Console.WriteLine($"> {sr}");
        }

        public static void T4()
        {
            Console.Write("Введите строку:\n > ");
            string s = Console.ReadLine();
            int k = helper.ask("Введите K (0 < k < 10): ", k => k > 0 && k < 10);

            string alp = "абвгдежзийклмнопрстуфхцчшщъыьэюя";
            string alpu = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

            string sr = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (!alp.Contains(char.ToLower(s[i]))) { sr += s[i]; continue; }

                if (char.IsLower(s[i]))
                    sr += alp[(alp.IndexOf(s[i]) + k) % alp.Length];
                else
                    sr += alpu[(alpu.IndexOf(s[i]) + k) % alpu.Length];
            }

            Console.WriteLine($"> {sr}");
        }

        public static void Main_()
        {
            while (true)
            {
                int sel = helper.ask("Введите задание (0 - выход): ");
                if (sel == 0) break;
                switch (sel)
                {
                    case 1: T1(); break;
                    case 2: T2(); break;
                    case 3: T3(); break;
                    case 4: T4(); break;
                    default: Console.WriteLine("Такого задания не существует"); break;
                }
                Console.WriteLine();
            }
        }
    }
}
