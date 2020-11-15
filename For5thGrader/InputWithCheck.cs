using System;

namespace For5thGrader
{
    public class InputWithCheck
    {
        public static string CheckAndReturnSs()
        {
            Console.Write("Введите систему счисления: ");
            var numSystem = Console.ReadLine();
            while (!Check.SS(Convert.ToInt32(numSystem)) 
                   || string.IsNullOrWhiteSpace(numSystem))
                numSystem = Console.ReadLine();
            return numSystem;
        }
        
        public static string CheckAndReturnSs(string text)
        {
            Console.Write(text);
            var numSystem = Console.ReadLine();
            while (!Check.SS(Convert.ToInt32(numSystem)) 
                   || string.IsNullOrWhiteSpace(numSystem))
                numSystem = Console.ReadLine();
            return numSystem;
        }

        public static string CheckAndReturnNumber(int numSystem)
        {
            Console.Write("Введите число: ");
            var num = Console.ReadLine();
            while (!Check.NumInSS(num, numSystem)
                   || string.IsNullOrWhiteSpace(num))
                num = Console.ReadLine();
            return num;
        }
        
        public static string CheckAndReturnNumber(int numSystem, string text)
        {
            Console.Write(text);
            var num = Console.ReadLine();
            while (!Check.NumInSS(num, numSystem)
                   || string.IsNullOrWhiteSpace(num))
                num = Console.ReadLine();
            return num;
        }
    }
}