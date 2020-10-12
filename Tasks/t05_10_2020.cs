using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    class T05_10_2020
    {

        public static void T1_4()
        {
            helper.WriteCenter("*Ср. арифметическое интервала*\n");
            int size = helper.ask("Введите размер массива: ");
            int[] arr = new int[size];
            helper.ArrayFillRnd(ref arr, max: 10);
            Console.WriteLine(helper.ArrayToStr(arr));

            int from = helper.ask("\nВведите интервал:\n от: ") - 1;
            int to = helper.ask(" до: ") - 1;

            int count = to - from + 1;
            int sum = 0;
            for (int i = from; i <= to; i++) sum += arr[i];
            double arithmeticMean = sum / (double)count;

            Console.WriteLine($"\nСр. арифметическое интервала [{from + 1}; {to + 1}] = {arithmeticMean}");
        }
        public static void T2_4()
        {
            helper.WriteCenter("*Удаление элементов с чётными номерами*\n");
            int size = helper.ask("Введите размер массива (>2): ", n => n > 2);
            int[] arr = new int[size];
            helper.ArrayFillRnd(ref arr, max: 100);
            Console.WriteLine(helper.ArrayToStrIndB(arr));

            int newSize = size / 2;
            int[] arr2 = new int[newSize];
            //for (int ind = 0, i = 1; i <= arr2.Length; ind++, i += 2) arr2[ind] = arr[i];
            for (int i = 0; i < newSize; i++) arr2[i] = arr[i * 2 + 1];

            Console.WriteLine($"> {helper.ArrayToStr(arr2)}");
        }
        public static void T3_4()
        {
            helper.WriteCenter("*Произведение элементов массива, расположенных между первым и вторым нулевыми элементами*\n");
            int[] arr = helper.FillArr();
            Console.WriteLine(helper.ArrayToStr(arr));

            int mul = 1;

            int ind = 0;
            for (; arr[ind] != 0; ind++) { };
            int from = ind;
            for (ind++; arr[ind] != 0; ind++) mul *= arr[ind];
            int to = ind;

            Console.WriteLine($"Произведение элементов отрезка [{from + 1}; {to + 1}] = {mul}");
        }
        public static void T4_4()
        {
            helper.WriteCenter("*Переписать в новый массив все элементы с нечетными порядковыми номерами*\n");
            int size = helper.ask("Введите размер массива (<15): ", n => n < 15);
            int[] A = new int[size];
            helper.ArrayFillRnd(ref A, max: 100);
            Console.WriteLine(helper.ArrayToStrIndB(A));

            int newSize = size / 2;
            int[] B = new int[newSize];
            //for (int ind = 0, i = 1; i <= arr2.Length; ind++, i += 2) arr2[ind] = arr[i];
            for (int i = 0; i < newSize; i++) B[i] = A[i * 2 + 1];

            Console.WriteLine($"\n> {helper.ArrayToStr(B)}\n  размер: {newSize}");
        }

        class Tree
        {
            int key;
            Tree left, right;

            public Tree(int key) => this.key = key;

            public void Add(Tree t)
            {
                if (t.key <= key)
                {
                    if (left == null) left = t;
                    else left.Add(t);
                }
                else
                {
                    if (right == null) right = t;
                    else right.Add(t);
                }
            }

            public int[] Traverse(List<int> list = null)
            {
                if (list == null) list = new List<int>();
                if (left != null) left.Traverse(list);
                list.Add(key);
                if (right != null) right.Traverse(list);

                return list.ToArray();
            }
        }
        public static int[] TreeSort(int[] arr)
        {
            Tree main = new Tree(arr[0]);
            for (int i = 1; i < arr.Length; i++) main.Add(new Tree(arr[i]));
            return main.Traverse();
        }

        public static int[] InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int key = arr[i];
                int j = i - 1;
                while (j >= 0 && key < arr[j])
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
            return arr;
        }

        public static int[] HalfDivSort(int[] arr)
        {
            int h = arr.Length / 2;

            while (h > 0)
            {
                for (int i = 0; i < arr.Length - h; i++)
                {
                    int j = i;

                    while (j >= 0)
                    {
                        if (arr[j] > arr[j + h])
                        {
                            int tmp = arr[j];
                            arr[j] = arr[j + h];
                            arr[j + h] = tmp;
                            j = j - h; 
                            Console.WriteLine($">> {helper.ArrayToStr(arr)}");
                        }
                        else j--;
                    }
                   
                }
                h = h / 2;
            }

            return arr;
        }

        public static int[] BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                for (int j = i + 1; j < arr.Length; j++)
                    if (arr[i] > arr[j])
                    {
                        int t = arr[i];
                        arr[i] = arr[j];
                        arr[j] = t;
                    }
            return arr;
        }
        public static void T5_4()
        {
            helper.WriteCenter("*Сортировка с помощью дерева / с помощью вставок*\n");
            int[] arr = new int[] { };
            switch (helper.Choice(new string[] { "заполнение вручную", "ввод размера и заполнение рандомными числами" }))
            {
                case 0: Console.WriteLine(); arr = helper.FillArr(); break;
                case 1:
                    int size = helper.ask("\nВведите размер массива: ");
                    arr = new int[size];
                    helper.ArrayFillRnd(ref arr, max: 100);
                    break;
            }
            Console.WriteLine(helper.ArrayToStr(arr));

            int[] sorted;
            switch (3)
            {
                case 1: sorted = TreeSort(arr); break;
                case 2: sorted = InsertionSort(arr); break;
                case 3: sorted = HalfDivSort(arr); break;
                case 4: sorted = BubbleSort(arr); break;
            }
            Console.WriteLine($"\n> {helper.ArrayToStr(sorted)}");
        }

        public static void T6_4()
        {
            helper.WriteCenter("*Для каждого столбца матрицы найти произведение его элементов*\n");

            int x = helper.ask("\nВведите размер матрицы:\n x: ");
            int y = helper.ask(" y: ");

            int[,] matrix = new int[y,x];
            helper.MatrixFillRnd(ref matrix, max: 20);

            Console.WriteLine('\n' + helper.MatrixToStrB(matrix) + '\n');

            for (int i = 0; i < x; i++)
            {
                int[] col = new int[y];
                long mul = 1;
                for (int j = 0; j < y; j++)
                {
                    col[j] = matrix[j, i];
                    mul *= col[j];
                }

                Console.WriteLine($"{i}: {helper.ArrayToStr(col)} ** = {mul}");
            }
        }
        public static void T7_4()
        {
            helper.WriteCenter("*Поменять местами минимальный и максимальный элемент в каждом столбце*\n");

            int x = helper.ask("\nВведите размер матрицы:\n x: ");
            int y = helper.ask(" y: ");

            int[,] matrix = new int[y,x];
            helper.MatrixFillRnd(ref matrix, max: 20);

            Console.WriteLine('\n' + helper.MatrixToStrB(matrix) + '\n');

            for (int i = 0; i < x; i++)
            {
                int min = matrix[0, i],
                    minIndex = 0,
                    max = matrix[0, i],
                    maxIndex = 0;

                for (int j = 0; j < y; j++)
                {
                    int val = matrix[j, i];
                    
                    if (val < min)
                    {
                        min = val;
                        minIndex = j;
                    }
                    if (val > max)
                    {
                        max = val;
                        maxIndex = j;
                    }
                }

                int temp = min;
                matrix[minIndex, i] = max;
                matrix[maxIndex, i] = min;
            }

            Console.WriteLine(helper.MatrixToStrB(matrix) + '\n');
        }
        public static void T8_4()
        {
            helper.WriteCenter("*Найти сумму элементов каждой ее диагонали, параллельной побочной*\n");

            int a = helper.ask("\nВведите размер квадратной матрицы:\n x: ", s => s > 0);

            int[,] matrix = new int[a,a];
            helper.MatrixFillRnd(ref matrix, max: 20);

            Console.WriteLine('\n' + helper.MatrixToStrB(matrix) + '\n');

            for (int i = 0; i < a; i++)
            {
                int[] col = new int[i + 1];
                int sum = 0;
                for (int x = 0, y = i; y >= 0; x++, y--)
                {
                    col[x] = matrix[y, x];
                    sum += col[x];
                }

                Console.WriteLine($"{i}: {helper.ArrayToStr(col)} ++ = {sum}");
            }
            for (int i = 1; i < a; i++)
            {
                int[] col = new int[a - i];
                int sum = 0;
                for (int x = i, y = a - 1; x < a; x++, y--)
                {
                    col[x - i] = matrix[y, x];
                    sum += col[x - i];
                }

                Console.WriteLine($"{i + a}: {helper.ArrayToStr(col)} ++ = {sum}");
            }

            /*for (int row = 0; row < 2 * a - 1; ++row)
            {
                int sum = 0;
                int[] acol = new int[row+ 1];
                for (int col = 0; col <= row; ++col)
                {
                    if (col < a && row - col < a)
                    {
                        sum += matrix[col, row - col];
                        acol[col] = matrix[col, row - col];
                    }
                }
                Console.WriteLine($"{row}: {helper.ArrayToStr(acol)} ++ = {sum}");
            }*/
        }

        public static int[] MaxMuls(int n) // [0] <= [1]
        {
            for (int i = (int)Math.Sqrt(n); i > 0; i--)
                if (n % i == 0)
                    return new int[] { i, n / i };
            return new int[] { 1, n };
        }

        public static void T9_4()
        {
            helper.WriteCenter("*сформировать из одномерного массива двухмерный м. отсортированный змейкой начиная с правого верхнего угла горизонтально*\n");
            int size = helper.ask("Введите размер массива: ");
            int[] arr = new int[size];
            helper.ArrayFillRnd(ref arr, max: 100);
            Console.WriteLine(helper.ArrayToStr(arr));

            arr = InsertionSort(arr);

            Console.WriteLine($"> {helper.ArrayToStr(arr)}");

            int[] xy = MaxMuls(arr.Length);
            int xl = xy[1],
                yl = xy[0];
            int[,] mat = new int[yl, xl];

            for (int y = 0; y < yl; y++)
            {
                if (y % 2 == 0)
                    for (int x = xl - 1; x >= 0; x--)
                        mat[y, x] = arr[xl * y + (xl - 1 - x)];
                else
                    for (int x = 0; x < xl; x++)
                        mat[y, x] = arr[xl * y + x];
            }

            Console.WriteLine('\n' + helper.MatrixToStrB(mat) + '\n');
        }

        public static void T10_4()
        {
            helper.WriteCenter("*сформировать из одномерного массива двухмерный, отсортированный по спирали начиная с правого верхнего угла горизонтально*\n");
            int size = helper.ask("Введите размер массива: ");
            int[] arr = new int[size];
            helper.ArrayFillRnd(ref arr, max: 100);
            Console.WriteLine(helper.ArrayToStr(arr));

            arr = InsertionSort(arr);

            Console.WriteLine($"> {helper.ArrayToStr(arr)}");

            int[] xy = MaxMuls(arr.Length);
            int xl = xy[1],
                yl = xy[0];
            int[,] mat = new int[yl, xl];

            int endPoint_y =
                yl <= xl ?
                    yl / 2
                :
                    xl % 2 == 0 ?
                        xl / 2
                    :
                        yl - 1 - xl / 2;
            int endPoint_x =
                yl <= xl ?
                    yl % 2 == 0 ?
                        xl - 1 - (yl / 2 - 1)
                    :
                        yl / 2
                :
                    xl / 2;


            int ind = 0;
            for (int h = 0, x = xl, y = 0; ; h++)
            {
                for (x--; x >= h; x--) mat[y, x] = arr[ind++]; if (x < h) x++;
                for (y++; y < yl - h; y++) mat[y, x] = arr[ind++]; if (y >= yl - h) y--;
                for (x++; x < xl - h; x++) mat[y, x] = arr[ind++]; if (x >= xl - h) x--;
                for (y--; y > h; y--) mat[y, x] = arr[ind++]; if (y <= h) y++;
                if (y == endPoint_y && x == endPoint_x) break;
            }

            Console.WriteLine('\n' + helper.MatrixToStrB(mat) + '\n');
        }

        public static void Main_()
        {
            while (true)
            {
                int sel = helper.ask("Введите задание (0 - выход): ");
                if (sel == 0) break;
                switch (sel)
                {
                    case 1: T1_4(); break;
                    case 2: T2_4(); break;
                    case 3: T3_4(); break;
                    case 4: T4_4(); break;
                    case 5: T5_4(); break;
                    case 6: T6_4(); break;
                    case 7: T7_4(); break;
                    case 8: T8_4(); break;
                    case 9: T9_4(); break;
                    case 10: T10_4(); break;
                    default: Console.WriteLine("Такого задания не существует"); break;
                }
                Console.WriteLine();
            }
        }
    }
}
