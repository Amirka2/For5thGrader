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
            Console.Write("Введите систему счисления: ");
            var numSystem = Convert.ToInt32(Console.ReadLine());
            while (!Check.SS(numSystem))
                numSystem = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Введите 1 число: ");
            var num1 = Console.ReadLine();
            while (!Check.NumInSS(num1, numSystem))
                num1 = Console.ReadLine();
            
            Console.Write("Введите 2 число: ");
            var num2 = Console.ReadLine();
            while (!Check.NumInSS(num2, numSystem))
                num2 = Console.ReadLine();

            var shortNum = GetShortNumber(num1, num2);
            var longNum = GetLongNumber(num1, num2);

            var diff = (int) Math.Abs(longNum.Length - shortNum.Length);

            var shortNumList = AddZeros(shortNum, diff);
            var longNumList = Converter.ToNumList(longNum);

            Console.Clear();
            Console.SetCursorPosition(80, 3);
            foreach (var el in longNumList)
                Console.Write(el + " ");
            Console.SetCursorPosition(79, 4);
            Console.WriteLine("+");
            Console.SetCursorPosition(80, 5);
            foreach (var el in shortNumList)
                Console.Write(el + " ");
            Console.WriteLine();
            
            Calculation(longNumList, shortNumList, numSystem);
        }

        public static void Subtraction()
        {
            Console.Write("Введите систему счисления: ");
            var numSystem = Console.ReadLine();
            while (!Check.SS(Convert.ToInt32(numSystem)) || string.IsNullOrWhiteSpace(numSystem))
                numSystem = Console.ReadLine();
            
            Console.Write("Введите систему счисления: ");
            var num1 = Console.ReadLine();
            while (!Check.NumInSS(num1, Convert.ToInt32(numSystem)) || string.IsNullOrWhiteSpace(num1))
                num1 = Console.ReadLine();
            
            Console.Write("Введите систему счисления: ");
            var num2 = Console.ReadLine();
            while (!Check.NumInSS(num2, Convert.ToInt32(numSystem)) || string.IsNullOrWhiteSpace(num2))
                num2 = Console.ReadLine();
        }

        public static void Multiply()
        {
            
        }
    }
}