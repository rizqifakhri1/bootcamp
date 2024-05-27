class Program 
{
    public static void Main(string[] args)
    {
        Printer();
        Printer2();
    }

    static void Printer()
    {
        System.Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        for (int i = 0; i < 10; i++)  
        {
            Console.WriteLine("Printer 1");
        }
    }
    static void Printer2()
    {
        System.Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        for (int i = 0; i < 10; i++)  
        {
            Console.WriteLine("Printer 2");
        }
    }
}