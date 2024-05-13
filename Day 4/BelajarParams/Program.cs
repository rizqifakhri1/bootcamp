class Calculator
{
   public int Add(params int[] number)
   {
    int sum = 0;
    foreach ( int i in number)
    {
        sum += i;
    }
    return sum;
   }
}

class StringClc
{
    public int Add(params string[] numberString)
    {
        int sum = 0;
        foreach (string i in numberString)
        {
            int number = int.Parse(i);
            sum += number;
        }
        

        return sum;
    }
}

class Program
{
    static void Main()
    {
        Calculator clc = new Calculator();
        int a = clc.Add(1,2,3,4,5); //.Dump
        Console.WriteLine(a);

        StringClc SClc = new StringClc();
        int b = SClc.Add("1", "2", "3", "4", "5");

        Console.WriteLine(b);
    }
}