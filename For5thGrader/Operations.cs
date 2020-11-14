using System;
using System.Collections.Generic;

namespace For5thGrader
{
    public class Operations
    {
        enum Alphabet
        {
            A = 10, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z,
            a, b, c, d, e, f, g, h, i, j, k, l, m, n
        }
        
        public static string GetShortNumber(string num1, string num2)
        {
            string res;
            if (num1.Length > num2.Length)
                res = num2;
            else
                res = num1;
            return res;
        }
        
        public static string GetLongNumber(string num1, string num2)
        {
            string res;
            if (num1.Length <= num2.Length)
                res = num2;
            else
                res = num1;
            return res;
        }
        
        public static List<int> AddZeros(string num, int diff)
        {
            var list = new List<int> { };
            for (int i = 0; i < diff; i++)
            {
                list.Add(0);
            }
            list.AddRange(Converter.ToNumList(num));
            
            return list;
        }

        public static string GetNumInSS(List<int> num)
        {
            string result = String.Empty;
            foreach (var el in num)
            {
                if (el > 9)
                {
                    result = string.Concat(result, Enum.GetName(typeof(Alphabet), el));
                }
                else
                {
                    result = string.Concat(result, Convert.ToString(el));
                }
            }

            return result;
        }

        static void Calculation(List<int> num1, List<int> num2, int numSystem)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            var expression = new List<int> { };
            var add = 0;

            for (int i = num1.Count - 1; i >= 0; i--)
            {
                var temp = num1[i] + num2[i] + add;
                Console.WriteLine($"Промежуточный результат: {num1[i]} + {num2[i]} + {add} = {temp}");
                if (temp >= numSystem)
                {
                    var strNum = Convert.ToString(temp);
                    add = Convert.ToInt32(strNum[0] - '0');
                    expression.Add(Convert.ToInt32(strNum[1] - '0'));
                    Console.WriteLine($"Записываем {strNum[1]}, переносим {add} в следующий разряд");
                }
                else
                {
                    expression.Add(temp);
                    Console.WriteLine($"Записываем {temp}");
                }
            }
            expression.Reverse();

            var result = GetNumInSS(expression);
            Console.WriteLine("Результат: " + result);
        }
        
        public static void Addition()
        {
            var StrNumSystem = InputWithCheck.CheckAndReturnSs();
            var numSystem = Convert.ToInt32(StrNumSystem);

            var num1 = InputWithCheck.CheckAndReturnNumber(numSystem);
            var num2 = InputWithCheck.CheckAndReturnNumber(numSystem);

            var shortNum = GetShortNumber(num1, num2);
            var longNum = GetLongNumber(num1, num2);

            var diff = Math.Abs(longNum.Length - shortNum.Length);

            var shortNumList = AddZeros(shortNum, diff);
            var longNumList = Converter.ToNumList(longNum);

            Output.PrintExpressionInCenter(longNumList, '+', shortNumList);
            
            Calculation(longNumList, shortNumList, numSystem);
        }

        public static void Subtraction()
        {
            var numSystem = InputWithCheck.CheckAndReturnSs();
            
            var num1 = InputWithCheck.CheckAndReturnNumber(Convert.ToInt32(numSystem));
            var num2 = InputWithCheck.CheckAndReturnNumber(Convert.ToInt32(numSystem));

            var numList1 = Converter.ToNumList(num1);
            var numList2 = Converter.ToNumList(num1);

            
        }

        public static void Multiply()
        {
            
        }
    }
}