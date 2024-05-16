using System;

public class Program
    {
        public static void Main()
        {
            // Test the AreEqual method with different types
            //bool isEqual = ClsCalculator.AreEqual<int>(10, 20);
            //bool isEqual = ClsCalculator.AreEqual<string>("ABC", "ABC");
            bool isEqual = ClsCalculator.AreEqual<double>(10.5, 20.5);

            if (isEqual)
            {
                Console.WriteLine("Both are Equal");
            }
            else
            {
                Console.WriteLine("Both are Not Equal");
            }

            Console.ReadKey();
        }
    }

    public class ClsCalculator
    {
        public static bool AreEqual<T>(T value1, T value2)
        {
            return value1.Equals(value2);
        }
    }