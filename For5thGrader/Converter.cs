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
            else if (!Check.NumInSS(num, numSystem1) || !Check.Number(num))
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
            var result = From10ToAny(number, numSystem2);
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
        }    // 1 Task

        static List<int> FractionalPart(int num, int numSystem)                // 3 Task
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
        }
        public static void RealNumber()
        {
            Console.Write("Введите число в десятичной системе счисления: ");
            var num = Console.ReadLine();
            while (Check.IsRealNumber(num) || string.IsNullOrWhiteSpace(num))
                num = Console.ReadLine();
            
            Console.Write("Введите желаемую систему счисления: ");
            var numSystem = Convert.ToInt32(Console.ReadLine());
            while (!Check.SS(numSystem) || string.IsNullOrWhiteSpace(numSystem.ToString()))
                numSystem = Convert.ToInt32(Console.ReadLine());

            string[] numParts = num.Split(',', '.');

            int beforeDot = 0, afterDot = 0;

            try
            {
                beforeDot = Convert.ToInt32(numParts[0]);
                afterDot = Convert.ToInt32(numParts[1]);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                RealNumber();
            }

            Console.WriteLine("Для перевода вещественного числа в 10 СС, нужно отдельно перевести целую часть, а затем дробную:");
            
            var listBeforeDot = From10ToAny(beforeDot, numSystem);

            var listAfterDot = FractionalPart(afterDot, numSystem);
            
            Console.Write("Результат: ");

            foreach (var el in listBeforeDot)
            {
                Console.Write(el);
            }
            Console.Write(".");
            foreach (var el in listAfterDot)
            {
                Console.Write(el);
            }
        }
    }
}