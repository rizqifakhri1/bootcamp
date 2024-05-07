namespace ProjectInheritance.Employee;

public class Mechanic: Employee
{
    public string jenisMesin;

    public Mechanic (int id, string name, int gaji, string jenisMesin):base(id, name, gaji) 
    {
        this.jenisMesin = jenisMesin;
    }

}
