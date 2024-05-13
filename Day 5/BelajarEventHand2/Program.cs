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
    public void EnemyKilled(object sender, EventArgs e)
    {
        System.Console.WriteLine("Musuh Terbunuh, Naik Level");
    }
}

class Program
{
    static void Main()
    {
        LevelUp levelUp = new();
        Enemy enemy = new();

        // Event Handler
        enemy.Terpukul += levelUp.EnemyKilled;

        enemy.Pukul();
    }
}