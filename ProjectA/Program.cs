// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System.Diagnostics.Tracing;

class Cat 
{
    string color;
    string spesies;
    public void Eat()
    {
        Console.WriteLine("Cat Eat");
    }
}
class Program
{
    static void Main()
    {
        Cat Caty = new Cat();
        Caty.Eat();
    }
}