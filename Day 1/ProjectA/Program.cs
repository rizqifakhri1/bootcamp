
class Cat 
{
		// Field
    string color;
    string spesies;
    //Method
    public void Eat()
    {
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