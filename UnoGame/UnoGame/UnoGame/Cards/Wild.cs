using System;
using UnoGame.Enum;
namespace UnoGame.Cards;

public class Wild : Card
{
    public Wild(int id, ColorVariants color, CardVariants type) : base(id, color, type)
    {
        ID = id;
        Type = type;
        Color = color;
    }

    public override CardVariants ExecuteCardEffect(GameController gameController)
    {
        gameController.Divider.Invoke();
        gameController.GameInfo.Invoke("Change Color!\n");

        string inputColor = gameController.GetInput.Invoke("Choose Color (Red, Green, Blue, Yellow)");
        ColorVariants userPickColor;

        while (true)
        {
            inputColor = gameController.GetInput.Invoke("Choose Color (Red, Green, Blue, Yellow)");

            if (TryParseColor(inputColor, out userPickColor) && userPickColor != ColorVariants.None)
            {
                break; // Keluar dari loop jika input adalah warna yang valid dan bukan putih
            }

            gameController.GameInfo.Invoke("Invalid color choice. Please choose again.");
        }

        gameController.CurrentRevealCard.Color = userPickColor;
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





