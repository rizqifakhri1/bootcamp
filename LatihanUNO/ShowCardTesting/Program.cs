using System;
using System.Collections.Generic;

public enum CardType
{
    Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine,
    Skip, Reverse, DrawTwo,
    Wild, WildDrawFour
}

public enum CardColor
{
    Red, Green, Blue, Yellow, None // None digunakan untuk Wild cards
}

public class Card
{
    public CardType Type { get; set; }
    public CardColor Color { get; set; }

    public Card(CardType type, CardColor color)
    {
        Type = type;
        Color = color;
    }

    //untuk apa ?
    public override string ToString()
    {
        return $"{Color} {Type}";
    }
}

public class Deck
{
    private Stack<Card> drawPile;
    private Stack<Card> discardPile;

    public Deck()
    {
        drawPile = new Stack<Card>();
        discardPile = new Stack<Card>();
        InitializeDeck();
        Shuffle();
    }

    private void InitializeDeck()
    {
        // Menambahkan kartu warna dengan angka 0 sampai 9, 2 kartu untuk setiap angka 1 sampai 9 dan 1 kartu untuk angka 0
        foreach (CardColor color in Enum.GetValues(typeof(CardColor)))
        {
            if (color == CardColor.None) continue;

            drawPile.Push(new Card(CardType.Zero, color));
            for (int i = 1; i <= 9; i++)
            {
                drawPile.Push(new Card((CardType)i, color));
                drawPile.Push(new Card((CardType)i, color));
            }

            // Menambahkan kartu Skip, Reverse, dan Draw Two (2 untuk setiap warna)
            for (int i = 0; i < 2; i++)
            {
                drawPile.Push(new Card(CardType.Skip, color));
                drawPile.Push(new Card(CardType.Reverse, color));
                drawPile.Push(new Card(CardType.DrawTwo, color));
            }

        }

        // Menambahkan Wild dan Wild Draw Four cards (4 untuk setiap jenis)
        for (int i = 0; i < 4; i++)
        {
            drawPile.Push(new Card(CardType.Wild, CardColor.None));
            drawPile.Push(new Card(CardType.WildDrawFour, CardColor.None));
        }
    }

    private void Shuffle()
    {
        Random rand = new Random();
        var cards = drawPile.ToArray();
        drawPile.Clear();
        for (int i = cards.Length - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);
            var temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        }
        foreach (var card in cards)
        {
            drawPile.Push(card);
        }
    }

    public Card DrawCard()
    {
        if (drawPile.Count == 0)
        {
            throw new InvalidOperationException("The draw pile is empty.");
        }

        return drawPile.Pop();
    }

    public void DiscardCard(Card card)
    {
        discardPile.Push(card);
    }

    public Card PeekTopDiscard()
    {
        if (discardPile.Count == 0)
        {
            throw new InvalidOperationException("The discard pile is empty.");
        }

        return discardPile.Peek();
    }

    public void PrintDrawPile()
    {
        foreach (var card in drawPile)
        {
            Console.WriteLine(card);
        }
    }

    public void PrintDiscardPile()
    {
        foreach (var card in discardPile)
        {
            Console.WriteLine(card);
        }
    }
}

public class Program
{
    public static void Main()
    {
        Console.Clear();
        Deck deck = new Deck();
        deck.PrintDrawPile();
        // Contoh untuk menarik kartu dan membuangnya
        Card drawnCard = deck.DrawCard();
        Console.WriteLine($"Drawn Card: {drawnCard}");
        
        deck.DiscardCard(drawnCard);
        Console.WriteLine("Top of Discard Pile: " + deck.PeekTopDiscard());

        List<Card> sampleCards = new List<Card>();
        for (int i = 0; i < 25; i++)
        {
            sampleCards.Add(deck.DrawCard());
        }

        //Untuk Mengurutkan kartu berdasarkan warna
        sampleCards = sampleCards.OrderBy(card => card.Color).ToList();

        Console.WriteLine("Sample Cards:");
        PrintUnoCards(sampleCards);
    }

    static void PrintUnoCards(List<Card> cards)
    {
        foreach (var card in cards)
        {
            Console.ForegroundColor = ConvertColor(card.Color);
            Console.Write("┌────┐ ");
        }
        Console.WriteLine();

        foreach (var card in cards)
        {
            Console.ForegroundColor = ConvertColor(card.Color);
            Console.Write($"│    │ ");
        }

        Console.WriteLine();

        foreach (var card in cards)
        {
            Console.ForegroundColor = ConvertColor(card.Color);
            Console.Write($"│ {GetSymbol(card)} │ ");
        }
        Console.WriteLine();

        foreach (var card in cards)
        {
            Console.ForegroundColor = ConvertColor(card.Color);
            Console.Write($"│    │ ");
        }

        Console.WriteLine();

        foreach (var card in cards)
        {
            Console.ForegroundColor = ConvertColor(card.Color);
            Console.Write("└────┘ ");
        }
        Console.WriteLine();
        foreach (var card in cards)
        {
            Console.ForegroundColor = ConvertColor(card.Color);
            int index = cards.IndexOf(card);
            Console.Write($"Idx{(index > 9 ? ":" : ": ")}{index} ");
        }
        Console.WriteLine();

        PrintIndexIndicators(cards);

        Console.ResetColor();
    }


    //Test memberi tanda
    static void PrintIndexIndicators(List<Card> cards)
    {
        foreach (var card in cards)
        {
            var nextCard = cards.IndexOf(card) < cards.Count - 1 ? cards[cards.IndexOf(card) + 1] : null;
            var hasSameColorAsAbove = nextCard != null && nextCard.Color == card.Color;
            var hasSameNumberAsAbove = nextCard != null && nextCard.Type == card.Type;
            
            Console.ForegroundColor = ConvertColor(card.Color);
            if (hasSameColorAsAbove || hasSameNumberAsAbove)
            {
                Console.Write("────── ");
            }
            else
            {
                Console.Write("       ");
            }
        }
        Console.WriteLine();
    }


    


    static string GetSymbol(Card card)
    {
        switch (card.Type)
        {
            case CardType.Zero:
                return " 0";
            case CardType.One:
                return " 1";
            case CardType.Two:
                return " 2";
            case CardType.Three:
                return " 3";
            case CardType.Four:
                return " 4";
            case CardType.Five:
                return " 5";
            case CardType.Six:
                return " 6";
            case CardType.Seven:
                return " 7";
            case CardType.Eight:
                return " 8";
            case CardType.Nine:
                return " 9";
            case CardType.Skip:
                return "⛔";
            case CardType.Reverse:
                return "⇄ ";
            case CardType.DrawTwo:
                return "+2";
            case CardType.Wild:
                return "🌈";
            case CardType.WildDrawFour:
                return "+4";
            default:
                return "";
        }
    }

    static ConsoleColor ConvertColor(CardColor color)
    {
        switch (color)
        {
            case CardColor.Red:
                return ConsoleColor.Red;
            case CardColor.Blue:
                return ConsoleColor.Blue;
            case CardColor.Green:
                return ConsoleColor.Green;
            case CardColor.Yellow:
                return ConsoleColor.Yellow;
            default:
                return ConsoleColor.White;
        }
    }
}
