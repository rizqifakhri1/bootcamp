class Program
{
    static int counter = 0;
    static object key = new(); // Tambahkan
    static async Task Main()
    {
        Task task1 = IncerementCounterAsync();
        var task2 = IncerementCounterAsync();

        await Task.WhenAll(task1, task2);
        System.Console.WriteLine($"Final Counter : {counter}");
    }

    static async Task IncerementCounterAsync()
    {
        lock (key) //lock
        {
            for (int i = 0; i < 100; i++)
            {
                counter++;
                System.Console.WriteLine($"Counter From: {i}");
            }
        }
        await Task.Delay(100); // await dikeluarkan dari loop
    }
}
