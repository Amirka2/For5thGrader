using System;
using System.Linq;

namespace For5thGrader
{
    public class Check
    {
        public static bool NumInSS(string num, int numSys)
        {
            var numList = Converter.ToNumList(num);
            foreach (var el in numList)
            {
                if (el >= numSys)
                    return false;
            }

            return true;
        }

        public static bool SS(int numSystem)
        {
            if (numSystem > 50 || numSystem < 2)
            {
                Console.WriteLine("Система счисления не удовлетворяет условию (2-50)");
                return false;
            }            
            
            return true;
        }
        
        public static bool IsRealNumber(string num)
        {
            if (!double.TryParse(num, out double c) || (!num.Contains(',')))
            {
                Console.WriteLine("Число не соответствует типу с плавающей запятой!");
                return false;
            }
            return true;
        }

    }
}