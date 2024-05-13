using System;

public delegate void Operation(int x, int y);

public class Calculator
{
    public static void Add(int x, int y)
    {
        Console.Write("Tambah :");
        Console.WriteLine(x + y);
    }

    public static void Min(int x, int y)
    {
        Console.Write("Kurang :");
        Console.WriteLine(x - y);
    }
}

class Program
{
    static void Main()
    {
        Operation my = new Operation(Calculator.Add);
        my += Calculator.Min;
        my.Invoke(1, 3);
    }
}
