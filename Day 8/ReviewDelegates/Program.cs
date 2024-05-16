public delegate void Calculator(int x, int y);


class Program
{
    static void Main(string[] args)
    {
        Calculator calculator = new Calculator(Hitung.Add);
        // calculator += Hitung.Add;
        calculator += Hitung.Sub;
        calculator.Invoke(3, 2);
    }
}

class Hitung 
{
    public static void Add(int x, int y)
    {
        Console.WriteLine(x + y);
    }

    public static void Sub(int x, int y)
    {
        Console.WriteLine(x - y);
    }
}