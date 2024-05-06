// See https://aka.ms/new-console-template for more information
class SmartPhone 
{
    string color;
    string BrandName;
    int Camera;
    int RAM;
    int ScreenSize;
    

    public void TakePitcure()
    {
        Console.WriteLine("Cekrek");
    }

    public void Call()
    {
        Console.WriteLine("Ting Ting Ting ada Telfone");
    }

    public void PlayGames()
    {
        Console.WriteLine("Welcome to Mobile Legend")
    }

    public void Chat()
    {
        Console.WriteLine("Kirim Pesan")
    }

    public void Alarm()
    {
        Console.WriteLine("Alarm Berbunyi")
    }   
}

class Program
{
    static void Main()
    {
        SmartPhone Nokia = new SmartPhone()
        Nokia.PlayGames();
    }
}