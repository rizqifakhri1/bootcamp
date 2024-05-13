public class Enemy
{
    public event EventHandler Terpukul;

    public void Pukul()
    {
        System.Console.WriteLine("Musuh Terpukul");
        Terpukul?.Invoke(this, EventArgs.Empty);
    }
}

public class LevelUp
{
    public void HandlerEnemyKilled(object sender, EventArgs e)
    {
        System.Console.WriteLine("Musuh Terbunuh, Naik Level");
    }
    public void ShowLevel(int level)
    {
        Console.WriteLine($"Level saat ini: {level}");
    }

}

class Program
{
    static void Main()
    {
        LevelUp levelUp = new();
        Enemy enemy = new();

        // Event Handler
        enemy.Terpukul += levelUp.HandlerEnemyKilled;

        enemy.Pukul();

        levelUp.ShowLevel(2);
    }
}