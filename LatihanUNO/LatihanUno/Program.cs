using System;
using System.Collections.Generic;
using LatihanUno.Enum;
using LatihanUno.Interface;

class Program
{
    static void Main()
    {
        Console.Clear();
        int numOfPlayers;
        Console.WriteLine("Masukan Jumlah Pemain (2-4) : ");
        while (!int.TryParse(Console.ReadLine(), out numOfPlayers) || numOfPlayers > 4 || numOfPlayers < 2)
        {
            Console.WriteLine("Invalid Input, Coba Lagi (2-4) : ");
        }
        for (int i = 0; i < numOfPlayers; i++)
        {
            int indexPlayer = i + 1;
            string playerName = "";

            Console.WriteLine($"Masukan Nama Pemain Ke {indexPlayer}");
            while (string.IsNullOrWhiteSpace(playerName))
            {
                playerName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(playerName))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Pemain Ke {indexPlayer}, Belum Memasukan Nama, Silakan masukkan lagi:");
                    Console.ResetColor();
                }
            }

            // Lanjutkan dengan logika Anda yang lain, misalnya menyimpan nama pemain
        }

        Console.Clear();
        System.Console.WriteLine("┌──────────────────────────────────────────────────────────────────┐");
        System.Console.WriteLine("│                             PLAYER A                             │");
        System.Console.WriteLine("└──────────────────────────────────────────────────────────────────┘");
        System.Console.WriteLine("--------------------------------------------------------------------");
        System.Console.WriteLine("---------------------------- Kartu Aktif ---------------------------");
        System.Console.WriteLine("--------------------------------------------------------------------");


        Number number = Number.One;
        Colors selectedColor = Colors.Yellow;
        int activeCard = 5;
        Console.ForegroundColor = ConvertColor(selectedColor);
        // Print the card
        System.Console.WriteLine();
        Console.WriteLine("┌─────┐");
        Console.WriteLine("│     │");
        Console.WriteLine($"│  {activeCard}  │");
        Console.WriteLine("│     │");
        Console.WriteLine("└─────┘");
        System.Console.WriteLine();
        Console.ResetColor();

        System.Console.WriteLine("--------------------------------------------------------------------");
        System.Console.WriteLine("---------------------------- Kartu Aktif ---------------------------");
        System.Console.WriteLine("--------------------------------------------------------------------");

        List<Card> cards = new List<Card>
        {
            new Card(Number.One, Colors.Red),
            new Card(Number.Two, Colors.Green),
            new Card(Number.Three, Colors.Blue),
            new Card(Number.Four, Colors.Yellow),
            new Card(Number.Six, Colors.Red),
            new Card(Number.Seven, Colors.Green),
            new Card(Number.Eight, Colors.Blue),
            new Card(Number.Nine, Colors.Yellow)

        };

        System.Console.WriteLine();
        PrintCards(cards);

        System.Console.WriteLine();
        System.Console.WriteLine("Pilih Index Dari Kartu ( ex : 4 )");
        System.Console.WriteLine();
        System.Console.WriteLine("[DrawCard] -> Press D		            [UnoCard]  -> Press U");
        System.Console.WriteLine("[SkipCard] -> Press S		            [UnoCard]  -> Press U");
        System.Console.WriteLine();
        System.Console.Write("Pilihan Kamu : ");
        string pilihan = Console.ReadLine();

        int selectedIndex;
        if (int.TryParse(pilihan, out selectedIndex) && selectedIndex >= 0 && selectedIndex < cards.Count)
        {
            // Jika input dapat diubah menjadi integer dan berada di dalam rentang indeks kartu
            Card selectedCard = cards[selectedIndex];
            Number numberSelect = selectedCard.Number;
            Colors selectedColorPlayed = selectedCard.Color;
            Console.ForegroundColor = ConvertColor(selectedColorPlayed);

            // Print the selected card
            System.Console.WriteLine();
            Console.WriteLine("┌─────┐");
            Console.WriteLine("│     │");
            Console.WriteLine($"│  {(int)numberSelect}  │");
            Console.WriteLine("│     │");
            Console.WriteLine("└─────┘");
            System.Console.WriteLine();
            Console.ResetColor();
        }
        else
        {
            // Jika input tidak valid
            System.Console.WriteLine("Pilihan tidak valid.");
        }


    }

    static void PrintCards(List<Card> cards)
    {

        foreach (var card in cards)
        {
            Console.ForegroundColor = ConvertColor(card.Color);
            Console.Write("┌─────┐ ");
        }
        Console.WriteLine();

        foreach (var card in cards)
        {
            Console.ForegroundColor = ConvertColor(card.Color);
            Console.Write("│     │ ");
        }
        Console.WriteLine();

        foreach (var card in cards)
        {
            Console.ForegroundColor = ConvertColor(card.Color);
            Console.Write($"│  {(int)card.Number}  │ ");
        }
        Console.WriteLine();

        foreach (var card in cards)
        {
            Console.ForegroundColor = ConvertColor(card.Color);
            Console.Write("│     │ ");
        }
        Console.WriteLine();

        foreach (var card in cards)
        {
            Console.ForegroundColor = ConvertColor(card.Color);
            Console.Write("└─────┘ ");
        }
        Console.WriteLine();
        foreach (var card in cards)
        {
            Console.ForegroundColor = ConvertColor(card.Color);
            int index = cards.IndexOf(card);
            Console.Write($"Idx : {index} ");
        }
        Console.WriteLine();
        Console.ResetColor();
    }

    static ConsoleColor ConvertColor(Colors color)
    {
        switch (color)
        {
            case Colors.Red:
                return ConsoleColor.Red;
            case Colors.Blue:
                return ConsoleColor.Blue;
            case Colors.Green:
                return ConsoleColor.Green;
            case Colors.Yellow:
                return ConsoleColor.Yellow;
            default:
                return ConsoleColor.White;
        }
    }
}

public class Card
{
    public Number Number { get; }
    public Colors Color { get; }

    public Card(Number number, Colors color)
    {
        Number = number;
        Color = color;
    }
}
