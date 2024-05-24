class Program
{
    static void Main(string[] args)
    {
        InstanceCreateor();
        GC.Collect();
        GC.WaitForPendingFinalizers();
        System.Console.WriteLine("Wait for the next Order");
    }

    static void InstanceCreateor()
    {
        Child child= new Child();
    }
}

public class GrandParent
{
    ~GrandParent()
    {
        System.Console.WriteLine("GrandParent Elimineted");
        System.Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
    }
}

public class Parent : GrandParent
{
    ~Parent()
    {
        System.Console.WriteLine("Parent Elimineted");
        System.Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
    }
}

public class Child : Parent
{
    ~Child()
    {
        System.Console.WriteLine("Child Elimineted");
        System.Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
    }
}