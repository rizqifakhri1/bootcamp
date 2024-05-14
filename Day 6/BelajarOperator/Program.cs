class Program
{
    static void Main()
    {
        Box box1 = new(4,4);
        Box box2 = new(5,3);

        Box box3 = box1 + box2;
        System.Console.WriteLine(box3);
        //kalo ga pake length terakhirnya menggunakan code yang di komen ToString
        //kalau tidak menggunakan toSting bisa menggunakan .Length
    }
}


class Box
{
    public int Length { get; set; }
    public int Width { get; set; }

    public Box(int length, int width)
    {
        Length = length;
        Width = width;
    }

    public static Box operator +(Box b1, Box b2)
    {
        int length = b1.Length + b2.Length;
        int width = b1.Width + b2.Width;
        Box box = new(length, width);
        return box;
    }

    public override string ToString()
    {
        return $"Panjang: {Length}, Lebar: {Width}";
    }
}
