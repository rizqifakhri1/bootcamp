using System;
using System.Collections.Generic;
using UnoGame;
using UnoGame.Enum;
using UnoGame.Interface;

namespace UnoGame
{
    public static class UserInterface
    {
        public static void DisplayCard(ICard card)
        {
            PrintCards(new List<ICard> { card });
        }

        public static string CardToString(ICard card)
        {
            return $"{card.Type} {card.Color}";
        }

        public static void PrintCards(List<ICard> cards)
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
                var symbol = GetCardSymbol(card);
                Console.Write($"│ {symbol} │ ");
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

            for (int i = 0; i < cards.Count; i++)
            {
                Console.ForegroundColor = ConvertColor(cards[i].Color);
                Console.Write($"Index {i + 1} ");
            }
            
            Console.WriteLine();
            Console.ResetColor();
        }

        private static string GetCardSymbol(ICard card)
        {
            return card.Type switch
            {
                CardVariants.Zero =>    " 0 ",
                CardVariants.One =>     " 1 ",
                CardVariants.Two =>     " 2 ",
                CardVariants.Three =>   " 3 ",
                CardVariants.Four =>    " 4 ",
                CardVariants.Five =>    " 5 ",
                CardVariants.Six =>     " 6 ",
                CardVariants.Seven =>   " 7 ",
                CardVariants.Eight =>   " 8 ",
                CardVariants.Nine =>    " 9 ",
                CardVariants.Reverse => "<=>",
                CardVariants.Skip =>    " X ",
                CardVariants.DrawTwo => "+2 ",
                CardVariants.WildFour =>"+4 ",
                CardVariants.Wild =>    " W ",
                _ => " ? "
            };
        }

        private static ConsoleColor ConvertColor(ColorVariants color)
        {
            return color switch
            {
                ColorVariants.Red => ConsoleColor.Red,
                ColorVariants.Green => ConsoleColor.Green,
                ColorVariants.Blue => ConsoleColor.Blue,
                ColorVariants.Yellow => ConsoleColor.Yellow,
                ColorVariants.None => ConsoleColor.White,
                _ => ConsoleColor.White
            };
        }
    }
}
