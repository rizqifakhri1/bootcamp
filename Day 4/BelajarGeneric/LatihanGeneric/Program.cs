using System;

public class GenericClass<T1, T2>
{
    public T1 Message;

    public void GenericMethod(T1 name, T1 location, T2 age)
    {
        Console.WriteLine($"Message : {Message}");
        Console.WriteLine($"Name : {name}");
        Console.WriteLine($"Location : {location}");
        Console.WriteLine($"Age: {age}");
    }
}

class Program
{
    static void Main()
    {
        GenericClass<string, int> myGenericClass = new GenericClass<string, int>
        {
            Message = "Welcome to Bootcamp"
        };

        myGenericClass.GenericMethod("Dewi Idda", "Salatiga", 25);
    }
}
