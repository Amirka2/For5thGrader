using System;
using System.Collections.Generic;
using System.Linq;

namespace For5thGrader
{
    public class Converter
    {
        enum Alphabet
        {
            A = 10, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z, //26 C
            a, b, c, d, e, f, g, h, i, j, k, l, m, n //14
        }

        public static List<int> ToNumList(string num)
        {
            var listNum = new List<int> { };
            foreach (var el in num)
            {
                if (el > '9')
                {
                    var elStr = Convert.ToString(el);
                    listNum.Add((int)Enum.Parse(typeof(Alphabet), elStr));
                }
                else if (el >= '0' && el <= '9')
                {
                    listNum.Add(el - '0');
                }
            }

            return listNum;
        }

        public static void FromAnyToAny()                                        // 1 Task
        {
            var strNumSystem1 = InputWithCheck.CheckAndReturnSs("Введите начальную систему счисления: ");
            int numSystem1 = Convert.ToInt32(strNumSystem1);
            
            var num = InputWithCheck.CheckAndReturnNumber(numSystem1);

            var strNumSystem2 = InputWithCheck.CheckAndReturnSs("Введите конечную систему счисления: ");
            int numSystem2 = Convert.ToInt32(strNumSystem2);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Для перевода из любой системы счисления в любую другую, нужно перевести число в десятичную систему, а потом из десятичной в нужную");
            
            int number = FromAnyTo10(num, numSystem1, true); 
            var result = From10ToAny(number, numSystem2);
        }                                    

        public static int FromAnyTo10(string num, int numSystem, bool check)
        {
            var number = ToNumList(num);
            Console.ForegroundColor = ConsoleColor.Blue;
            if (check)
                Output.FromAnyTo10Text1();

            var result = 0;
            for (int i = number.Count - 1, j = 0; i >= 0; i--, j++)
            {
                if (check)
                    Console.WriteLine($"Результат = {result} + {number[j]} * {numSystem} ^ {i} = {number[j] * (int)Math.Pow(numSystem, i)}");
                result += number[j] * (int)Math.Pow(numSystem, i);
            }
            if (check)
                Console.WriteLine($"Складываем \nИтог: {result}");

            return result;
        }             // 1 Task
        
        public static List<int> From10ToAny(int num, int numSystem)
        {
            var result = new List<int>{};

            Console.ForegroundColor = ConsoleColor.Yellow;
            while (num != 0)
            {
                var tempRes = num / numSystem;
                var remainder = num % numSystem;
                Console.WriteLine($"{num} / {numSystem} = {tempRes} + остаток {remainder}");
                result.Add(remainder);
                
                num /= numSystem;
            }

            result.Reverse();
            Console.Write($"Теперь записываем остатки в обратной последовательности \nПолучаем конечный результат: ");
            foreach (var el in result)
            {
                Console.Write(el);
            }
            Console.WriteLine();
            
            return result;
        }            // 1 Task

        static List<int> GetFractionalPart(int num, int numSystem)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string zero = "0,";
            var strNum = Convert.ToString(num);
            string strFract = string.Concat(zero, strNum);
            var fract = Convert.ToDouble(strFract);
            var result = new List<int> { };
            var count = 0;

            while ((fract != 0) || (count <= 8))
            {
                Console.WriteLine($"Умножаем число после запятой на основание системы: {fract} * {numSystem}");
                fract *= numSystem;
                Console.WriteLine($"Дробная часть: {fract}");

                var res = Convert.ToString(fract).Split(',');
                Console.WriteLine($"Записываем {res[0]}");
                result.Add(Convert.ToInt32(res[0]));

                if (fract >= 1)
                {
                    fract -= (int) fract;
                }

                count++;
            }
            
            Console.ResetColor();

            return result;
        }                // 3 Task
        
        public static void RealNumber()
        {
            var num = InputWithCheck.CheckAndReturnNumber(10, "Введите число в десятичной системе счисления: ");
            
            var strNumSystem = InputWithCheck.CheckAndReturnSs("Введите желаемую систему счисления: ");
            var numSystem = Convert.ToInt32(strNumSystem);

            string[] numParts = num.Split(',', '.');

            int beforeDot = 0, afterDot = 0;


            if (!Check.IsRealNumber(num))
                RealNumber();
            else
            {
                beforeDot = Convert.ToInt32(numParts[0]);
                afterDot = Convert.ToInt32(numParts[1]);
            }

            Console.WriteLine("Для перевода вещественного числа в 10 СС, нужно отдельно перевести целую часть, а затем дробную:");
            
            var listBeforeDot = From10ToAny(beforeDot, numSystem);

            var listAfterDot = GetFractionalPart(afterDot, numSystem);
            
            Console.Write("Результат: ");

            Output.PrintRealNumber(listBeforeDot, listAfterDot);
        }                                       // 3 Task
    }
}