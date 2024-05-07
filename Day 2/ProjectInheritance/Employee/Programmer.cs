namespace ProjectInheritance.Employee;


public class Programmer : Employee
{
    public string bPemrograman;
    public Programmer (int id, string name, int  gaji, string bPemrograman): base(id, name, gaji) 
    //kalau di parent ga ada parameter di kosongin aja ntuk base
    {
        this.bPemrograman = bPemrograman;
    }
}