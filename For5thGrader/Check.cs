using System;
using System.Linq;
using System.Collections.Generic;

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
        
        public static bool IsList1BiggerThanList2(string list1, string list2, int numSystem)
        {
            var check = false;
            
            var num1 = Converter.FromAnyTo10(list1, numSystem, false);
            var num2 = Converter.FromAnyTo10(list2, numSystem, false);

            if (num1 < num2)
                return false;

            return true;
        }
    }
}