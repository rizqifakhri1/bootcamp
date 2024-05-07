namespace ProjectPhone.Card;

public class Card
{
    public string Provider;
    public string NetworkType;

    public Card(string Provider, string NetworkType)
    {
        this.Provider = Provider;
        this.NetworkType = NetworkType;
    }

    public void PrintSpec()
    {
        Console.WriteLine($"Provider Jaringan : {Provider}");
        Console.WriteLine($"Tipe Jaringan : {NetworkType}");
    }

    
}
