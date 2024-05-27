using System;
using System.Threading;

namespace SimpleNumberGuessingGame
{
    class Program
    {
        private static int targetNumber;
        private static bool gameOver = false;
        
        static void Main(string[] args)
        {
            // Membuat dan memulai thread untuk menghasilkan angka acak
            Thread generateNumberThread = new Thread(new ThreadStart(GenerateNumber));
            generateNumberThread.Start();
            
            // Membuat dan memulai thread untuk meminta input dari pengguna
            Thread userInputThread = new Thread(new ThreadStart(UserInput));
            userInputThread.Start();
            
            // Menunggu kedua thread selesai
            generateNumberThread.Join();
            userInputThread.Join();
            
            Console.WriteLine("Permainan selesai.");
        }
        
        static void GenerateNumber()
        {
            Random random = new Random();
            targetNumber = random.Next(1, 101);
            Console.WriteLine("Angka acak telah dihasilkan. Silakan tebak!");
        }
        
        static void UserInput()
        {
            while (!gameOver)
            {
                Console.Write("Masukkan tebakan Anda (antara 1 dan 100): ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int guess))
                {
                    if (guess == targetNumber)
                    {
                        Console.WriteLine("Selamat! Anda menebak angka yang benar.");
                        gameOver = true;
                    }
                    else
                    {
                        Console.WriteLine(guess < targetNumber ? "Terlalu rendah!" : "Terlalu tinggi!");
                    }
                }
                else
                {
                    Console.WriteLine("Masukkan angka yang valid.");
                }
            }
        }
    }
}
