using System;
using System.Collections.Generic;
using System.Text;

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
            var strNumSystem = InputWithCheck.CheckAndReturnSs();
            var numSystem = Convert.ToInt32(strNumSystem);

            var num1 = InputWithCheck.CheckAndReturnNumber(numSystem);
            var num2 = InputWithCheck.CheckAndReturnNumber(numSystem);

            var shortNum = GetShortNumber(num1, num2);
            var longNum = GetLongNumber(num1, num2);

            var diff = Math.Abs(longNum.Length - shortNum.Length);

            var shortNumList = AddZeros(shortNum, diff);
            var longNumList = Converter.ToNumList(longNum);

            Console.Clear();
            Output.PrintExpressionInCenter(longNumList, '+', shortNumList);
            
            Calculation(longNumList, shortNumList, numSystem);
        }

        public static void Subtraction()
        {
            var strNumSystem = InputWithCheck.CheckAndReturnSs();
            var numSystem = Convert.ToInt32(strNumSystem);

            var num1 = InputWithCheck.CheckAndReturnNumber(numSystem);
            var num2 = InputWithCheck.CheckAndReturnNumber(numSystem);

            var numList1 = new List<int> {} ;
            var numList2 = new List<int> {} ;
            
            var diff = num1.Length - num2.Length;
            if (diff < 0)
            {
                numList1 = AddZeros(num1, Math.Abs(diff));
                numList2 = Converter.ToNumList(num2);
            }
            else
            {
                numList2 = AddZeros(num2, diff);
                numList1 = Converter.ToNumList(num1);
            }

            bool minus = false;
            
            Console.Clear();
            Output.PrintAlphabet();
            
            if (!Check.IsList1BiggerThanList2(num1, num2, numSystem))
            {
                minus = true;
                var list = numList1;
                numList1 = numList2;
                numList2 = list;
                Output.PrintColorfulText(2, "Если первое число меньше второго, то нужно поменять их местами" +
                                            " и сделать вычитание первого из второго, поставив минус перед результатом");
            }
            else
            {
                numList1 = Converter.ToNumList(num1);
                numList2 = Converter.ToNumList(num2);
            }
            Output.PrintExpressionInCenter(numList1, '-', numList2);
            
            var result = new List<int> { };
            var add = 0;
            
            for (int i = numList1.Count - 1; i >= 0; i--)
            {
                var tempRes = numList1[i] - numList2[i];
                if (tempRes >= 0)
                {
                    result.Add(tempRes + add);
                    Output.PrintColorfulText(1, "Если верхняя цифра больше нижней," +
                                                " то просто вычитаем верхнее из нижнего");
                    Output.PrintColorfulText(2, $"верхняя цифра({numList1[i]}) - нижняя цифра({numList2[i]}) " +
                                                $"= {tempRes}");
                }
                else
                {
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (numList1[i + j] != 0)
                        {
                            numList1[i + j]--;
                            tempRes = numSystem + numList1[i] - numList2[i];
                        }
                    }

                    result.Add(tempRes + add);
                    add--;
                    
                    Output.PrintColorfulText(1, "Если верхняя цифра меньше нижней, то занимаем из " +
                                                "разряда старше единицу, складываем ее с верхним числом и вычитаем " +
                                                "из этого нижнее число ");
                    Output.PrintColorfulText(1, "Не забываем о занятом числе в следующей цифре");
                    Output.PrintColorfulText(2, $"Занятый разряд({numSystem}) + верхняя цифра({numList1[i]}) - нижняя цифра({numList2[i]}) " +
                                                $"= {tempRes}");
                }
            }

            result.Reverse();

            var strResult = GetNumInSS(result);
            if (minus)
                string.Concat("-", strResult);
            Console.WriteLine("Результат: " + strResult);
        }

        public static void Multiply()
        {
            
        }
    }
}