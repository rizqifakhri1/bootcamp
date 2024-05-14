// 3 foo
// 5 bar
// User input => n

// n = 15
// 0, 1, 2, foo, 4, bar, foo, 7, 8, foo, bar, 11, foo, 13, 14, foobar

using System;

class Program
{
    static void Main()
    {
        string foo = "Foo";
        string bar = "Bar";
        string foobar = "FooBar";
        System.Console.Write("Masukan Nilai : ");
        string input = Console.ReadLine();
        int inputUser =  Convert.ToInt32(input) + 1;
        int i = 0;

        for (i = 0; i < inputUser; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                System.Console.WriteLine(foobar);
            }
            else if (i % 3 == 0)
            {
                System.Console.WriteLine(foo);
            }
            else if (i % 5 == 0)
            {
                System.Console.WriteLine(bar);
            }
            else
            {
                System.Console.WriteLine(i);
            }
        }
    }
}