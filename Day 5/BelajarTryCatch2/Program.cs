static void ExceptionMaker()
{
    string a = "nana23";
    int x = 5, y = 10;

    public void StringToInt()
    {
        int aNum = int.Parse(a);
    }

    public void DividedZero()
    {
        int result = x /y;
    }
}

class Program
{
    static void Main()
{
    try
    {
        ExceptionMaker();
    }
    catch (FormatException e)
    {
        System.Console.WriteLine(e.Message);  
    }
    catch (IndexOutOfRangeException e)
    {
        System.Console.WriteLine(e.Message);  
    }
}
}