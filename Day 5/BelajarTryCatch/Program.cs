class Program 
{
    static void Main()
    {
        //Baris kedua masukin ke try

        //Format Exeption
        //string a = "nana23";
        //int aNum = int.Parse(a);

        //Divided by zero exeption
        // int x = 10, y = 0;
        // int result = x /y;

        // IndexOutOfRangeException
        // int[] someArray = {1,2,3,4};
        // System.Console.WriteLine(someArray[4]);

        //NullReferencesException
        // string nama = null;
        // System.Console.WriteLine(nama.Length);   

        // Stack overflow Exception
        // static void Run()
        // {
        //     Run();
        // }
        // Masukin Try => Run();

        try
        {

        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);   
        }

    }
}