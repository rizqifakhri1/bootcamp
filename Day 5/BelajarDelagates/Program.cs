using System;

public delegate void MyDelegate();

class Program
{
    static void Main()
    {
        MyDelegate my = new MyDelegate(Print);
        my += Run;
        my.Invoke();

    }

    static void Print()
    {
        Console.WriteLine("Hello Dunia");
    }

    static void Run() 
    {
        System.Console.WriteLine("Lari Cukkk");
    }
}
