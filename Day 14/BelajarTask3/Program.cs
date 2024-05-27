class Program 
{
    public static void Main(string[] args) 
    {
        Task task = Task.Run(()=>
        {
            for (int i = 0; i < 10; i++)
            {
                System.Console.WriteLine("+" + i);
            }
        });
        System.Console.WriteLine("Sebelum");
        System.Console.WriteLine(task.IsCompleted);
        System.Console.WriteLine(task.IsCanceled);
        System.Console.WriteLine(task.IsFaulted);

        Task.WaitAll(task);

        System.Console.WriteLine("Sesudah");
        System.Console.WriteLine(task.IsCompleted);
        System.Console.WriteLine(task.IsCanceled);
        System.Console.WriteLine(task.IsFaulted);
    }
}