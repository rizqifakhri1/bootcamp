class Program 
{
    static void Main()
    {
        Circle circle = new Circle();
        Rectangle rct = new Rectangle();

        // circle.ChangeColor("Green");
        circle.Draw();
        circle.ChangeColor("Green");
    

        rct.ChangeColor("Merah");
        rct.Draw();
    }
}

class Circle : OutlineColor, IShape
{
    public void Draw()
    {
        Console.WriteLine("Draw Circle - Interface");
    }

    public override void ChangeColor(string color)
    {
        Console.WriteLine("Color Change to " + color);
    }
}

class Rectangle : Shape, IShape 
{
    public override void Draw()
    {
        Console.WriteLine("Draw Rectangle - abstract");
    }
}

abstract class OutlineColor 
{
    public abstract void ChangeColor(string color);
}

abstract class Shape 
{
    public abstract void Draw();
    public void ChangeColor(string color)
    {
        Console.WriteLine("Color Change to " + color);
    }
}

interface IShape 
{
    void Draw();
}