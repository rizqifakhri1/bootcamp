using System.Diagnostics;
using UnoGame.Enum;
using UnoGame.Interface;

namespace UnoGame;

public class GameController
{
    public Func<string, string> GetInput { get; set; } = null!;
    public Action<string> GameInfo { get; set; }
    public Action Divider { get; set; }
    public GameRotation Rotation { get; private set; }
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
        CardDeck.ShuffleDeck();
        CurrentPlayer = PlayerHand.Keys.ElementAt(CurrentPlayerIndex);
        NextPlayer = PlayerHand.Keys.ElementAt(NextPlayerIndex);

        foreach (IPlayer player in PlayerHand.Keys)
        {
            SetPlayerHand(player, 7);
        }

        ICard firstCard;
        do
        {
            firstCard = CardDeck.DrawCard();
        } while (firstCard.Color == ColorVariants.None);

        DiscardPile.Push(firstCard);
        CurrentRevealCard = firstCard;

        return firstCard;
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
        var currentPlayer = CurrentPlayer;
        var currentRevealedCard = CurrentRevealCard;
        var possibleCards = GetPossibleCards(currentPlayer).ToList();
        var otherCards = GetPlayerHand(currentPlayer).Where(card => !possibleCards.Contains(card)).ToList();

        Console.Clear();
        // GameInfo?.Invoke(CenterText("Last Card Played:", 70));
        GameInfo?.Invoke("┌──────────────────────────────────────────────────────────────────┐");
        GameInfo?.Invoke("│                        Last Card Played                          │");
        GameInfo?.Invoke("└──────────────────────────────────────────────────────────────────┘");
        UserInterface.DisplayCard(currentRevealedCard);
        Console.WriteLine();
        GameInfo?.Invoke("┌──────────────────────────────────────────────────────────────────┐");
        GameInfo?.Invoke($"│{CenterText($"{currentPlayer.Name}'s turn", 66)}│");
        GameInfo?.Invoke("└──────────────────────────────────────────────────────────────────┘");

        if (possibleCards.Any())
        {
            DisplayCards("Available cards", possibleCards);
            DisplayCards("Other cards in hand", otherCards);

            var indexVal = GetCardIndex(possibleCards.Count);
            var playedCard = possibleCards[indexVal - 1];
            PlayerPlayCard(currentPlayer, playedCard);
            GameInfo?.Invoke($"{currentPlayer.Name} plays");
            UserInterface.DisplayCard(playedCard);
        }
        else
        {
            GameInfo?.Invoke("(No available cards to play)");
            DisplayCards("Cards in hand", otherCards);

            GameInfo?.Invoke("No cards to play... drawing card");
            await Task.Delay(2000);
            var newCard = PlayerDrawCard(currentPlayer);
            GameInfo?.Invoke($"Drawn Card: {UserInterface.CardToString(newCard)}");

            if (PossibleCard(newCard))
            {
                PlayerPlayCard(currentPlayer, newCard);
                GameInfo?.Invoke($"{currentPlayer.Name} plays");
                UserInterface.DisplayCard(newCard);
            }
            await Task.Delay(1500);
        }
        await Task.Delay(2500);
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

        DiscardPile.Push(cardChosen);
        CurrentRevealCard = cardChosen;
        PlayerHand[player].Remove(cardChosen);
        cardChosen.ExecuteCardEffect(this);
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
        var input = GetInput("Choose a card by index: ");
        while (!int.TryParse(input, out indexVal) || indexVal < 1 || indexVal > availableCardCount)
        {
            input = GetInput("Try again... Choose only available cards by index (ex: 1)");
        }
        return indexVal;
    }

}
