
using System;
using System.Linq;

namespace Tasks
{
    class T21_09_2020
    {
        static int Choice(string[] list)
        {
            int select = 0;
            int pos = Console.CursorTop;
            int posEnd = pos + list.Length - 1;
            Console.Write(list.Aggregate("> ", (acc, str) => acc += str + '\n'));
            Console.SetCursorPosition(0, pos);
            ConsoleKeyInfo info;

            while (true)
            {
                info = Console.ReadKey();
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

                } else if (info.Key == ConsoleKey.Enter) { Console.CursorTop = posEnd+1; return select; }
            }
            return 0;
        }

        public static void Main_()
        {
            int c = Choice(new string[] { "123", "234", "345" });
            Console.WriteLine($"Выбор: {c}");
        }
    }
}
