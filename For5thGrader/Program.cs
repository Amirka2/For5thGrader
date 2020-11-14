using System;
using System.Linq;
using System.Collections.Generic;

namespace For5thGrader
{
    internal class Program
    {
        private static void ChooseMainOptions(string option)
        {
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
                Console.Write("Введите число от 1 до 5: ");
                option = Console.ReadLine();
            }
        }
        
        public static void Main(string[] args)
        {
            Output.PrintStartOptions();
            var option = Console.ReadLine();

            ChooseMainOptions(option);
        }
    }
}