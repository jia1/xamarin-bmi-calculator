using System.Text;
using System;

namespace Core
{
    public static class BmiCalculator
    {
        public static string Calculate(string h, string w)
        {
            double height, weight, bmi;
            if (string.IsNullOrWhiteSpace(h) || string.IsNullOrWhiteSpace(w))
            {
                return "Please fill in the blank(s)!";
            }
            else
            {
                height = double.Parse(h);
                weight = double.Parse(w);
                bmi = weight / Math.Pow(height, 2);
                return bmi.ToString();
            }
        }
    }
}