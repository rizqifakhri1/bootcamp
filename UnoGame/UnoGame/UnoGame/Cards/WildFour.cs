using UnoGame.Enum;
namespace UnoGame.Cards;

public class WildFour: Card
{
     public WildFour(int id, ColorVariants color, CardVariants type) : base(id, color, type)
    {
        ID = id;
        Type = type;
        Color = color;
    }
    // public override CardVariants ExecuteCardEffect(GameController gameController)
    // {
    //     gameController.Divider.Invoke();
    //     gameController.GameInfo.Invoke("Change Color!\n");

    //     string inputColor = gameController.GetInput.Invoke("Choose Color (Red, Green, Blue, Yellow)");
    //     ColorVariants userPickColor;

    //     if (!TryParseColor(inputColor, out userPickColor))
    //     {
    //         gameController.GameInfo.Invoke("Invalid color choice. Please choose again.");
    //         return CardVariants.Wild; // atau lakukan sesuatu yang sesuai dengan logika aplikasi Anda
    //     }

    //     gameController.Divider.Invoke();
    //     gameController.GameInfo.Invoke($"{gameController.NextPlayer.Name} Draw Four Card");
    //     for (int i=0; i<4; i++)
    //     {
    //         gameController.PlayerDrawCard(gameController.NextPlayer);
    //     }

    //     gameController.CurrentRevealCard.Color = userPickColor;
    //     gameController.NextTurn();
    //     gameController.Divider.Invoke();
    //     return CardVariants.Wild;
    // }
    public override CardVariants ExecuteCardEffect(GameController gameController)
{
    gameController.Divider.Invoke();
    gameController.GameInfo.Invoke("Change Color!\n");

    ColorVariants userPickColor;
    string inputColor;

    while (true)
    {
        inputColor = gameController.GetInput.Invoke("Choose Color (Red, Green, Blue, Yellow)");

        if (TryParseColor(inputColor, out userPickColor) && userPickColor != ColorVariants.None)
        {
            break; // Keluar dari loop jika input adalah warna yang valid dan bukan putih
        }

        gameController.GameInfo.Invoke("Invalid color choice. Please choose again.");
    }

    gameController.Divider.Invoke();
    gameController.GameInfo.Invoke($"{gameController.NextPlayer.Name} Draw Four Card");
    for (int i = 0; i < 4; i++)
    {
        gameController.PlayerDrawCard(gameController.NextPlayer);
    }

    gameController.CurrentRevealCard.Color = userPickColor;
    gameController.NextTurn();
    gameController.Divider.Invoke();
    return CardVariants.Wild;
}


    // Fungsi untuk mengonversi string menjadi enum ColorVariants
    public static bool TryParseColor(string input, out ColorVariants color)
    {
        input = input.ToLower(); // Ubah ke huruf kecil untuk mempermudah perbandingan

        if (input == "red")
        {
            color = ColorVariants.Red;
            return true;
        }
        else if (input == "green")
        {
            color = ColorVariants.Green;
            return true;
        }
        else if (input == "blue")
        {
            color = ColorVariants.Blue;
            return true;
        }
        else if (input == "yellow")
        {
            color = ColorVariants.Yellow;
            return true;
        }
        else
        {
            color = default(ColorVariants);
            return false;
        }
    }
}
