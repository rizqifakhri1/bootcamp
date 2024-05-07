namespace ProjectPhone.Phone;

public class SmartPhone
{
    public string Brand;
    public string Type;
    public Chip chip;
    public Screen Screen;

    public SmartPhone(string Brand, string Type, Chip chip, Screen screen)
    {
        this.Brand = Brand;
        this.Type = Type;
        this.chip = chip;
        this.Screen = screen;
    }

    public void PrintSpec()
    {
        Console.WriteLine($"Phone Manufacture : {Brand}");
        Console.WriteLine($"Phone Type : {Type}");
        Console.WriteLine($"Chip : {chip.Ram} Manufacure : {chip.Manufacture}  Core : {chip.CpuCore} Size : {chip.Size}");
    }

}

