namespace ProjectPhone.Phone;

public class Chip
{
    public string Manufacture;
    public int Ram;
    public int CpuCore;

    //Construcktor
    public Chip(string Manufacture, int Ram, int CpuCore)
    {
        this.Manufacture = Manufacture;
        this.Ram = Ram;
        this.CpuCore = CpuCore;
    }

    public void PrintSpec()
    {
        Console.WriteLine(Manufacture);
        Console.WriteLine(Ram);   
        Console.WriteLine(CpuCore);
    }
}

