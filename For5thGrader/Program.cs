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
            A = 10, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z, //26 Convertfromanyto10 работа с енамом
            a, b, c, d, e, f, g, h, i, j, k, l, m, n //14
        }

        public static string Result;

        public static void ConvertFrom10ToAny(int num, int numSystem)
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
        }
        /*static double ConvertFromAnyTo10(string num, string numSystem)
        {
            Console.WriteLine("\n" + num);
            for (int i = num.Length - 1; i >= 0; i--)
                Console.Write(i);
            Console.WriteLine(" - степени\n");
            
            var result = 0.0;
            for (int i = 0, j = 1; i < num.Length; i++, j++)
            {
                double number;
                if ((num[i] >= 65) && (num[i] <= 90))
                {
                    number = Alphabet
                }
                else if (num[i] >= 97) && (num[i] <= 110))
                {
                    
                }
                else if (num[i])
                {
                    number = (double.Parse(num[i].ToString()) * Math.Pow(Convert.ToDouble(numSystem), num.Length - j));
                }

                result += number;
                Console.Write("+ " + number);
                Console.WriteLine($"     ({num[i]}*{numSystem}^{num.Length - j})");
            }

            Console.WriteLine($"Число {num} в {numSystem} СС = {result} в 10 СС\n");
            return result;
        }
        static void ConvertFromOneToAnother()
        {
            Console.WriteLine("Алфавит: 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, " + 
                              "A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z, " + 
                              "a, b, c, d, e, f, g, h, i, j, k, l, m, n"); 
            Console.Write("Введите число: ");
            var num = Console.ReadLine();
            //CheckNum(num);
            
            Console.Write("Введите начальную систему счисления(1-50): ");
            var numSys1 = Console.ReadLine();
            //CheckNum(numSys1);

            bool check = false;

            foreach (var el in num)
            {
                if ((el >= 65) && (el <= 90))
                {
                    if ((el - 55) >= int.Parse(numSys1))
                        check = false;
                    else
                        check = true;
                }
                else if ((el >= 97) && (el <= 110))
                {
                    if ((el - 60) >= int.Parse(numSys1))
                        check = false;
                    else
                        check = true;                
                }
                else
                {
                    if ((el - '0') >= int.Parse(numSys1))
                        check = false;
                    else
                        check = true;
                }
            }
            
            if (check)
            {
                Console.Write("Введите желаемую систему счисления(1-50): ");
                var numSys2 = Console.ReadLine();
                //CheckNum(numSys2);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1)Для перевода из одной системы счисления в другую нужно перевести число сначала в десятичную систему, а затем в нужную");
                Console.WriteLine($"{num} в {numSys1} СС переводится в 10 СС путем представления в виде суммы степеней {numSys1} с коэффициентами-цифрами");
                Console.WriteLine("2)Для перевода числа из 10 СС в другой СС, нужно столбиком делить это число на основание СС," 
                                  + " а затем записать остатки от деления в обратной последовательности\n" 
                                  + "Читать снизу вверх (а остатки собираются сверху вниз)");
                Console.ResetColor();
                
                ConvertFrom10ToAny(Convert.ToInt32(ConvertFromAnyTo10(num, numSys1)), Convert.ToInt32(numSys2));
                Console.WriteLine("\nРезультат: " + Result);
            }
            else
            {
                Console.WriteLine("Система счисления меньше, чем указанные в числе символы!");
            }
        }*/

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
        public static void Main(string[] args)
        {
            Console.WriteLine("Выберите, что вам нужно: " +
                              "\n1) Перевод из любой системы счисления в любую другую" +
                              "\n2) Перевод целых чисел в римскую систему счисления" +
                              "\n3) Перевод вещественных чисел" +
                              "\n4) Процесс сложения/вычитания в произвольной системе счисления" +
                              "\n5) Процесс умножения в произвольных системах счисления");
            var option = Console.ReadLine();
            //if (option == "1")
                //ConvertFromOneToAnother();
            if (option == "2")
                ConvertToRome();
            /*else if (option == "3")
                ConvertRealNumbers();
            else if (option == "4")
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