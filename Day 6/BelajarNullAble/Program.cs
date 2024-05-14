class Program
{
    static void Main()
    {
        //NullAble
        int? a = null;
        if (a.HasValue)
        {
            Console.WriteLine($"a is :{a}");
        }
        else
        {
            Console.WriteLine("a doesn't have value");
        }
    }
}