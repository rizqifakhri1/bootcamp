namespace ProjectInheritance.Employee;


public class Programeer : Employee
{
    public string bPemrograman;
    public Programeer (int id, string name, int  gaji, string bPemrograman): base() 
    //kalau di parent ga ada parameter di kosongin aja ntuk base
    {
        // this.id = id;
        // this.name = name;
        // this.gaji = gaji;
        this.bPemrograman = bPemrograman;
    }
}