using ObserserDesignPattern.Reader;
class Program
{
    static void Main(string[] args)
    {
        // Buat publisher (subjek)
        NewsPublisher publisher = new NewsPublisher();

        // Buat beberapa pengamat dengan reaksi yang berbeda
        Reader1 reader1 = new Reader1("Reader 1");
        Reader2 reader2 = new Reader2("Reader 2");

        // Daftarkan pengamat ke subjek
        publisher.Attach(reader1);
        publisher.Attach(reader2);

        // Update berita yang secara otomatis akan memberitahu semua pengamat
        publisher.News = "News Upate : Kopi Sudah Restock";

        System.Console.WriteLine();
        System.Console.WriteLine("------------------------------------------------");
        System.Console.WriteLine();
        // Lepas satu pengamat dan update berita lagi
        publisher.Detach(reader2);
        publisher.News = "News Update : Kopi Sudah Habis";

    }
}
