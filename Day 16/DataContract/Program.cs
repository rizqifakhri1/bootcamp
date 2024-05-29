using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

[DataContract]
class Player
{
    [DataMember]
    private string _name;
    [DataMember]
    private int _money;
    [DataMember]
    public int Gold { get; set; }
    [DataMember]
    public int Exp { get; set; }

    public Player(string name, int money, int gold, int exp)
    {
        _name = name;
        _money = money;
        Gold = gold;
        Exp = exp;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetMoney()
    {
        return _money;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Player juan = new Player("Juan", 500, 300, 100);
        Player reno = new Player("Redo", 400, 200, 50);
        Player didi = new Player("Didi", 700, 100, 300);

        List<Player> players = new List<Player>()
        {
            juan, reno, didi
        };

        DataContractJsonSerializer serializer = new(typeof(List<Player>));
        using (FileStream fs = new("player.json", FileMode.Create))
        {
            serializer.WriteObject(fs, players);
        }
    }
}