using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Nama file yang akan dibuat dan ditulis
        string filePath = "textSteamWriter.txt";

        // Teks yang akan ditulis ke file
        string text = "Selamat Siang Dunia";

        // Menggunakan StreamWriter untuk menulis teks ke file
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine(text);
        }

        // Memberitahukan bahwa penulisan selesai
        Console.WriteLine("Teks telah berhasil ditulis ke file.");
        Console.ReadLine();
    }
}
