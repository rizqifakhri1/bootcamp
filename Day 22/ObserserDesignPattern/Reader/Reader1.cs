namespace ObserserDesignPattern.Reader;
public class Reader1 : NewsReader
{
    public Reader1(string name) : base(name)
    {
    }

    public override void React(string message)
    {
        Console.WriteLine($"{name} says: Thank you for the news!");
    }
}