public abstract class NewsReader : INewsObserver
{
    protected string name;

    public NewsReader(string name)
    {
        this.name = name;
    }

    public void Update(string message)
    {
        Console.WriteLine($"{name} received news update: {message}");
        React(message); // Panggil metode React untuk menanggapi berita
    }

    // Metode React yang harus diimplementasikan oleh setiap pengamat konkret
    public abstract void React(string message);
}
