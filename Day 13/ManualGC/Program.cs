class Program
{
    static void Main(string[] args)
    {
        Garbage garbage = new Garbage();
        garbage.Greeating();
        GC.Collect(); //GC Manual
        // Console.ReadKey();
    }
}

class Garbage
{
    public void Greeating()
    {
        Console.WriteLine("Aku Sampah");
    }
    //Kenapa Destructor tidak di sarankan?
    // Di Desctructor akan memarking rootnya 
    ~Garbage() //Destructor
    {
        System.Console.WriteLine("Aku Hancur :(");
    }
}
