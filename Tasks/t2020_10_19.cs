using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    class t19_10_2020
    {
        public static void T1_4()
        {
            Console.Write("");
            int n = helper.ask("Введите число (1 <= n <= 26): ", n => n >= 1 && n <= 26);

            string alp = "";
            int Aind = (int)'A'; helper.mb(Aind);
            for (int i = 0; i < 26; i++) alp += (char)(Aind + i);

            Console.WriteLine($"> {alp.Substring(0, n)}");
        }

        public static void T2_4()
        {
            Console.Write("Введите строку S:\n > ");
            string s = Console.ReadLine();
            Console.Write("Введите строку S0:\n > ");
            string s0 = Console.ReadLine();
            Console.Write("Введите символ C: ");
            char c = Console.ReadLine()[0];

            int s0l = s0.Length;

            string sr = "";
            for (int i = 0; i < s.Length; i++)
                if (s[i] == c)
                    sr += s0 + s[i];
                else
                    sr += s[i];

            Console.WriteLine($"> {sr}");
        }

        public static string[] ExtractWords(string s)
        {
            List<string> words = new List<string>();

            string temp = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ') temp += s[i];
                else
                {
                    if (temp != "")
                    {
                        words.Add(temp);
                        temp = "";
                    }
                }
            }
            if (temp != "") words.Add(temp);

            return words.ToArray();
        }

        public static void T3_4()
        {
            Console.Write("Введите строку S:\n > ");
            string s = Console.ReadLine();

            string[] wl = ExtractWords(s);
            helper.mb(helper.ArrayToStr(wl));

            int AC = 0;
            foreach (string w in wl)
                if (w.Contains('А')) AC++;

            Console.WriteLine($"> 'А' в словах: {AC}");
        }

        public static void T4()
        {
            Console.Write("Введите путь к файлу:\n > ");
            string s = helper.ReadLine_esc(1==1 ? "C:/folder1/index.1.html" : ""); //заготовок ввода для демонстрации

            int sli1 = s.LastIndexOf('/');
            int sli2 = s.LastIndexOf('/', sli1 - 1);

            string cname = "/";

            if (sli2 >= 0)
                cname = s.Substring(sli2 + 1, sli1 - sli2 - 1);

            Console.WriteLine($"> {cname}");
        }

        public static void Main_()
        {
            while (true)
            {
                int sel = helper.ask("Введите задание (0 - выход): "); Console.WriteLine();
                if (sel == 0) break;
                switch (sel)
                {
                    case 1: T1_4(); break;
                    case 2: T2_4(); break;
                    case 3: T3_4(); break;
                    case 4: T4(); break;
                    default: Console.WriteLine("Такого задания не существует"); break;
                }
                Console.WriteLine();
            }
        }
    }
}
