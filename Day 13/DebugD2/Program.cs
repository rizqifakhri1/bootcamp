using System;

class Program 
{
    public static void Main(string[] args)
    {
        Pertambahan hehe = new Pertambahan();
        int hasil = hehe.Tambah(1, 3);
        Console.WriteLine(hasil);
    }
}

class Pertambahan
{
    public int Tambah(int a, int b) {
        return a + b;
    }
}
