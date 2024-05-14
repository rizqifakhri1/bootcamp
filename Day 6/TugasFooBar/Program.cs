using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        //membuat object generator
        FooBarGenerator generator = new FooBarGenerator();
        System.Console.WriteLine("FooBar Generator");
        System.Console.WriteLine("----------------");
        Console.Write("Masukan Nilai : ");
        string input = Console.ReadLine();

        int inputUser;

        // Option 1 - Kalau mau pake If Else
        // if (!int.TryParse(input, out inputUser))
        // {
        //     Console.WriteLine("Input harus berupa angka.");
        //     return;
        // }

        // Option 2 - Kalau mau pake Try & Catch
        try
        {
            inputUser = int.Parse(input);
        }
        catch (FormatException)
        {
            Console.WriteLine($"Input harus berupa angka, Input Kamu :{input}");
            return;
        }

        List<string> results = generator.Generate(inputUser);
        foreach (var result in results)
        {
            Console.WriteLine(result);
        }
    }
}

