using System;
using System.Linq;
using System.Collections.Generic;

namespace For5thGrader
{
    internal class Program
    {
        //1task
        enum Alphabet
        {
            A = 10, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z, //26 C
            a, b, c, d, e, f, g, h, i, j, k, l, m, n //14
        }

        public static string Result;
        
        static int CheckEnum(char num)
        {
            string trueNum = "";
            for (short i = 10; i <= 50; i++)
            {
                if (num.ToString() == Convert.ToString((Alphabet)i))
                    trueNum = i.ToString();
                else if (!int.TryParse(num.ToString(), out int e))
                    return 0;
            }
            return Convert.ToInt32(trueNum);
        }

        static bool CheckNum(string num, string numSystem)
        {
            bool check = false;
            var list = new List<int>{ };
            for (int i = 0; i < num.Length; i++)
            {
                if (((num[i] >= 65) && (num[i] <= 90)) || ((num[i] >= 97) && (num[i] <= 110)))
                {
                    list.Add(CheckEnum(num[i]));
                    continue;
                }
                list.Add(num[i]);
            }

            foreach (var n in list)
            {
                if (n >= int.Parse(numSystem))
                    return false;
                else
                    check = true;
            }

            foreach (var m in list)
            {
                Console.Write(m);
            }

            return check;
        }

        static int ConvertFrom10ToAny(int num, int numSystem)
        {
            if (num >= numSystem) ConvertFrom10ToAny(num / numSystem, numSystem);
            var number = num % numSystem;
            Alphabet numberStr;
            if (number >= 10)
            {
                numberStr = (Alphabet)number;
                Result += numberStr;
            }
            else
            {
                Result += number;
            }
            Console.WriteLine("Промежуточный результат:                         " + number);
            Console.WriteLine($"{num} / {numSystem} = {num / numSystem} и {num % numSystem}(остаток)");
            
            return int.Parse(Result);
        }
        static int ConvertFromAnyTo10(List<int> num1, int numSystem1)
        {
            string num = "";
            foreach (var n in num1)
            {
                num += n;
            }
            var numSystem = numSystem1.ToString();
            
            Console.SetCursorPosition(80, 3);
            Console.WriteLine(num);
            Console.SetCursorPosition(80, 4);
            for (int i = num.Length - 1; i >= 0; i--)
            {
                Console.Write(i);
            }
            Console.WriteLine();

            var res = 0;

            for (int i = num.Length - 1, n = 0; i >= 0; i--, n++)
            {
                res += num1[n] * Convert.ToInt32(Math.Pow(numSystem1, i));
            }
            Console.WriteLine(res);
            return res;
        }
        static void ConvertFromOneToAnother()
        {
            var x = Console.ReadLine();
            var listx = new List<int> { };
            foreach (var ch in x)
            {
                if (((ch >= 'A') && (ch <= 'Z')) || ((ch >= 'a') && (ch <= 'n')))
                {
                    listx.Add(CheckEnum(ch));
                }
                else 
                    listx.Add(Convert.ToInt32(ch));
            }
            var y = Convert.ToInt32(Console.ReadLine());
            var z = Convert.ToInt32(Console.ReadLine());

            var newNum = ConvertFromAnyTo10(listx, y);
            var res = ConvertFrom10ToAny(newNum, z);
            Console.WriteLine(res);
        }

        //2task
        static void ConvertToRome()
        {
            var num = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("| = 1, || = 2, ||| = 3, |V = 4, V = 5, V|, V|| = 7, V||| = 8, |X = 9 \n" +
                              "X = 10, X| = 11, X|| = 12, X||| = 13, X|V = 14, XV = 15, XV| = 16, XV|| = 17, XV||| = 18, X|X = 19 \n" +
                              "| = 1, V = 5, X = 10, L = 50, C = 100, D = 500, M = 1000, V* = 5000, X* = 10000 \n" +
                              "Логика такая же, как и с числами от 1 до 20: добавляем младший разряд до тех пор, " +
                              "пока не останется один шаг до вышестоящего разряда, как только доходит до него, " +
                              "мы пишем один младший разряд слвеа и за ним вышестоящий разряд. \nСледующим шагом убираем" +
                              " младший разряд слева, оставляя один вышестоящий. Дальше к нему справа дописываем младшие, если хотим добавить шаг\n" +
                              "Пример: | -> || -> ||| -> |V -> V -> V| -> V|| -> V||| \n" +
                              "Дальше все повторяется");
            Console.ResetColor();
            var discharge = new List<int> { };
            for (int i = 0; i < num.Length; i++)
            {
                discharge.Add(int.Parse(num[i].ToString()));
            }

            var l = num.Length;
            int thsnd = 0, hndr = 0, tens = 0, ones = 0;
            var output = new List<string> { };

            if (l == 4)
            {
                thsnd = discharge[0];
                hndr = discharge[1];
                tens = discharge[2];
                ones = discharge[3];
            }
            else if (l == 3)
            {
                hndr = discharge[0];
                tens = discharge[1];
                ones = discharge[2];
            }
            else if (l == 2)
            {
                tens = discharge[0];
                ones = discharge[1];
            }
            else if (l == 1)
            {
                ones = discharge[0];
            }
            
            if (thsnd != 0)
            {
                if ((thsnd > 0) && (thsnd <= 10))
                {
                    if ((thsnd > 0) && (thsnd < 4))
                    {
                        for (int i = 0; i < thsnd; i++)
                        {
                            output.Add("M");
                        }
                    }
                    else if (thsnd == 4)
                    {
                        output.Add("MV*");
                    }
                    else if ((hndr > 4) && (hndr < 9))
                    {
                        output.Add("V*");
                        for (int i = 0; i < hndr; i++)
                        {
                            output.Add("M");
                        }
                    }
                    else if (hndr == 9)
                    {
                        output.Add("MX*");
                    }
                }
            }
            if (hndr != 0)
            {
                if ((hndr > 0) && (hndr < 4))
                {
                    for (int i = 0; i < hndr; i++)
                    {
                        output.Add("C");
                    }
                }
                else if (hndr == 4)
                {
                    output.Add("CD");
                }
                else if ((hndr > 4) && (hndr < 9))
                {
                    output.Add("D");
                    for (int i = 0; i < hndr; i++)
                    {
                        output.Add("C");
                    }
                }
                else if (hndr == 9)
                {
                    output.Add("CM");
                }
            }
            if (tens != 0)
            {
                if ((tens > 0) && (tens < 4))
                {
                    for (int i = 0; i < tens; i++)
                    {
                        output.Add("X");
                    }
                }
                else if (tens == 4)
                {
                    output.Add("XL");
                }
                else if ((tens > 4) && (tens < 9))
                {
                    output.Add("L");
                    for (int i = 0; i < tens - 5; i++)
                    {
                        output.Add("X");
                    }
                }
                else if (tens == 9)
                {
                    output.Add("XC");
                }
            }
            if (ones != 0)
            {
                if ((ones > 0) && (ones < 4))
                {
                    for (int i = 0; i < ones; i++)
                    {
                        output.Add("|");
                    }
                }
                else if (ones == 4)
                {
                    output.Add("|V");
                }
                else if ((ones > 4) && (ones < 9))
                {
                    output.Add("V");
                    for (int i = 0; i < ones - 5; i++)
                    {
                        output.Add("|");
                    }
                }
                else if (ones == 9)
                {
                    output.Add("|X");
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"Результат: {num} = ");
            foreach (var str in output)
            {
                Console.Write(str);
            }
        } 
        
        //3task
        static List<int> ConvertFractionalPart(int drobpart, int numSystem)
        {
            var str = "0," + drobpart;
            double drob = double.Parse(str);
            var result = new List<int> { };
            var c = 0;
            var x = str.Split(',');

            do
            {
                c++;

                Console.WriteLine("while");
                drob *= numSystem;
                Console.WriteLine("    " + drob);
                
                var s = drob.ToString();
                var d = s.Split(',');
               
                if (string.IsNullOrWhiteSpace(d[1]))
                    drobpart = int.Parse(d[1]);

                if (drob > 1)
                {
                    result.Add(Convert.ToInt32(drob));
                    Console.WriteLine("iF " + drob + " " + drobpart);
                    drob -= Convert.ToInt32(drob);
                }
                
            } while ((c <= 8) || (!string.IsNullOrWhiteSpace(x[1])));
            
            return result;
        }
        static void ConvertRealNumbers()
        {
            Console.WriteLine("Введите число в 10-СС с точкой");
            var input = Console.ReadLine();
            var c = input.Split('.');
            var mainNum = int.Parse(c[0]);
            var subNum = int.Parse(c[1]);
            
            Console.WriteLine("Введите желаемую СС:");
            var numSystem = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Сначала переводим целую часть:");
            var main = ConvertFrom10ToAny(mainNum, numSystem);
            
            Console.WriteLine("Теперь переводим дробную часть:");
            var sub = ConvertFractionalPart(subNum, numSystem);
            
            Console.WriteLine(main);
            foreach (var ch in sub)
            {
                Console.Write(ch);
            }
            
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Выберите, что вам нужно: " +
                              "\n1) Перевод из любой системы счисления в любую другую" +
                              "\n2) Перевод целых чисел в римскую систему счисления" +
                              "\n3) Перевод вещественных чисел" +
                              "\n4) Процесс сложения/вычитания в произвольной системе счисления" +
                              "\n5) Процесс умножения в произвольных системах счисления");
            var option = Console.ReadLine();
            if (option == "1")
                ConvertFromOneToAnother();
            else if (option == "2")
                ConvertToRome();
            else if (option == "3")
                ConvertRealNumbers();
            /*else if (option == "4")
                StackOrFind();
            else if (option == "5")
                ToIncrease();*/
            else
            {
                Console.WriteLine("Введите число от 1 до 5");
                option = Console.ReadLine();
            }
        }
    }
}