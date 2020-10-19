using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

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
            for (; ; )
            {
                int r = ask(text);
                if (iff(r)) return r;
            }

        }
        public static int Choice(string[] list) => Choice(list, (k, i) => null);
        public static int Choice(string[] list, Func<ConsoleKey, int, int?> act)
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

                } else if (info.Key == ConsoleKey.Enter) { Console.CursorTop = posEnd + 1; return select; } else
                {
                    int? t = act(info.Key, select);
                    if (t != null) return (int)t;
                }
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
            for (int i = 0; i < arr.Length; i++) s += $"{i}: {arr[i].ToString()}, ";
            s = s.Substring(0, s.Length - 2) + "]";
            return s;
        }
        public static string ArrayToStrIndB<T>(T[] arr)
        {
            string s = "[\n";
            for (int i = 0; i < arr.Length; i++) s += $"  {i}: {arr[i].ToString()},\n";
            s = s.Substring(0, s.Length - 2) + "\n]";
            return s;
        }

        public static Random rnd = new Random();
        public static void ArrayFillRnd(ref int[] arr, int min = 0, int max = 1000)
        {
            for (int i = 0; i < arr.Length; i++) arr[i] = rnd.Next(min, max + 1);
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
                    s += arr[i, j].ToString() + ", ";
                }
                s = s.Substring(0, s.Length - 2) + "]\n";
            }
            return s;
        }
        public static int FindMax(int[,] arr)
        {
            int max = arr[0, 0];
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
                    s += MinLength($"{arr[i, j]}, ", minLength);
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

        public static bool IsInputChar(char c) => Char.IsLetterOrDigit(c) || Char.IsPunctuation(c) || Char.IsWhiteSpace(c) || Char.IsSymbol(c);

        public static string ReadLine_esc(string input = "")
        {
            string v = input;
            ReadLine_esc(ref v, input);
            return v;
        }
        public static bool ReadLine_esc(ref string value, string input = "")
        {
            int left = Console.CursorLeft,
                pos = 0;

            StringBuilder buffer = new StringBuilder();

            if (input != "")
            {
                buffer.Append(input);
                pos = input.Length;
                Console.Write(input);
            }

            ConsoleKeyInfo key = Console.ReadKey(true);
            while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape)
            {
                if (key.Key == ConsoleKey.Backspace && pos > 0)
                {
                    buffer.Remove(--pos, 1);
                    Console.CursorLeft--;
                    Console.Write(buffer.ToString(pos, buffer.Length - pos) + ' ');
                    Console.CursorLeft = left + pos;
                } else if (IsInputChar(key.KeyChar))
                {
                    buffer.Insert(pos++, key.KeyChar);
                    Console.Write(buffer.ToString(pos - 1, buffer.Length - pos + 1));
                    Console.CursorLeft = left + pos;
                } else if (key.Key == ConsoleKey.LeftArrow && pos > 0)
                {
                    Console.CursorLeft--; pos--;
                } else if (key.Key == ConsoleKey.RightArrow && pos < buffer.Length)
                {
                    Console.CursorLeft++; pos++;
                }
                key = Console.ReadKey(true);
            }

            if (key.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                value = buffer.ToString();
                return true;
            }
            return false;
        }

        public static string ReadLine_pattern(string pattern, string input = "")
        {
            string v = input;
            ReadLine_pattern(ref v, pattern, input);
            return v;
        }
        /// <summary>
        /// \. - любой символ <br/>
        /// \d - число <br/>
        /// \D - число или пробел <br/>
        /// \w - буква/число <br/>
        /// \\ = \ <br/>
        /// Остальные символы - неизменяемые
        /// </summary>
        /// <param name="value"></param>
        /// <param name="pattern"></param>
        /// <returns>esc => false | enter => true</returns>
        public static bool ReadLine_pattern(ref string value, string pattern, string input = "")
        {
            int left = Console.CursorLeft;

            StringBuilder buffer = new StringBuilder();
            string patt = "";
            List<int> muts = new List<int>();

            char[] sc = new char[] { '.', 'd', 'D', 'w', 'c' };
            for (int i = 0; i < pattern.Length; i++)
            {
                if (pattern[i] == '\\' && i + 1 < pattern.Length && sc.Contains(pattern[i + 1]))
                {
                    buffer.Append(' ');
                    patt += pattern[i + 1];
                    muts.Add(patt.Length - 1);
                    i += 1;
                } else
                {
                    patt += pattern[i];
                    buffer.Append(pattern[i]);
                }
            }
            int len = muts.Count;
            if (len == 0) { value = patt; return true; }
            int pos = muts[0];

            bool check(char c, char pattC)
            {
                switch (pattC)
                {
                    case '.': return true;
                    case 'd': return Regex.IsMatch(c.ToString(), @"\d");
                    case 'D': return c == ' ' || Regex.IsMatch(c.ToString(), @"\d");
                    case 'w': return Regex.IsMatch(c.ToString(), @"\w");
                }
                return false;
            }
            char pdefault(char pc)
            {
                switch (pc)
                {
                    case 'd': return '0';
                }
                return ' ';
            }

            if (input != "" && input.Length <= patt.Length)
            {
                foreach (int mi in muts) {
                    if (mi >= input.Length) break;
                    if (check(input[mi], patt[mi]))
                        buffer[mi] = input[mi];
                }
            }

            Console.Write(buffer.ToString());

            Console.CursorLeft = left + pos;

            ConsoleKeyInfo key = Console.ReadKey(true);
            while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape)
            {
                if (key.Key == ConsoleKey.Backspace && pos > 0)
                {
                    buffer[muts[--pos]] = pdefault(patt[muts[pos]]);
                    Console.CursorLeft = left + muts[pos];
                    Console.Write(buffer.ToString(muts[pos], 1));
                    Console.CursorLeft--;
                } else if (pos < muts.Count && IsInputChar(key.KeyChar))
                {
                    if (check(key.KeyChar, patt[muts[pos]]))
                    {
                        buffer[muts[pos++]] = key.KeyChar;
                        Console.Write(buffer.ToString(muts[pos - 1], 1));
                        Console.CursorLeft = left + (pos == len ? muts[pos - 1] + 1 : muts[pos]);
                    }
                } else if (key.Key == ConsoleKey.LeftArrow && pos > 0)
                {
                    Console.CursorLeft = left + muts[--pos];
                } else if (key.Key == ConsoleKey.RightArrow && pos < muts.Count - 1)
                {
                    Console.CursorLeft = left + muts[++pos];
                }
                key = Console.ReadKey(true);
            }

            if (key.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                value = buffer.ToString();
                return true;
            }
            return false;
        }

        public class Param
        {
            public string Name,
                          Value,
                          Pattern;
            public bool Require;

            public Param(string name, string value, string pattern = "", bool require = false)
            {
                this.Name = name;
                this.Value = value;
                this.Pattern = pattern;
                this.Require = require;
            }

        }
        public static void EditParams(List<Param> paramList)
        {
            int selectInd = 0;
            int top = Console.CursorTop;
            int count = paramList.Count + 1;
            Console.Write(paramList.Aggregate("", (acc, par) => acc += $"  {par.Name}: {par.Value}\n") + "  Сохранить\n");
            ConsoleKeyInfo info;

            void setSel() { if (selectInd < count - 1) Console.CursorLeft = paramList[selectInd].Name.Length + 4 + paramList[selectInd].Value.Length; else Console.CursorLeft = 0; };
            void select(int ind)
            {
                Console.SetCursorPosition(0, top + selectInd);
                Console.CursorLeft = 0;
                Console.Write($" ");
                Console.SetCursorPosition(0, top + ind);
                Console.Write($">");
                selectInd = ind;
                setSel();
            }
            bool end()
            {
                int? req = null;
                for (int i = 0; i < paramList.Count; i++)
                    if (paramList[i].Require && paramList[i].Value == "")
                    { req = i; break; }
                if (req != null)
                {
                    select((int)req);
                    return false;
                } else
                {
                    Console.CursorTop = top + count + 1;
                    return true;
                }
            }

            select(0);

            while (true)
            {
                info = Console.ReadKey(true);

                if (info.Key == ConsoleKey.DownArrow)
                {
                    if (selectInd + 1 < count)
                        select(selectInd + 1);
                    else
                        select(0);

                } else if (info.Key == ConsoleKey.UpArrow)
                {
                    if (selectInd > 0)
                        select(selectInd - 1);
                    else
                        select(count - 1);

                } else if (info.Key == ConsoleKey.Enter)
                {
                    if (selectInd == count - 1)
                    {
                        if (end()) return;
                    } else
                    {
                        Param p = paramList[selectInd];
                        Console.CursorLeft = paramList[selectInd].Name.Length + 4;

                        if (p.Pattern == "") p.Value = ReadLine_esc(p.Value);
                        else p.Value = ReadLine_pattern(p.Pattern, p.Value);
                        select(selectInd);
                    }
                } else if (info.Key == ConsoleKey.Escape) if (end()) return;
                
                setSel();
            }
        }
    }
}
