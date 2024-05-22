class Program 
{
    static void Main(string[] args) 
    {
        string result = String.Empty;
        int iteration = 10000;
        for (int i = 0; i < iteration; i++)
        {
            result += "Hello";
            result += "Word";
            System.Console.WriteLine(result);
        }
        // System.Console.ReadKey();
    }
}