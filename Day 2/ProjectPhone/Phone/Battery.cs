namespace ProjectPhone.Phone;

public class Battery
{
    public int BatteryLevel;

    public Battery (int BatteryLevel)
    {
        this.BatteryLevel = BatteryLevel;
    }

    public void Charge() 
    {
        if (BatteryLevel == 100) {
            Console.WriteLine("Battery Penuh");
        } else {
            BatteryLevel += 10;
            Console.WriteLine($"Setelah Di Charge : {BatteryLevel}");
        } 
    }
}
