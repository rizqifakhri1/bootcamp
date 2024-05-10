using System;
namespace GenericsDemo
{
    public class ClsMain
    {
        private static void Main()
        {
            //bool IsEqual = ClsCalculator.AreEqual<int>(10, 20);
            //bool IsEqual = ClsCalculator.AreEqual<string>("ABC", "ABC");
            bool IsEqual = ClsCalculator.AreEqual<double>(10.5, 20.5);
            if (IsEqual)
            { Console.WriteLine("Both are Equal"); }
            else
            { Console.WriteLine("Both are Not Equal"); }
            Console.ReadKey();
        }
    }

    public class ClsCalculator
    {
				//TAKE INT 
        //public static bool AreEqual(int value1, int value2)
        //{
        //    return value1 == value2;
        //}
        public static bool AreEqual<T>(T value1, T value2)
        { 
            return value1.Equals(value2); 
            }
    }
}