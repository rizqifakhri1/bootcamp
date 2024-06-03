using UnoGame;
using UnoGame.Interface;

class Program
{
    static async Task Main()
    {
        //Inisiasi Object Game Controller untuk masing" property
        var gameControl = new GameController
        {
            GameInfo = ConsolePrint,
            GetInput = GetConsoleInput,
            Divider = ConsoleDivider
        };

        Console.Clear();
        DisplayAsciiArt();
        //Mengambil Inputan User untuk menentukan jumlah player
        int numOfPlayers = GetNumberOfPlayers();
        //Menambahkan Player ke GameController
        gameControl.AddPlayers(numOfPlayers);

        Console.Clear();
        // Console.WriteLine("Drawing first card...");
        Console.WriteLine("┌──────────────────────────────────────────────────────────────────┐");
        Console.WriteLine("│                      Drawing first card...                       │");
        Console.WriteLine("└──────────────────────────────────────────────────────────────────┘");
        await AnimateLoading("Preparing game", 3); // 3 detik animasi loading
        var firstCard = gameControl.PrepareGame();
        Console.WriteLine();
        Console.WriteLine("First Card:");
        UserInterface.DisplayCard(firstCard);
        // await Task.Delay(500);

        Console.WriteLine();
        Console.WriteLine("Starting Game!");
        await AnimateLoading("Starting game", 3); // 3 detik animasi loading
        await gameControl.PlayGame();


        Console.WriteLine($"Game Winner: {gameControl.WinnerOrder.First().Name}");
        gameControl.DisplayWinnerOrder();
    }

    static int GetNumberOfPlayers()
    {
        int numOfPlayers;
        Console.WriteLine();
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine("---------- Welcome to Uno Game ----------");
        Console.WriteLine("----- Enter Number of Players (2-4) -----");
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine();
        Console.Write("Players : ");
        // Pengecekan Input
        while (!int.TryParse(Console.ReadLine(), out numOfPlayers) || numOfPlayers is > 4 or < 2)
        {
            Console.WriteLine();
            Console.WriteLine("Invalid Input. Please Enter number of players again (2-4):");
            Console.WriteLine();
        }
        return numOfPlayers;
    }

    public static void ConsolePrint(string inputString) => Console.WriteLine(inputString);

    public static string GetConsoleInput(string description)
    {
        Console.WriteLine(description);
        return Console.ReadLine() ?? string.Empty;
    }

    public static void DisplayAsciiArt()
    {
        Console.WriteLine("      ___           ___           ___     ");
        Console.WriteLine("     /\\  \\         /\\  \\         /\\  \\    ");
        Console.WriteLine("     \\:\\  \\        \\:\\  \\       /::\\  \\   ");
        Console.WriteLine("      \\:\\  \\        \\:\\  \\     /:/\\:\\  \\  ");
        Console.WriteLine("  ___  \\:\\  \\   _____\\:\\  \\   /:/  \\:\\  \\ ");
        Console.WriteLine(" /\\  \\  \\:\\__\\ /::::::::\\__\\ /:/__/ \\:\\__\\");
        Console.WriteLine(" \\:\\  \\ /:/  / \\:\\~~\\~~\\/__/ \\:\\  \\ /:/  /");
        Console.WriteLine("  \\:\\  /:/  /   \\:\\  \\        \\:\\  /:/  / ");
        Console.WriteLine("   \\:\\/:/  /     \\:\\  \\        \\:\\/:/  /  ");
        Console.WriteLine("    \\::/  /       \\:\\__\\        \\::/  /   ");
        Console.WriteLine("     \\/__/         \\/__/         \\/__/  ");
    }

    private static async Task AnimateLoading(string message, int durationSeconds)
    {
        Console.Write($"{message} [");
        int totalWidth = 20; // Lebar total dari loading bar
        int animationSteps = durationSeconds * 2; // Jumlah langkah animasi (hitungan setengah detik)
        int delay = durationSeconds * 1000 / animationSteps; // Delay untuk setiap langkah animasi
        int stepWidth = totalWidth / animationSteps; // Lebar yang harus ditambahkan setiap langkah

        for (int i = 0; i <= animationSteps; i++)
        {
            int barWidth = i * stepWidth; // Lebar loading bar saat ini
            Console.Write($"{new string('\u2588', barWidth)}{new string(' ', totalWidth - barWidth)}] {i * 100 / animationSteps}%");
            Console.SetCursorPosition(Console.CursorLeft - (totalWidth + 5), Console.CursorTop); // Kembali ke awal baris
            await Task.Delay(delay); // Menunggu sebelum langkah berikutnya
        }
        Console.WriteLine();
    }

    public static void ConsoleDivider() => Console.WriteLine("------------------------------------------------");
}
