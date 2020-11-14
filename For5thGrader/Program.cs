using System;
using System.Linq;
using System.Collections.Generic;

namespace For5thGrader
{
    internal class Program
    {
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