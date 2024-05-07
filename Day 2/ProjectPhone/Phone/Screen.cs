namespace ProjectPhone.Phone;

public class Screen
{
    public int ScreenSize;
    public string ScreenType;


    //Construcktor
    public Screen (int ScreenSize, string ScreenType)
    {
        this.ScreenSize = ScreenSize;
        this.ScreenType = ScreenType;
    }

    public void PrintSpec()
    {
        Console.WriteLine(ScreenSize);
        Console.WriteLine(ScreenType);
    }
}
