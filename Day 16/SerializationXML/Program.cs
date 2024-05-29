using System.Text.Json;
using System.Xml.Serialization;

public class Human
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Addres { get; set; }

    public Human() { }
    
    public Human(string name, int age, string addres)
    {
        Name = name;
        Age = age;
        Addres = addres;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Human yusa = new Human("Yusa", 26, "TulungAgung");
        Human ega = new Human("Ega", 22, "Semarang");
        Human rizqi = new Human("Rizqi", 24, "Bandung");
        Human fadil = new Human("Fadil", 23, "Jakarta");
        Human dewi = new Human("Dewi", 25, "Pati");
        Human wulan = new Human("Wulan", 29, "Bandung");
        Human bella = new Human("Bella", 24, "Kediri");
        Human jun = new Human("Jun", 23, "Balikpapan");

        List<Human> bootcamp = new List<Human>() { 
            yusa, ega, rizqi, fadil, dewi, wulan, bella, jun
        };

        XmlSerializer xmlSerializer= new XmlSerializer(typeof(Human));
        using (StreamWriter sw = new StreamWriter("file.xml"))
        {
            xmlSerializer.Serialize(sw, bootcamp);
        }

        // Deserialize
        // string result;
        // using(StreamReader sr = new("filekita.json"))
        // {
        //     result = sr.ReadToEnd();
        // }

        // List<Human> bootcamp = JsonSerializer.Deserialize<List<Human>>(result);
        // foreach(var human in bootcamp)
        // {
        //     System.Console.WriteLine(human.Name + " -> " +  human.Age);
        //     System.Console.WriteLine();
        // }
    }
}
