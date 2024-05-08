//Penggunaan static
public static class Calculator
{
    public static double PI = 3.14;

    public static double Add(double a, double b)
    {
        return a + b;
    }

    public static double Kurang(double a, double b)
    {
        return a - b;
    }

    public static double Kali (double a, double b)
    {
        return a * b;
    }
} 

//Besarin Font
public static class MethodUpper
{
    public static string ToUpper(this string input) // masih bingung this (this string input) -> untuk mempermudah pembacaan
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        return input.ToUpper();
    }
}

public class Program 
{
    static void Main()
    { 
        // Calculator.Add(3, 5);
        // Console.WriteLine(Calculator.Add(3, 5));

        double Hitung = Calculator.Add(3, 5);
        Console.WriteLine("Hasil Tambah " + Hitung);

        Console.WriteLine("Hasil Kurang : " + Calculator.Kurang(3, 5));
        Console.WriteLine("Hasil Kali : " + Calculator.Kali(3, 5));


        string msg = "Halo Dunia Tipu-Tipu";
        Console.WriteLine(MethodUpper.ToUpper(msg));
    }
}