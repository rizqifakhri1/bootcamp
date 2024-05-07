using ProjectPhone.Phone;
using ProjectPhone.Card;

class Program
{
    static void Main()
    {
        Chip chip = new Chip("Snapdragon", 4, 8, 3);
        Screen screen = new Screen(6, "Amoled");
        SmartPhone smartPhone = new SmartPhone("Samsung", "Galaxy S22", chip, screen);
        Card card = new Card("Telkomsel", "4G");

        smartPhone.PrintSpec();
        card.PrintSpec();
    }
}