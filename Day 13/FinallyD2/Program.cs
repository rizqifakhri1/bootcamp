class Program 
{
    static void Main(string[] args) 
    {
        try 
        {
            string a = "3a";
            int b = int.Parse(a);   //Error           
        }
        catch (FormatException e)
        {
            System.Console.WriteLine("Format Excepation");
        }
        finally
        {
            Console.WriteLine("Program Close");
        }
    }
}