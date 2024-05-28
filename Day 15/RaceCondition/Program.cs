class Program 
{
    static int counter = 0;
    static async Task Main()
    {
        Task task1 = IncerementCounterAsync();
        var task2 = IncerementCounterAsync();

        await Task.WhenAll(task1, task2);
        System.Console.WriteLine($"Final Counter : {counter}");
    }

    static async Task IncerementCounterAsync()
    {
        for (int i = 0; i < 100; i++)
        {
            counter++;
            await Task.Delay(100);
            System.Console.WriteLine($"Counter From: {i}");
        }
    }
}
