using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Tasks
{
    public static class helper
    {
        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr h, string m, string c, int type);

        public static int MessageBox(string msg, string caption, int type) => MessageBox(IntPtr.Zero, msg, caption, type);
        public static int MessageBox(string msg, string caption) => MessageBox(IntPtr.Zero, msg, caption, 0);
        public static int mb(params object[] msg) => MessageBox(IntPtr.Zero, msg.Aggregate("", (string acc, object str) => acc += str.ToString()), "", 0);

        public static double read(string s)
        {
            Console.Write(s);
            return Convert.ToDouble(Console.ReadLine());
        }
        public static int ask(string text = "", int default_ = 0)
        {
            Console.Write(text);
            string inp = Console.ReadLine();
            int res;
            if (!int.TryParse(inp, out res) && default_ != 0) res = default_;
            return res;
        }
        public static int ask(string text, Func<int, bool> iff)
        {
            for (; ;)
            {
                int r = ask(text);
                if (iff(r)) return r;
            }

        }
        public static int Choice(string[] list)
        {
            int select = 0;
            int pos = Console.CursorTop;
            int posEnd = pos + list.Length - 1;
            Console.Write(list.Aggregate("> ", (acc, str) => acc += str + '\n'));
            Console.SetCursorPosition(0, pos);
            ConsoleKeyInfo info;

            while (true)
            {
                info = Console.ReadKey(true);
                Console.CursorLeft = 0;

                if (info.Key == ConsoleKey.DownArrow)
                {
                    Console.Write($"{list[select]}  "); Console.CursorLeft = 0;
                    if (Console.CursorTop < posEnd)
                    {
                        select++;
                        Console.CursorTop += 1;
                    } else
                    {
                        select = 0;
                        Console.CursorTop = pos;
                    }
                    Console.Write($"> {list[select]}");

                } else if (info.Key == ConsoleKey.UpArrow)
                {
                    Console.Write($"{list[select]}  "); Console.CursorLeft = 0;
                    if (Console.CursorTop > pos)
                    {
                        select--;
                        Console.CursorTop -= 1;

                    } else
                    {
                        select = list.Length - 1;
                        Console.CursorTop = posEnd;
                    }
                    Console.Write($"> {list[select]}");

                } else if (info.Key == ConsoleKey.Enter) { Console.CursorTop = posEnd + 1; return select; }
            }
        }
        public static string Choice_str(string[] list)
        {
            int c = Choice(list);
            return list[c];
        }

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
        public static string ArrayToStrInd<T>(T[] arr)
        {
            string s = "[";
            for(int i = 0; i < arr.Length; i++) s += $"{i}: {arr[i].ToString()}, ";
            s = s.Substring(0, s.Length - 2) + "]";
            return s;
        }
        public static string ArrayToStrIndB<T>(T[] arr)
        {
            string s = "[\n";
            for(int i = 0; i < arr.Length; i++) s += $"  {i}: {arr[i].ToString()},\n";
            s = s.Substring(0, s.Length - 2) + "\n]";
            return s;
        }

        public static Random rnd = new Random();
        public static void ArrayFillRnd(ref int[] arr, int min = 0, int max = 1000)
        {
            for (int i = 0; i < arr.Length; i++) arr[i] = rnd.Next(min, max+1);
        }
        
        public static void WriteCenter(string text)
        {
            if (text.Length <= Console.WindowWidth)
                Console.WriteLine(new string(' ', Console.WindowWidth / 2 - text.Length / 2) + text);
            else
                Console.WriteLine(
                    text.Insert(
                        text.Length / Console.WindowWidth * Console.WindowWidth,
                        new string(' ', Console.WindowWidth / 2 - (text.Length % Console.WindowWidth) / 2)
                        )
                    );
        }

        public static int[] FillArr()
        {
            Console.WriteLine("Введите значения (пустая строка - закончить):");
            int[] arr = new int[] { };
            for (int i = 0; ; i++)
            {
                Console.Write($"[{i}] > ");
                string inp = Console.ReadLine();
                if (inp == "") break;
                int n;
                if (!int.TryParse(inp, out n)) break;
                Array.Resize(ref arr, i + 1);
                arr[i] = n;
            }
            return arr;
        }

        public static string MatrixToStr<T>(T[,] arr)
        {
            string s = "";
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                s += '[';
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    s += arr[i,j].ToString() + ", ";
                }
                s = s.Substring(0, s.Length - 2) + "]\n";
            }
            return s;
        }
        public static int FindMax(int[,] arr)
        {
            int max = arr[0,0];
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    if (arr[i, j] > max) max = arr[i, j];
            return max;
        }
        public static string MinLength(string s, int len)
        {
            if (s.Length < len) return s + new string(' ', len - s.Length);
            else return s;
        }
        public static string MatrixToStrB(int[,] arr)
        {
            string s = "";
            int minLength = FindMax(arr).ToString().Length + 2;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                s += '[';
                for (int j = 0; j < arr.GetLength(1) - 1; j++)
                {
                    s += MinLength($"{arr[i,j]}, ", minLength);
                }
                s += MinLength(arr[i, arr.GetLength(1) - 1].ToString(), minLength - 2);
                s += "]\n";
            }
            return s;
        }

        public static void MatrixFillRnd(ref int[,] arr, int min = 0, int max = 1000)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++) 
                    arr[i, j] = rnd.Next(min, max + 1);
        }
    }
}
