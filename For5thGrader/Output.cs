using System;
using System.Collections.Generic;

namespace For5thGrader
{
    public class Output
    {
        public static void PrintAlphabet()
        {
            PrintColorfulText(3, "A = 10, B = 11, C = 12, D = 13, E = 14, F = 15, G = 16, H = 17, I = 18, \n" +
                                 "J = 19, K = 20, L = 21, M = 22, N = 23, O = 24, P = 25, Q = 26, R = 27, S = 28, \n" +
                                 "T = 29, U = 30, V = 31, W = 32, X = 33, Y = 34, Z = 35, a = 36, b = 37, c = 38, \n" +
                                 "d = 39, e = 40, f = 41, g = 42, h = 43, i = 44, j = 45, k = 46, l = 47, m = 48, \n" +
                                 "n = 49");
        }
        public static void PrintStartOptions()
        {
            Console.WriteLine("Выберите, что вам нужно: " +
                              "\n1) Перевод из любой системы счисления в любую другую" +
                              "\n2) Перевод целых чисел в римскую систему счисления" +
                              "\n3) Перевод вещественных чисел" +
                              "\n4) Процесс сложения в произвольной системе счисления" +
                              "\n5) Процесс вычитания в произвольной системе счисления(не работает)" +
                              "\n6) Процесс умножения в произвольных системах счисления(не работает)");
        }
        
        public static void PrintNumber(List<int> number, int i)
        {
            Console.SetCursorPosition(80, i);
            foreach (var el in number)
                Console.Write(el + " ");
        }

        public static void PrintSign(char sign, int i)
        {
            Console.SetCursorPosition(79, i);
            Console.WriteLine(sign);
        }

        public static void PrintExpressionInCenter(List<int> num1, char sign, List<int> num2)
        {
            Output.PrintNumber(num1, 3);

            Output.PrintSign(sign, 4);
            
            Output.PrintNumber(num2, 5);
            Console.WriteLine();
        }

        public static void PrintRealNumber(List<int> listBeforeDot, List<int> listAfterDot)
        {
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
        
        public static void PrintRulesInRomanianNumbers()
        {
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
        }

        public static void PrintResultInRomanianNumbers(string num, List<string> output)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"Результат: {num} = ");
            foreach (var str in output)
            {
                Console.Write(str);
            }
        }

        public static void PrintColorfulText(int color, string text)
        {
            if (color == 0)
                Console.ForegroundColor = ConsoleColor.Red;
            else if (color == 1)
                Console.ForegroundColor = ConsoleColor.Green;
            else if (color == 2)
                Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static void FromAnyTo10Text1()
        {
            PrintColorfulText(1, "Для перевода числа из любой системы счисления в десятичную достаточно " +
                              "пронумеровать его разряды, начиная с нулевого " +
                              "\nТеперь найдём сумму произведений цифр числа на основание системы счисления в степени позиции этой цифры:");
        }
    }
}