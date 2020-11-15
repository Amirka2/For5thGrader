using System;
using System.Linq;
using System.Collections.Generic;

namespace For5thGrader
{
    internal class Program
    {
        private static void ChooseMainOptions(int index)
        {
            if (index == 0)
                Converter.FromAnyToAny();       
            else if (index == 1)
                RomanianNumber.Calculate();
            else if (index == 2)
                Converter.RealNumber();
            else if (index == 3)
                Operations.Addition();
            else if (index == 4)
                Operations.Subtraction();
            else if (index == 5)
                Operations.Multiply();
        }
        
        public static void Main(string[] args)
        {
            var menuItems = new List<string>
            {
                "1) Перевод из любой системы счисления в любую другую",
                "2) Перевод целых чисел в римскую систему счисления",
                "3) Перевод вещественных чисел" ,
                "4) Процесс сложения в произвольной системе счисления" ,
                "5) Процесс вычитания в произвольной системе счисления" ,
                "6) Процесс умножения в произвольных системах счисления(не работает)"
            };

            while(true)
            {
                ConsoleKeyInfo key;
                int index = 0;
                Console.CursorVisible = false;
                do
                {
                    Console.Clear();
                    Output.PrintStartOptions(menuItems, index);

                    key = Console.ReadKey();
                    if (key.Key == ConsoleKey.UpArrow) index--;
                    if (key.Key == ConsoleKey.DownArrow) index++;

                    if (index < 0) index = menuItems.Count - 1;
                    if (index >= 6) index = 0;
                    if (key.Key == ConsoleKey.Enter) break;

                } while (key.Key != ConsoleKey.Escape);

                ChooseMainOptions(index);
                Console.ReadKey();
            }
        }
    }
}