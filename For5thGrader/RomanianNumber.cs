using System;
using System.Collections.Generic;

namespace For5thGrader
{
    public class RomanianNumber
    {
        public static void Calculate()
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
    }
}