class Car 
{
    public Car()
    {
        System.Console.WriteLine("Constructor are Created");
    }

    ~Car()
    {
        System.Console.WriteLine("Destructro are called");
    }
}

class Program 
{
    static void Main(string[] args) 
    {
        Car car = new Car();
        System.Console.ReadKey();
    }
    
}