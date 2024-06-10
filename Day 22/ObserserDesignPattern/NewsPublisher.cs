public class NewsPublisher : ISubject
{
    private List<INewsObserver> observers = new List<INewsObserver>();
    private string news;

    public string News
    {
        get { return news; }
        set
        {
            news = value;
            Notify(); // Ketika ada berita baru, semua pengamat diberitahu
        }
    }

    public void Attach(INewsObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(INewsObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (INewsObserver observer in observers)
        {
            observer.Update(news);
        }
    }
}
