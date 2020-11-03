using System;

namespace For5thGrader
{
    internal class Program
    {
        enum Alphabet
        {
            A = 10, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z, //26
            a, b, c, d, e, f, g, h, i, j, k, l, m, n //14
        }

        public static string Result;
       /* static void CheckNum(string input)
        {
            int c = 0;
            var check = int.TryParse(input, out c);
            while (!check)
            {
                Console.WriteLine("Введите число!");
                input = Console.ReadLine();
                check = int.TryParse(input, out c);
            }
        }*/

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
        static double ConvertFromAnyTo10(string num, string numSystem)
        {
            Console.WriteLine("\n" + num);
            for (int i = num.Length - 1; i >= 0; i--)
                Console.Write(i);
            Console.WriteLine(" - степени\n");
            
            var result = 0.0;
            for (int i = 0, j = 1; i < num.Length; i++, j++)
            {
                var number = (double.Parse(num[i].ToString()) * Math.Pow(Convert.ToDouble(numSystem), num.Length - j));
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
            /*else if (option == "2")
                ConvertToRome();
            else if (option == "3")
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