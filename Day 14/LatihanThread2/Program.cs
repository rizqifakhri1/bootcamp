using System;
using System.Collections.Generic;
using System.Threading;

namespace SimpleRPSGame
{
    class Program
    {
        private static string[] choices = { "gunting", "kertas", "batu" };
        private static string targetChoice;
        private static bool gameOver = false;

        static void Main(string[] args)
        {
            // Membuat dan memulai thread untuk memilih pilihan acak
            Thread selectChoiceThread = new Thread(new ThreadStart(SelectRandomChoice));
            selectChoiceThread.Start();

            // Membuat dan memulai thread untuk meminta input dari pengguna
            Thread userInputThread = new Thread(new ThreadStart(UserInput));
            userInputThread.Start();

            // Menunggu kedua thread selesai
            selectChoiceThread.Join();
            userInputThread.Join();

            Console.WriteLine("Permainan selesai.");
        }

        static void SelectRandomChoice()
        {
            Random random = new Random();
            int index = random.Next(choices.Length);
            targetChoice = choices[index];
            Console.WriteLine("Pilihan acak telah dibuat. Silakan tebak (gunting, kertas, batu)!");
        }

        static void UserInput()
        {
            while (!gameOver)
            {
                Console.Write("Masukkan pilihan Anda (gunting, kertas, batu): ");
                string input = Console.ReadLine().ToLower().Trim(); // Mengubah input menjadi lowercase dan menghapus spasi ekstra
                if (Array.Exists(choices, element => element.Equals(input)))
                {
                    if (input.Equals(targetChoice))
                    {
                        Console.WriteLine("Draw, Kamu dan Bot memilih : " + targetChoice);
                        gameOver = true;
                    }
                    else
                    {
                        if ((input == "gunting" && targetChoice == "kertas") ||
                            (input == "kertas" && targetChoice == "batu") ||
                            (input == "batu" && targetChoice == "gunting"))
                        {
                            Console.WriteLine("Kamu Menang, Bot Memilih : " + targetChoice);
                            gameOver = true;
                        }
                        else
                        {
                            Console.WriteLine("Kamu Kalah, Bot Memilih : " + targetChoice);
                            gameOver = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Masukkan pilihan yang valid.");
                }
            }
        }

        // IF else dapat di serhanakan

        // static void UserInput()
        // {
        //     while (!gameOver)
        //     {
        //         Console.Write("Masukkan pilihan Anda (gunting, kertas, batu): ");
        //         string input = Console.ReadLine().ToLower(); // Mengubah input menjadi lowercase agar tidak case sensitive
        //         if (Array.Exists(choices, element => element.Equals(input)))
        //         {
        //             if (input.Equals(targetChoice))
        //             {
        //                 Console.WriteLine("Draw");
        //                 gameOver = true;
        //             }
        //             else if (input != targetChoice)
        //             {
        //                 if (input == "gunting " && targetChoice == "kertas")
        //                 {
        //                     System.Console.WriteLine("Kamu Menang");
        //                     gameOver = true;
        //                 }

        //                 else if (input == "gunting " && targetChoice == "batu")
        //                 {
        //                     System.Console.WriteLine("Kamu kalah");
        //                     gameOver = true;
        //                 }

        //                 else if (input == "kertas " && targetChoice == "batu")
        //                 {
        //                     System.Console.WriteLine("Kamu Menang");
        //                     gameOver = true;
        //                 }

        //                 else if (input == "kertas " && targetChoice == "gunting")
        //                 {
        //                     System.Console.WriteLine("Kamu Kalah");
        //                     gameOver = true;
        //                 }
        //                 else if (input == "batu " && targetChoice == "gunting")
        //                 {
        //                     System.Console.WriteLine("Kamu Menang");
        //                     gameOver = true;
        //                 }
        //                 else if (input == "batu " && targetChoice == "kertas")
        //                 {
        //                     System.Console.WriteLine("Kamu Kalah");
        //                     gameOver = true;
        //                 }
        //             }

        //         }
        //         else
        //         {
        //             Console.WriteLine("Masukkan pilihan yang valid.");
        //         }
        //     }
        // }
    }
}
