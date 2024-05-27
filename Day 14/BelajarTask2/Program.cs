class Program
{
    public static void Main(string[] args)
    {
        Task task1 = new Task(() =>
        {
            Console.WriteLine("T1");
            Thread.Sleep(6000);
            System.Console.WriteLine("Task 1 Complete");
        });

        Task task2 = new Task(() =>
        {
            Console.WriteLine("T2");
            Thread.Sleep(7000);
            System.Console.WriteLine("Task 2 Complete");
        });

        task1.Start();
        task2.Start();

        System.Console.WriteLine("Task 1 Running");
        System.Console.WriteLine("Task 2 Running");

        // task1.Wait();
        // task2.Wait();

        Task.WaitAll(task1, task2);
        System.Console.WriteLine("Task 1 Done");
    }
}