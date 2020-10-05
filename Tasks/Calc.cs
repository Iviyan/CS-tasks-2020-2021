using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    public static class Calc
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
    }
}
