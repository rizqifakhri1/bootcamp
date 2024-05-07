namespace ProjectInheritance.Employee;

public class Marketing : Employee
{
    public string divisi ;

    public Marketing(int id, string name, int  gaji, string divisi): base ()
    {
        // this.id = id;
        // this.name = name;
        // this.gaji = gaji;
        this.divisi = divisi;

    }
}