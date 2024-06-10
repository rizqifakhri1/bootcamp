namespace ObserserDesignPattern.Reader;

public class Reader2 : NewsReader
{
    public Reader2(string name) : base(name)
    {
    }

    public override void React(string message)
    {
        Console.WriteLine($"{name} says: This seems like spam!");
    }
}
