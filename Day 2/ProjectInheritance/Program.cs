using ProjectInheritance.Employee;
class Program
{
    static void Main()
    {
        // test SourceTree Push Error
        // Marketing bambang = new Marketing();
        // bambang.id = 123;
        // bambang.name = "Bambang";
        // bambang.gaji = 5000000;
        // bambang.divisi= "Creative";

        // Programmer siska = new Programmer();
        // siska.id = 123;
        // siska.name = "siska";
        // siska.gaji = 3000000;
        // siska.bPemrograman = "C#";

        Marketing bambang = new Marketing(123, "Bambang", 5000000, "Creative");
        Programmer siska = new Programmer(234, "Siska", 3000000, "C#");
        Mechanic forsaken = new Mechanic(345, "Forsaken", 4000000, "Car");

        // Cetak informasi pegawai
        Console.WriteLine("Marketing:");
        Console.WriteLine($"ID: {bambang.id}, Name: {bambang.name}, Salary: {bambang.gaji}, Division: {bambang.divisi}");

        Console.WriteLine("\nProgrammer:");
        Console.WriteLine($"ID: {siska.id}, Name: {siska.name}, Salary: {siska.gaji}, Programming Language: {siska.bPemrograman}");

        Console.WriteLine("\nMechanice:");
        Console.WriteLine($"ID: {forsaken.id}, Name: {forsaken.name}, Salary: {forsaken.gaji}, Handle Jenis Mesin: {forsaken.jenisMesin}");
    }
}

