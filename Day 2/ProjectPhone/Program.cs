using ProjectPhone.Phone;
using ProjectPhone.Card;

class Program
{
    static void Main()
    {
        Chip chip = new Chip("Snapdragon", 4, 8, 3);
        Screen screen = new Screen(6, "Amoled");
        Battery battery = new Battery(80);
        SmartPhone smartPhone = new SmartPhone("Samsung", "Galaxy S22", chip, screen, battery);
        Card card = new Card("Telkomsel", "4G");

        smartPhone.PrintSpec();
        card.PrintSpec();
        battery.Charge();
    }
}