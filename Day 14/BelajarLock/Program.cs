using System;
using System.Threading;

namespace Threading_with_lock
{
    class lookup
    {
        //apa ini
        private static readonly object lockObject = new object();

        static void Main(string[] args)
        {
            Thread one = new Thread(PrntChar);
            Thread two = new Thread(PrntChar);
            one.Start();
            two.Start();

            Console.ReadLine();
        }

        public static void PrntChar()
        {
            string strArray = "Hi programmer";

            lock (lockObject) // Mengunci akses ke resource bersama
            {
                for (int y = 0; y < strArray.Length; y++)
                {
                    Console.Write($"{strArray[y]}");
                    Thread.Sleep(TimeSpan.FromSeconds(0.1));
                }
                Console.WriteLine(" ");
            }
        }
    }
}
