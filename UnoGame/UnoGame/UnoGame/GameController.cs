using System.Diagnostics;
using UnoGame.Enum;
using UnoGame.Interface;
using NLog;
using NLog.Config;

namespace UnoGame;

public class GameController
{
    public Func<string, string> GetInput { get; set; } = null!;
    //Secara default Func meminta input
    public Action<string> GameInfo { get; set; }
    public Action Divider { get; set; }
    public GameRotation Rotation { get; private set; } //Set di ubah menjadi public untuk unit test
    public Stack<ICard> DiscardPile { get; private set; }
    public IDeck CardDeck { get; private set; }
    public ICard CurrentRevealCard { get; set; } = null!;
    public Dictionary<IPlayer, List<ICard>> PlayerHand { get; private set; }
    public IEnumerable<IPlayer> WinnerOrder { get; private set; } = null!;
    public IPlayer CurrentPlayer { get; private set; } = null!;
    public IPlayer NextPlayer { get; private set; } = null!;
    public int CurrentPlayerIndex { get; private set; } = 0;
    public int NextPlayerIndex { get; private set; } = 0;

    public GameController()
    {
        DiscardPile = new();
        PlayerHand = new();
        Rotation = GameRotation.Clockwise;
        CardDeck = new Deck();
    }

    public ICard PrepareGame()
    {
        ShuffleDeck();
        DealInitialCards();
        CurrentPlayer = PlayerHand.Keys.ElementAt(CurrentPlayerIndex);
        NextPlayer = PlayerHand.Keys.ElementAt(NextPlayerIndex);

        ICard firstCard;
        do
        {
            firstCard = CardDeck.DrawCard();
        } while (firstCard.Color == ColorVariants.None);

        DiscardPile.Push(firstCard);
        CurrentRevealCard = firstCard;

        return firstCard;
    }

    private void ShuffleDeck()
    {
        CardDeck.ShuffleDeck();
    }

    private void DealInitialCards()
    {
        foreach (IPlayer player in PlayerHand.Keys)
        {
            SetPlayerHand(player, 7);
        }
    }

    public void AddPlayers(int numOfPlayers)
    {
        for (var i = 0; i < numOfPlayers; i++)
        {
            var playerName = GetInput($"Enter Player {i + 1}'s Name:").Trim();
            playerName = string.IsNullOrEmpty(playerName) ? $"Player{i + 1}" : playerName;
            InsertPlayer(new Player(playerName, i));
        }
    }

//     public void AddPlayers(int numOfPlayers)
// {
//     if (CardDeck == null)
//     {
//         throw new InvalidOperationException("CardDeck is not initialized.");
//     }

//     for (var i = 0; i < numOfPlayers; i++)
//     {
//         var playerName = GetInput($"Enter Player {i + 1}'s Name:").Trim();
//         playerName = string.IsNullOrEmpty(playerName) ? $"Player{i + 1}" : playerName;
//         InsertPlayer(new Player(playerName, i));
//     }
// }

    public async Task PlayGame()
    {
        while (true)
        {
            if (CheckEmptyHand())
            {
                GetWinnerOrder();
                break;
            }
            await PlayerTurn();
            NextTurn();
        }
    }

    private async Task PlayerTurn()
    {
        var currentPlayer = GetCurrentPlayer();
        var currentRevealedCard = GetCurrentRevealCard();
        var possibleCards = GetPossibleCards(currentPlayer).ToList();
        var otherCards = GetOtherPlayerCards(currentPlayer);

        ClearConsole();
        DisplayLastCardPlayed(currentRevealedCard);
        DisplayPlayerTurnMessage(currentPlayer);

        if (possibleCards.Any())
        {
            DisplayCards("Available cards", possibleCards);
            DisplayCards("Other cards in hand", otherCards);

            var indexVal = GetCardIndex(possibleCards.Count);
            var playedCard = possibleCards[indexVal - 1];
            PlayCard(currentPlayer, playedCard);
            DisplayPlayerPlaysCardMessage(currentPlayer, playedCard);
            // UserInterface.DisplayCard(playedCard);
        }
        else
        {
            DisplayNoAvailableCardsMessage();
            DisplayCards("Cards in hand", otherCards);
            DrawCardAndPlayIfPossible(currentPlayer);
        }

        await Task.Delay(2500);
    }

    private ICard GetCurrentRevealCard()
    {
        return CurrentRevealCard;
    }

    private IPlayer GetCurrentPlayer()
    {
        return CurrentPlayer;
    }

    private void ClearConsole()
    {
        Console.Clear();
    }

    private void DisplayLastCardPlayed(ICard currentRevealedCard)
    {
        //Sudah di pindah ke UserInterface
        // GameInfo?.Invoke("┌──────────────────────────────────────────────────────────────────┐");
        // GameInfo?.Invoke("│                        Last Card Played                          │");
        // GameInfo?.Invoke("└──────────────────────────────────────────────────────────────────┘");
        UserInterface.HeaderLastCardDisplay();
        UserInterface.DisplayCard(currentRevealedCard);
    }

    private void DisplayPlayerTurnMessage(IPlayer currentPlayer)
    {
        //Sudah di pindah ke UserInterface
        // GameInfo?.Invoke("┌──────────────────────────────────────────────────────────────────┐");
        // GameInfo?.Invoke($"│{CenterText($"{currentPlayer.Name}'s turn", 66)}│");
        // GameInfo?.Invoke("└──────────────────────────────────────────────────────────────────┘");
        UserInterface.DisplayName(currentPlayer);
    }

    private List<ICard> GetOtherPlayerCards(IPlayer currentPlayer)
    {
        return GetPlayerHand(currentPlayer).Where(card => !GetPossibleCards(currentPlayer).Contains(card)).ToList();
    }

    private void PlayCard(IPlayer currentPlayer, ICard playedCard)
    {
        PlayerPlayCard(currentPlayer, playedCard);
    }

    private void DisplayPlayerPlaysCardMessage(IPlayer currentPlayer, ICard playedCard)
    {
        GameInfo?.Invoke($"{currentPlayer.Name} plays");
        UserInterface.DisplayCard(playedCard);
    }

    private void DisplayNoAvailableCardsMessage()
    {
        UserInterface.DisplayNoAvailableCard();
    }

    private void DrawCardAndPlayIfPossible(IPlayer currentPlayer)
    {
        GameInfo?.Invoke("No cards to play... drawing card");
        // await Task.Delay(2000);
        var newCard = PlayerDrawCard(currentPlayer);
        GameInfo?.Invoke($"Drawn Card: {UserInterface.CardToString(newCard)}");

        if (PossibleCard(newCard))
        {
            PlayCard(currentPlayer, newCard);
            DisplayPlayerPlaysCardMessage(currentPlayer, newCard);
        }

        // await Task.Delay(1500);
    }

    public void DisplayWinnerOrder()
    {
        int count = 1;
        GameInfo?.Invoke("\n[Rank]");
        foreach (var player in WinnerOrder)
        {
            GameInfo?.Invoke($"{count}. {player.Name}");
            count++;
        }
    }

    public bool InsertPlayer(IPlayer player)
    {
        if (PlayerHand.ContainsKey(player))
        {
            return false;
        }
        PlayerHand.Add(player, new List<ICard>());
        return true;
    }

    public bool SetPlayerHand(IPlayer player, int numOfCards)
    {
        if (!PlayerHand.TryGetValue(player, out var playerHand))
        {
            return false;
        }
        for (int i = 0; i < numOfCards; i++)
        {
            playerHand.Add(CardDeck.DrawCard());
        }
        return true;
    }

    public IEnumerable<ICard> GetPlayerHand(IPlayer player)
    {
        if (!PlayerHand.ContainsKey(player))
        {
            return Enumerable.Empty<ICard>();
        }
        return PlayerHand[player];
    }

    public bool PossibleCard(ICard card)
    {
        return card.Color == CurrentRevealCard?.Color || card.Color == ColorVariants.None || card.Type == CurrentRevealCard?.Type;
    }

    public IEnumerable<ICard> GetPossibleCards(IPlayer player)
    {
        if (!PlayerHand.ContainsKey(player))
        {
            return Enumerable.Empty<ICard>();
        }
        List<ICard> possibleCards = GetPlayerHand(player).Where(PossibleCard).ToList();
        return possibleCards;
    }

    public bool PlayerPlayCard(IPlayer player, ICard cardChosen)
    {
        if (!PlayerHand.ContainsKey(player))
        {
            return false;
        }

        if (!GetPlayerHand(player).Contains(cardChosen))
        {
            return false;
        }

        DiscardPile.Push(cardChosen); // Kartu dimasukkan ke DiscardPile
        CurrentRevealCard = cardChosen; // Kartu dimasukkan sebagai kartu terakhir yang dimainkan
        PlayerHand[player].Remove(cardChosen); // Kartu dihapus dari tangan pemain
        cardChosen.ExecuteCardEffect(this); // Efek kartu dieksekusi
        return true;
    }

    public ICard PlayerDrawCard(IPlayer player)
    {
        var drawCard = CardDeck.DrawCard();
        PlayerHand[player].Add(drawCard);
        return drawCard;
    }

    public void ChangeRotation()
    {
        Rotation = (Rotation == GameRotation.Clockwise) ? GameRotation.CounterClockwise : GameRotation.Clockwise;
    }

    public void NextTurn()
    {
        int playerCount = PlayerHand.Count;
        if (Rotation == GameRotation.Clockwise)
        {
            CurrentPlayerIndex = (CurrentPlayerIndex + 1) % playerCount;
        }
        else
        {
            CurrentPlayerIndex = (CurrentPlayerIndex + playerCount - 1) % playerCount;
        }

        NextPlayerIndex = (CurrentPlayerIndex + 1) % playerCount;
        CurrentPlayer = PlayerHand.Keys.ElementAt(CurrentPlayerIndex);
        NextPlayer = PlayerHand.Keys.ElementAt(NextPlayerIndex);
    }

    public bool CheckEmptyHand()
    {
        return PlayerHand.Any(player => player.Value.Count == 0);
    }

    public IEnumerable<IPlayer> GetWinnerOrder()
    {
        WinnerOrder = PlayerHand.OrderBy(player => player.Value.Count)
                                .ToDictionary(player => player.Key, player => player.Value)
                                .Keys
                                .ToList();
        return WinnerOrder;
    }

    //Membuat teks di tengah
    private void DisplayCards(string title, List<ICard> cards)
    {
        int totalWidth = 68; // Panjang total baris
        string separator = new string('-', totalWidth);

        GameInfo?.Invoke(separator);
        GameInfo?.Invoke(CenterText($"{title}", totalWidth));
        GameInfo?.Invoke(separator);
        UserInterface.PrintCards(cards);
    }


    public string CenterText(string text, int totalWidth)
    {
        if (text.Length >= totalWidth)
        {
            return text; // Jika teks lebih panjang dari lebar total, tidak ada yang perlu dilakukan
        }

        int leftPadding = (totalWidth - text.Length) / 2;
        int rightPadding = totalWidth - text.Length - leftPadding;

        return new string(' ', leftPadding) + text + new string(' ', rightPadding);
    }


    private int GetCardIndex(int availableCardCount)
    {
        int indexVal;
        var input = GetInput("Choose a card by index (Avalible Card): ");
        while (!int.TryParse(input, out indexVal) || indexVal < 1 || indexVal > availableCardCount)
        {
            input = GetInput("Try again.Choose only available cards by index (ex: 1)");
        }
        return indexVal;
    }

    //Code Tambahan Untuk Unit Testing (karena set rotation private)

    public void SetRotation(GameRotation rotation)
{
    Rotation = rotation;
}


}
