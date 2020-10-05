
using System;
using System.Linq;

namespace Tasks
{
    class T24_09_2020
    {
        static double sum(double a, double b) => a + b;
        static double sub(double a, double b) => a - b;
        static double mul(double a, double b) => a * b;
        static double div(double a, double b) => a / b;
        static double ln(double a) => Math.Log(a);
        static double lg(double a) => Math.Log10(a);
        static double pow(double a, double b) => Math.Pow(a, b);
        static double sin(double a) => Math.Sin(a);
        static double cos(double a) => Math.Cos(a);

        static double act(string act, double a, double b = 0)
        {
            switch (act)
            {
                case "+": return sum(a,b);
                case "-": return sub(a,b);
                case "*": return mul(a,b);
                case "/": return div(a,b);
                case "^": return pow(a,b);
                case "sin": return sin(a);
                case "cos": return cos(a);
                case "ln": return ln(a);
                case "lg": return lg(a);
                default: return 0;
            }
        }
        public static void Main_()
        {
            Console.WriteLine("Выберите действие:");
            string sel = helper.Choice_str(new string[] { "+", "-", "*", "/", "^", "sin", "cos", "ln", "lg" });
            double result;
            if ((new string[] { "+", "-", "*", "/", "^" }).Contains(sel))
            {
                double n1 = helper.read("Число 1: ");
                double n2 = helper.read("Число 2: ");
                result = act(sel, n1, n2);
            } else
            {
                double n1 = helper.read("Число: ");
                result = act(sel, n1);
            }

            
            Console.WriteLine($"= {result}");
        }
    }
}
