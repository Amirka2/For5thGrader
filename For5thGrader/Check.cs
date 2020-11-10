using System;
using System.Linq;
using static System.Enum;
using static System.Convert;

namespace For5thGrader
{
    public class Check
    {
        enum Alphabet
        {
            A = 10, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z,
            a, b, c, d, e, f, g, h, i, j, k, l, m, n
        }
        
        public static bool NumInSS(string num, int numSys)
        {
            var numList = Converter.ToNumList(num);
            foreach (var el in numList)
            {
                if (el >= numSys)
                    return false;
            }

            return true;
        }

        public static bool SS(int numSystem)
        {
            if (numSystem > 50 || numSystem < 2)
            {
                Console.WriteLine("Система счисления не удовлетворяет условию (2-50)");
                return false;
            }            
            
            return true;
        }

        public static bool Number(string num)
        {
            foreach (var el in num)
            {
                if (el > '9')
                {
                    //var elStr = Convert.ToString(el);
                   // int n = (int) Enum.Parse(typeof(Alphabet), elStr);
                }            
            }

            return true;

        }

        public static bool IsRealNumber(string num)
        {
            if (!double.TryParse(num, out double c) || (!num.Contains(',')))
            {
                Console.WriteLine("Число не соответствует типу с плавающей запятой!");
                return true;
            }
            return false;
        }
    }
}