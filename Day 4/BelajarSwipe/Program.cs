
// static Swap (object a, object b)
// {
//     object  swap = a;
//     a = y;
//     b = swap;
// }

// class Program 
// {
//     static void Main()
//     {
//         int x = 3;
//         int y = 5;
//         Console.WriteLine();
//     }
// }


using System;

public class SwapExample
{
    public static void Main()
    {
        int a = 5;
        int b = 10;
        Console.WriteLine($"Before swap: a = {a}, b = {b}");

        // Swap using a temporary variable
        int temp = a;
        a = b;
        b = temp;

        Console.WriteLine($"After swap: a = {a}, b = {b}");
    }
}
