public class Cat 
{
    public string FavFood;

    public string CatName;

    public Cat(string FavFood, string CatName) //overloading 2 parameter
    {
        this.FavFood = FavFood;
        this.CatName = CatName;
    }

    public void eat()
    {
        Console.WriteLine(CatName + " makan " + FavFood);
    }

    public void PrintInfo()
    {
        Console.WriteLine(CatName + " " + FavFood);
    }

    public void PrintInfo(string CatName) //Overloading
    {
        Console.WriteLine(CatName);
    }

    public void PrintInfo(string CatName, string FavFood) //Overloading
    {
        Console.WriteLine(CatName + " dan " + FavFood );
    }

    
}

class Program
{
    static void Main()
    {
        Cat Caty = new Cat("Wiskas", "Caty");
        Caty.eat();
        Caty.PrintInfo(Caty.CatName);
        Caty.PrintInfo(Caty.CatName, Caty.FavFood);

    }
}