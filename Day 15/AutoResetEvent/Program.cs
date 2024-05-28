//Autoreset event has 3 method, set(), Reset(), WaitOne()

class Program 
{
    static AutoResetEvent autoResetEvent = new AutoResetEvent(false);
    static void Main()
    {
        Thread thread = new Thread(SomeMethod)
        {
            Name = "NewThread"
        };

        thread.Start();
        Console.ReadKey();

        autoResetEvent.Set();
    }

    static void SomeMethod()
    {
        System.Console.WriteLine("Starting...");
        autoResetEvent.WaitOne();
        System.Console.WriteLine("Finsihing...");
    }
}