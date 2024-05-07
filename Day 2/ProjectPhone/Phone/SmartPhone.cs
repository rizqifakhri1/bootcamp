namespace ProjectPhone.Phone;

public class SmartPhone
{
    public string Brand;
    public string Type;
    public Chip chip;
    public Screen Screen;

    public Battery battery;

    public SmartPhone(string Brand, string Type, Chip chip, Screen screen, Battery battery)
    {
        this.Brand = Brand;
        this.Type = Type;
        this.chip = chip;
        this.Screen = screen;
        this.battery = battery; 
    }

    public void PrintSpec()
    {
        Console.WriteLine($"Phone Manufacture : {Brand}");
        Console.WriteLine($"Phone Type : {Type}");
        Console.WriteLine($"Chip : {chip.Ram} Manufacure : {chip.Manufacture}  Core : {chip.CpuCore} Size : {chip.Size}");
        Console.WriteLine($"Batrai Level : {battery.BatteryLevel}");
    }

}

