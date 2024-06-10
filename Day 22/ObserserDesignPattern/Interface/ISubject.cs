public interface ISubject
{
    void Attach(INewsObserver observer);
    void Detach(INewsObserver observer);
    void Notify();
}