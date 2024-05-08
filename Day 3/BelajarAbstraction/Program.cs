class Program 
{
    static void Main()
    {
        Circle circle = new Circle();
        Rectangle rct = new Rectangle();

        // circle.ChangeColor("Green");
        circle.Draw();
        circle.ChangeColor("Green");
        circle.Size();
        circle.Tools();
        circle.Volume();
        circle.Rotate(40);
    
        rct.Draw();
        rct.ChangeColor("Merah");
        rct.Size();
        rct.Volume();
    }
}

class Circle : OutlineColor, IShape, IDrawWith, ISize, IVolume
{
    public void Draw()
    {
        Console.WriteLine("Draw Circle - Interface");
    }

    public override void ChangeColor(string color)
    {
        Console.WriteLine("Color Change to " + color);
    }

    public void Tools()
    {
        Console.WriteLine("Draw with : Pen");
    }

    public void Size() 
    {
        Console.WriteLine("Size of Circle : 100 cm");
    }

    public void Volume()
    {
        Console.WriteLine("Volume of Circle : 50 L");
    }

    public void Rotate(int numOfRotation)
    {
        Console.WriteLine("Besar Rotasi : " + numOfRotation);
    }
}

class Rectangle : Shape, IShape, IVolume
{
    public override void Draw()
    {
        Console.WriteLine("Draw Rectangle - abstract");
    }

    public void Size()
    {
        Console.WriteLine("Hasil Size - Rectangle - Interface&Abstak");
    }

    // perlu ada overide karena volume menggunakan abstrak dan tidak menggunakan body
    public override void Volume()
    {
        Console.WriteLine("Hasil Volume - Rectangle - Interface&Abstak");
    }
}

abstract class OutlineColor 
{
    public abstract void ChangeColor(string color);
}

abstract class Shape : ISize, IVolume
{
    //contoh menggunakan abstrak
    public abstract void Draw();

    //Disini harusnya menggunakan abstract untuk memanggil interface, akan tetapi karena sudah ada bodynya maka tidak perlu
    //Kalau disini menggunakan abstrak, maka body hilang, dan untuk Class wajib menggunakan override

    public void Size()
    {
        Console.WriteLine("Size dari Abstrack");
    }

    //contoh menggunakan abstrak
    public abstract void Volume();

    public void ChangeColor(string color)
    {
        Console.WriteLine("Color Change to " + color);
    }
}

interface IShape 
{
    void Draw();
}

interface ISize
{
    void Size();
}

interface IVolume
{
    void Volume();
}

interface IDrawWith
{
    void Tools();
}

interface IRotate
{
    void Rotate(int numOfRotation);
}
