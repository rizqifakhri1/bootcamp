public class Animal 
{
    public virtual int Umur { get; set; }

    public virtual void Makan()
    {
        Console.WriteLine("Makanan Default");
    }
}

public class Cat : Animal
{
    public override int Umur { get; set; }

    public override void Makan()
    {
        Console.WriteLine("Makan Ikan");
    }
}

class Program
{
    static void Main()
    {
        Cat Billy = new Cat();
        Billy.Umur = 5;
        Console.WriteLine(Billy.Umur);
        Billy.Makan();
    }
}