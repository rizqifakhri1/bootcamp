class Program 
{
    public static void Main(string[] args)
    {
        Thread thread = new(()=> Yell());
        Thread thread2 = new(Yell2);
        Thread thread3 = new(Yell3);
        Thread thread4 = new(Yell4);

        // thread.IsBackground = true;
        thread.Name = "Nama Thread";
        thread.Priority = ThreadPriority.Normal;

        thread.Start();
        thread2.Start();
        thread3.Start();
        thread4.Start();

        thread.Join();
        thread2.Join();
        thread3.Join();
        thread4.Join();

        System.Console.WriteLine("Jangan Teriak Di bawah ini");
    }

    static void Yell()
    {
        System.Console.WriteLine("Ini Thread Ke : " + Thread.CurrentThread.ManagedThreadId);
        // Console.WriteLine("Teriak 1 : Yihaaa");
        // Thread.Sleep(50000); //Untuk menunda

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Teriak 1 : Yihaaa Ke = " + i);
            Thread.Sleep(500);
        }
    }
    static void Yell2()
    {
        System.Console.WriteLine("Ini Thread Ke : " + Thread.CurrentThread.ManagedThreadId);
        Console.WriteLine("Teriak 2 : Uhuy");
        Thread.Sleep(500); //Untuk menunda ?
    }
    static void Yell3()
    {
        System.Console.WriteLine("Ini Thread Ke : " + Thread.CurrentThread.ManagedThreadId);
        Console.WriteLine("Teriak 3 : Apaan tuh");
        Thread.Sleep(500); //Untuk menunda ?
    }

    static void Yell4()
    {
        System.Console.WriteLine("Ini Thread Ke : " + Thread.CurrentThread.ManagedThreadId);
        Console.WriteLine("Teriak 4 : Shisss");
        Thread.Sleep(500); //Untuk menunda ?
    }
}