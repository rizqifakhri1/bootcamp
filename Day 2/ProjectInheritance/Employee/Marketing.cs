namespace ProjectInheritance.Employee;

public class Marketing : Employee
{
    public string divisi ;

    public Marketing(int id, string name, int  gaji, string divisi): base (id, name, gaji)
    {
        this.divisi = divisi;

    }
}