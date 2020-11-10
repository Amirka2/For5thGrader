using System;
using System.Linq;
using System.Collections.Generic;

namespace For5thGrader
{
    internal class Program
    {
        /*static void Stack()
        {
            Console.Write("Введите систему счисления:");
            var numSys = Console.ReadLine();
            Console.Write("\nВведите 1 число:");
            var num1 = Console.ReadLine();
            Console.Write("\nВведите 2 число:");
            var num2 = Console.ReadLine();

            var diff = Math.Abs(num1.Length - num2.Length);

            int longN = 0, shortN = 0;
            var n1List = ConvertFromEnum(num1);
            var n2List = ConvertFromEnum(num2);

            if (num2.Length > num1.Length)
            {
                longN = Convert.ToInt32(num2);
                shortN = Convert.ToInt32(num1);
                n1List = AddZeros(n1List, diff);

            }
            else if (num2.Length < num1.Length)
            {
                longN = Convert.ToInt32(num1);
                shortN = Convert.ToInt32(num2);
                n2List = AddZeros(n2List, diff);
            }

            Console.WriteLine(longN);                //вывод
            Console.WriteLine("+");
            for (int i = 0; i < diff; i++)
                Console.Write(" ");
            Console.WriteLine(shortN);

            var add = 0;
            var result = new List<int> { };
            for (int j = n1List.Count - 1; j >= 0; j--)
            {
                var res = 0;
                res += add + n1List[j] + n2List[j];
                if (res >= Convert.ToInt32(numSys))
                {
                    result.Add(Convert.ToInt32(res.ToString()[1]));
                    add = Convert.ToInt32(res.ToString()[0]);
                    Console.WriteLine($"res += {add} + {n1List[j]} + {n2List[j]} ");
                }
                else if (res < Convert.ToInt32(numSys))
                {
                    result.Add(res);
                    Console.WriteLine($"res += {add} + {n1List[j]} + {n2List[j]} ");
                }
            }
        }
        static void Stacking()
        {
            Console.WriteLine("Введите СС");
            var numSystem = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите 1 число");
            var x1Str = Console.ReadLine();
            Console.WriteLine("Введите 2 число");
            var x2Str = Console.ReadLine();

            string[] X1Convert = new string[x1Str.Length];
            for (int i = 0; i < x1Str.Length; i++)
            {
                if (((x1Str[i] >= 'A') && (x1Str[i] <= 'Z')) || ((x1Str[i] >= 'a') && (x1Str[i] <= 'n')))
                {
                    X1Convert[i] = CheckEnum(x1Str[i]).ToString();
                }
                else if (x1Str[i] >= '0' && x1Str[i] <= '9')
                {
                    X1Convert[i] = x1Str[i].ToString();
                }
            }
            
            string[] X2Convert = new string[x2Str.Length];
            for (int i = 0; i < x2Str.Length; i++)
            {
                if (((x2Str[i] >= 'A') && (x2Str[i] <= 'Z')) || ((x2Str[i] >= 'a') && (x2Str[i] <= 'n')))
                {
                    X2Convert[i] = CheckEnum(x2Str[i]).ToString();
                }
                else if (x2Str[i] >= '0' && x2Str[i] <= '9')
                {
                    X2Convert[i] = x2Str[i].ToString();
                }
            }

            var diff = Math.Abs(x1Str.Length - x2Str.Length);
            int longN = 0, shortN = 0;
            string l = string.Empty, s = String.Empty;
            var x1 = new List<int> { };
            var x2 = new List<int> { };
            
            //var x1 = Convert.ToInt32(x1Str);
            //var x2 = Convert.ToInt32(x2Str);
            for (int i = l.Length - 1; i >= 0; i--)
            {
                int q1 = 0, q2 = 0;
                if (l[i] - '0' > 9)
                {
                    q1 = CheckEnum(l[i]);
                }
                if (s[i] - '0' > 9)
                {
                    q2 = CheckEnum(s[i]);
                }
                if ((l[i] - '0' > 9) && (s[i] - '0' > 9))
                {
                    q1 = Convert.ToInt32(l[i] - '0');
                    q2 = Convert.ToInt32(s[i] - '0');
                }
                x1.Add(q1);
                x2.Add(q2);
            }

            x1.Reverse();
            x2.Reverse();

            if (x1Str.Length >= x2Str.Length)
            {
                longN = Convert.ToInt32(x1);
                shortN = Convert.ToInt32(x2);
                l = x1Str;
                s = x2Str;
            }
            else
            {
                longN = Convert.ToInt32(x2);
                shortN = Convert.ToInt32(x1);
                l = x2Str;
                s = x1Str;
            }

            Console.Clear();
            Console.WriteLine("Сверху записываем длинное число, потом короткое");
            Console.SetCursorPosition(120, 3);
            Console.WriteLine(longN);
            Console.SetCursorPosition(119, 4);
            Console.WriteLine("+");
            Console.SetCursorPosition(120 + diff, 5);
            Console.WriteLine(shortN);

            var zeros = "";
            for (int i = 0; i < diff; i++)
            {
                zeros += "0";
            }

            s = String.Concat(zeros, s);

            var num = new List<string> { };
            var add = 0;
            for (int i = l.Length - 1, j = 1; i >= 0; i--, j++)
            {
                int z1 = 0, z2 = 0;
                if (l[i] - '0' > 9)
                {
                    z1 = CheckEnum(l[i]);
                }
                if (s[i] - '0' > 9)
                {
                    z2 = CheckEnum(s[i]);
                }
                if ((l[i] - '0' > 9) && (s[i] - '0' > 9))
                {
                    z1 = Convert.ToInt32(l[i] - '0');
                    z2 = Convert.ToInt32(s[i] - '0');
                }
                int g = z1 + z2 + add;
                Console.WriteLine("     //////   " + g);
                Console.WriteLine($"{j}) {l[i]} + {s[i]} + {add}(добавка) = {g};");
                
                if ((g) >= numSystem)
                {
                    var m = z1 + z2;
                    var t = Convert.ToString(m);
                    add = Convert.ToInt32(t[0]);
                    num.Add(t[1].ToString());
                }
                else if ((g) < numSystem)
                {
                    num.Add(Convert.ToString(z1 + z2));
                }
            }

            num.Reverse();
            Console.WriteLine("Результат = ");
            foreach (var ch in num)
            {
                Console.Write(ch);
            }
        }
        static void StackOrFind()
        {
            Console.WriteLine("Сложение: 1 \nВычитание: 2");
            var option = Console.ReadLine();
            if (option == "1")
                Stack();
            //else if (option == "2")
                //Finding();
            else 
                StackOrFind();
        }*/
        public static int GetLengthDifference(string num1, string num2)
        {
            return (int) Math.Abs(num1.Length - num2.Length);
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Выберите, что вам нужно: " +
                              "\n1) Перевод из любой системы счисления в любую другую" +
                              "\n2) Перевод целых чисел в римскую систему счисления" +
                              "\n3) Перевод вещественных чисел" +
                              "\n4) Процесс сложения в произвольной системе счисления" +
                              "\n5) Процесс вычитания в произвольной системе счисления(не работает)" +
                              "\n6) Процесс умножения в произвольных системах счисления(не работает)");
            var option = Console.ReadLine();
            if (option == "1")
                Converter.FromAnyToAny();       
            else if (option == "2")
                RomanianNumber.Calculate();
            else if (option == "3")
                Converter.RealNumber();
            else if (option == "4")
                Operations.Addition();
            else if (option == "5")
                Operations.Subtraction();
            else if (option == "6")
                Operations.Multiply();
            else
            {
                Console.WriteLine("Введите число от 1 до 5");
                option = Console.ReadLine();
            }
        }
    }
}