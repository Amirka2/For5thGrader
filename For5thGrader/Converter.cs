using System;
using System.Collections.Generic;

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
        
        public static List<int> AddZeros(List<int> list, int count)
        {
            list.Reverse();
            for (int i = 0; i < count; i++)
            {
                list.Add(0);
            }

            list.Reverse();
            return list;
        }

        public static void FromAnyToAny()
        {
            Console.Write("Введите начальную систему счисления: ");
            var strNumSystem1 = Console.ReadLine();
            while (string.IsNullOrEmpty(strNumSystem1))
            {
                FromAnyToAny();
            }
            int numSystem1 = Convert.ToInt32(strNumSystem1);
            
            Console.Write("Введите число: ");
            var num = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(num))
            {
                Console.WriteLine("Ошибка ввода!");
                FromAnyToAny();
            }
            else if (!Check.SS(num, numSystem1) || !Check.Number(num))
            {
                Console.WriteLine("Число не подходит данной системе счисления! \nВведите заново");
                FromAnyToAny();
            }
            
            Console.Write("Введите желаемую систему счисления: ");
            var strNumSystem2 = Console.ReadLine();
            while (string.IsNullOrEmpty(strNumSystem2))
            {
                strNumSystem2 = Console.ReadLine();
            }
            int numSystem2 = Convert.ToInt32(strNumSystem2);
            while (numSystem2 > 50 || numSystem2 < 2)
            {
                Console.WriteLine("Система счисления не поддерживается! \nВведите другую (2-50)");
                numSystem2 = Convert.ToInt32(Console.ReadLine());
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Для перевода из любой системы счисления в любую другую, нужно перевести число в десятичную систему, а потом из десятичной в нужную");
            
            int number = FromAnyTo10(num, numSystem1); 
            var result = ConvertFrom10ToAny(number, numSystem2);
        }                                    // 1 Task

        public static int FromAnyTo10(string num, int numSystem)
        {
            var number = ToNumList(num);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Для перевода числа из любой системы счисления в десятичную достаточно " +
                              "пронумеровать его разряды, начиная с нулевого " +
                              "\nТеперь найдём сумму произведений цифр числа на основание системы счисления в степени позиции этой цифры:");

            var result = 0;
            for (int i = number.Count - 1, j = 0; i >= 0; i--, j++)
            {
                Console.WriteLine($"Результат = {result} + {number[j]} * {numSystem} ^ {i} = {number[j] * (int)Math.Pow(numSystem, i)}");
                result += number[j] * (int)Math.Pow(numSystem, i);
            }
            Console.WriteLine($"Складываем \nИтог: {result}");

            return result;
        }             // 1 Task
        
        public static List<int> ConvertFrom10ToAny(int num, int numSystem)
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
            
            return result;
        }    // 1 Task
        
        public static void RealNumber()
        {
            Console.Write("Введите число в десятичной системе счисления: ");
            var num = Console.ReadLine();
            while (!Check.Is10Number(num))
                num = Console.ReadLine();
            
        }
    }
}