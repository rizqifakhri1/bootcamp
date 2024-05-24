using System.Runtime.InteropServices;
class Program
{
    //dotnet run -c Debug
    static void Main() 
    {
        int a = 2;
        int b = 3;

        // dotnet run -c release
        #if DEBUG
            System.Console.WriteLine("Mode Debug");
            System.Console.WriteLine(a+b);
        #endif
        #if RELEASE
            System.Console.WriteLine("Mode Release");
            System.Console.WriteLine(a-b);
        #endif
        #if HEHEHE
            System.Console.WriteLine("Mode hehehe");
            System.Console.WriteLine(a*b);
        #endif
    }
}