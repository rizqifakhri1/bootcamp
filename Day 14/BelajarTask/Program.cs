using System;
// using System.Threading.Tasks;

class Program 
{
    static void Main(string[] args)
    {
        Task task1 = new Task(() => Console.WriteLine("Hallo"));
        task1.Start();
        task1.Wait();
    }
}
