using System;

class Program
{
    static void Main()
    {
        Action<string, string> Sapa = Menyapa.sayHi;
        Sapa("Rizqi", "Fakhri");
    }
}

class Menyapa
{
    // Akses modifier pada method otomatis kalau tidak di tuliskan private
    public static void sayHi(string firstName, string lastName)
    {
        string fullName = firstName + " " + lastName;
        Console.WriteLine("Halo " + fullName);
    }
}
