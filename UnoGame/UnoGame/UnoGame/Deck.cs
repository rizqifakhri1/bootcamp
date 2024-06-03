using System.Security.Cryptography.X509Certificates;
using UnoGame.Cards;
using UnoGame.Enum;
using UnoGame.Interface;

namespace UnoGame;

public class Deck : IDeck
{
    public Stack<ICard> Cards { get; set; } = new Stack<ICard>();

    public Deck()
    {
        for (int i = 0; i < 4; i++)
        {
            Cards.Push(new WildFour(i, ColorVariants.None, CardVariants.WildFour));
            Cards.Push(new Wild(i, ColorVariants.None, CardVariants.Wild));
        }

        foreach (ColorVariants color in ColorVariants.GetValues(typeof(ColorVariants)))
        {
            // Iterasi melalui setiap nilai enum dalam CardColor
            if (color == ColorVariants.None)
                continue; // Lewati iterasi jika warna kartu adalah none

            foreach (CardVariants type in CardVariants.GetValues(typeof(CardVariants)))
            {
                // Iterasi melalui setiap nilai enum dalam CardVariants untuk setiap warna
                if (type == CardVariants.Zero || type >= CardVariants.One && type <= CardVariants.Nine)
                {
                    // Jika jenis kartu adalah 0 atau angka 1-9
                    int count = (type == CardVariants.Zero) ? 1 : 2; // Tentukan jumlah kartu yang akan dibuat
                    for (int i = 0; i < count; i++)
                    {
                        // Loop untuk membuat dan menambahkan kartu-kartu tersebut ke dalam tumpukan Cards
                        Cards.Push(new Number(i, color, type));
                    }
                }
                else
                {
                    // Jika jenis kartu adalah Skip, Reverse, atau DrawTwo
                    int count = (type == CardVariants.Skip || type == CardVariants.Reverse || type == CardVariants.DrawTwo) ? 2 : 0; // Tentukan jumlah kartu yang akan dibuat
                    for (int i = 0; i < count; i++)
                    {
                        // Loop untuk membuat dan menambahkan kartu-kartu tersebut ke dalam tumpukan Cards
                        switch (type)
                        {
                            case CardVariants.Skip:
                                Cards.Push(new Skip(i, color, type)); // Tambahkan kartu Skip
                                break;
                            case CardVariants.Reverse:
                                Cards.Push(new Reverse(i, color, type)); // Tambahkan kartu Reverse
                                break;
                            case CardVariants.DrawTwo:
                                Cards.Push(new DrawTwo(i, color, type)); // Tambahkan kartu DrawTwo
                                break;
                        }
                    }
                }
            }
        }
    }

    public Deck(Stack<ICard> cards)
    {
        Cards = cards;
    }

    public Stack<ICard> ShuffleDeck()
    {
        List<ICard> cardList = Cards.ToList();
        Stack<ICard> shuffledCards = new Stack<ICard>(); // Inisialisasi tumpukan kartu yang diacak
        Random random = new Random();

        while (cardList.Count > 0)
        {
            int i = random.Next(cardList.Count); // Pilih angka acak antara 0 dan jumlah kartu yang tersisa
            shuffledCards.Push(cardList[i]); // Tambahkan kartu yang dipilih ke dalam tumpukan yang diacak
            cardList.RemoveAt(i); // Hapus kartu yang dipilih dari daftar kartu sementara
        }

        Cards = shuffledCards; // Tetapkan tumpukan yang diacak sebagai tumpukan utama
        return Cards;
    }

    public ICard DrawCard()
    {
        return Cards.Pop();
    }

}
