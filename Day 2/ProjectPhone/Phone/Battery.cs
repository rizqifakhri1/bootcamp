namespace ProjectPhone.Phone;

public class Battery
{
    public int BatteryLevel { get; set; } //Get set untuk menerima return kembali

    public Battery(int BatteryLevel)
    {
        this.BatteryLevel = BatteryLevel;
    }

    public int Charge() // Menyatakan tipe pengembalian int
    {
        if (BatteryLevel == 100)
        {
            Console.WriteLine("Battery Penuh");
        }
        else
        {
            BatteryLevel += 10;
            Console.WriteLine($"Setelah Di Charge : {BatteryLevel}");
        }

        return BatteryLevel; // Mengembalikan nilai BatteryLevel
    }

    // public void ChargeInfo()
    // {
    //     Console.WriteLine(BatteryLevel);
    // }
}
