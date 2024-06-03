``` mermaid
classDiagram
    class GameController{
        - Func<string, string> GetInput
        - Action<string> GameInfo
        - Action Divider
        - GameRotation Rotation
        - Stack<ICard> DiscardPile
        - IDeck CardDeck
        - ICard CurrentRevealCard
        - Dictionary<IPlayer, List<ICard>> PlayerHand
        - IEnumerable<IPlayer> WinnerOrder
        - IPlayer CurrentPlayer
        - IPlayer NextPlayer
        - int CurrentPlayerIndex
        - int NextPlayerIndex
        + GameController()
        + PrepareGame(): ICard
        + AddPlayers(numOfPlayers: int)
        + PlayGame(): async Task
        + InsertPlayer(player: IPlayer): bool
        + SetPlayerHand(player: IPlayer, numOfCards: int): bool
        + GetPlayerHand(player: IPlayer): IEnumerable<ICard>
        + PossibleCard(card: ICard): bool
        + GetPossibleCards(player: IPlayer): IEnumerable<ICard>
        + PlayerPlayCard(player: IPlayer, cardChosen: ICard): bool
        + PlayerDrawCard(player: IPlayer): ICard
        + ChangeRotation()
        + NextTurn()
        + CheckEmptyHand(): bool
        + GetWinnerOrder(): IEnumerable<IPlayer>
        + DisplayCards(title: string, cards: List<ICard>)
        + CenterText(text: string, totalWidth: int): string
        + GetCardIndex(availableCardCount: int): int
        - PlayerTurn(): async Task
    }

    class ICard{
        <<Interface>>
        +int ID get;
        +ColorVariants Color get;
        +CardVariants Type get;
    }

    class IDeck{
        <<Interface>>
        +Stack~ICard~ Cards get; set;
        +ShuffleDeck() : Stack~ICard~
        +Draw() : ICard
    }

    class IPlayer{
        <<Interface>>
        +int ID get;
        +string Name get;
    }

    class Card{
        <<abstract>>
        +Card(int id, CardColor color, CardType type)
        +abstract CardType ExecuteCardEffect(GameController gameController)
    }

    class WildFour{
        ExecuteCardEffect(GameController gc)
    }

    class Wild{
        ExecuteCardEffect(GameController gc)
    }

    class DrawTwo{
        ExecuteCardEffect(GameController gc)
    }

    class Reverse{
        ExecuteCardEffect(GameController gc)
    }

    class Skip{
        ExecuteCardEffect(GameController gc)
    }

    class Number{
        ExecuteCardEffect(GameController gc)
    }

    class Deck{
        +Stack~ICard~ Cards get; set;
        +Deck()
        +Deck(Stack ~ICard~ cards)
        +ShuffleDeck() : Stack~ICard~
        +Draw() : ICard
    }
    
    class GameRotation{
        <<Enumeration>>
        Clockwise,
        CounterClockwise,
    }

    class ColorVariants{
        <<Enumeration>>
        Red,
        Green, 
        Blue,
        None
    }

    class CardVariants{
        <<Enumeration>>
        0,
        1,
        2,
        3,
        4,
        5,
        6,
        7,
        8,
        9,
        Skip,
        Reverse,
        DrawTwo,
        WildFour,
        Wild,
    }

    class Player{       
        +Player(int id, string name)
    }

    GameController "*" -- "1" ICard : Composition
    GameController "*" -- "1" IDeck : Composition
    GameController "1" *-- "2..4" IPlayer : Composition
    GameController *-- GameRotation  : Composition

    ICard --> CardVariants : Type
    ICard --> ColorVariants : Color

    GameController -- CardVariants
    GameController -- ColorVariants

    ICard <|-- Card
    Card <|-- Number
    Card <|-- Reverse
    Card <|-- Skip
    Card <|-- DrawTwo
    Card <|-- WildFour
    Card <|-- Wild

    IDeck -- Deck

    IPlayer -- Player

    ```