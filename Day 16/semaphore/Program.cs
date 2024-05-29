using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    // Membuat semaphore dengan 3 slot tersedia dan maksimum 3 slot.
    private static SemaphoreSlim semaphore = new SemaphoreSlim(3);

    static void Main()
    {
        for (int i = 1; i <= 10; i++)
        {
            int taskNum = i;
            Task.Run(() => AccessResource(taskNum));
        }

        // Tunggu sampai semua tugas selesai.
        Console.ReadLine();
    }

    private static void AccessResource(int taskNum)
    {
        Console.WriteLine($"Task {taskNum} menunggu untuk memasuki area kritis.");

        // Tunggu sampai semaphore mengizinkan masuk (menunggu slot tersedia).
        semaphore.Wait();

        try
        {
            Console.WriteLine($"Task {taskNum} memasuki area kritis.");
            Thread.Sleep(1000); // Simulasi pekerjaan dalam area kritis.
            Console.WriteLine($"Task {taskNum} keluar dari area kritis.");
        }
        finally
        {
            // Melepaskan semaphore sehingga thread lain bisa masuk.
            semaphore.Release();
        }
    }
}
