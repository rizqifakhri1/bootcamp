using ProjectInheritance.Employee;
class Program 
{
    static void Main()
    {
        Marketing bambang = new Marketing();
        bambang.id = 123;
        bambang.name = "Bambang";
        bambang.gaji = 5000000;
        bambang.divisi= "Creative";

        Programmer siska = new Programmer();
        siska.id = 123;
        siska.name = "siska";
        siska.gaji = 3000000;
        siska.bPemrograman = "C#";
    }
}