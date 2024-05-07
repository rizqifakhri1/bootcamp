using ProjectPhone.Phone;

class Program
{
    static void Main()
    {
        Chip chip = new Chip("Snapdragon", 4, 8);
        Screen screen = new Screen(6, "Amoled");
        SmartPhone smartPhone = new SmartPhone("Samsung", "Galaxy S22", chip, screen);

        smartPhone.PrintSpec();
    }
}