// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System.Diagnostics.Tracing;

// Field
class Cat 
{
    string color;
    string spesies;
    public void Eat()
    {
        // Object
        Console.WriteLine("Cat Eat");
    }
}
class Program
{
    static void Main()
    {
        //Object
        Cat Caty = new Cat();
        Caty.Eat();
    }
}