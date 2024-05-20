classDiagram

IPlayer <|.. Player
IBoard <|.. Board
ISpace *.. Position
ISpace <|.. Utility
ISpace <|.. Station
ISpace <|.. City
ISpace <|.. SpecialSpace

SpecialSpace <|.. GoSpace
SpecialSpace <|.. GoToJailSpace
SpecialSpace <|.. FreeParkingSpace
SpecialSpace <|.. CardSpace
SpecialSpace <|.. LuxuryTax
SpecialSpace <|.. IncomeTax

IDice <|.. Dice

GameController *-- IPlayer
GameController *-- IBoard
GameController *-- IDice
GameController *-- ICard
GameController *-- GameStatus
GameController *-- Bank
GameController *-- PlayerData

PlayerData *-- ISpace
PlayerData o-- ICard
PlayerData .. PlayerPiece
PlayerData *-- Property

ICard .. CardTypes
ICard .. CommunityChest
ICard .. ChaceCard

Board "1" *-- "40" ISpace

Property *-- City
Property *-- Utility
Property *-- Station

City *-- House
City *-- Hotel


class PlayerData {

    +PlayerPiece Piece
    +decimal Balance ~get; private set;~
    +List~Property~ PropertiesOwned
    +ISpace PlayerPosition
    +ICard JailFreeCard
    +PlayerData(PlayerPiece piece, int money)
    ~HaveJailFreeCard() bool
}

class PlayerPiece {
    <<enum>>
    Battleship
    RaceCar
    TopHat
    ScottishTerrier
    Cat
    Penguin
    RubberDucky
    Thimble
}

class IPlayer {
    +int Id ~get;~
    +string Name ~get;~
}

class Player {
    -int Id ~get; private set;~
    -string Name ~get; private set;~
  
}



class Property {
    +string Name ~get; private set;~
    +decimal Price ~get; private set;~
    +decimal Rent ~get; private set;~
    +decimal MortgageValue ~get; private set;~
    +IPlayer Owner ~get; set;~
    
    +Property(string name, decimal price, decimal rent, decimal mortgageValue)
    +Buy(IPlayer player) bool
    +PayRent(IPlayer player) bool
    +Mortgage() bool
}

%%  City (House & Hotel)
class City {
    +int id ~get; private set;~
    +string Name ~get; private set;~
    +decimal Price ~get; private set;~
    +decimal Rent ~get; private set;~
    +decimal MortgageValue ~get; private set;~
    +int Position ~get; private set;~
    +IPlayer Owner ~get; set;~
    +bool HasHotel ~get; private set;~
    +bool HasHouse ~get; private set;~
    +decimal MortgageValue ~get; private set;~
}

class House {
    +decimal Price ~get; private set;~
    +BuildHouse() bool
    +House(decimal price)
}

class Hotel {
    +decimal Price ~get; private set;~
    +BuildHotel() bool
    +Hotel(decimal price)
}

class ICard {
    <<interface>>
    +int id ~get;~
    +string Description ~get;~
    +CardTypes cardTypes
    +ChanceCard chaneCard
    +CommunityChest communityChest
    +ActionCard(IPlayer player)
}

class CommunityChest {
    <<Enumeration>>
    AdvanceToGo,
    BankError,
    DoctorFees,
    SaleOfStock,
    GetOutOfJailFree,
    GoToJail,
    GrandOperaNight,
    HolidayFundMatures,
    IncomeTaxRefund,
    Birthday,
    LifeInsuranceMatures,
    HospitalFees,
    SchoolFees,
    ConsultancyFee,
    StreetRepairs,
    BeautyContest,
    Inherit
}

class ChaceCard {
    <<Enumeration>>
     AdvanceToGo,
    AdvanceToIllinoisAve,
    AdvanceToStCharlesPlace,
    AdvanceToNearestUtility,
    AdvanceToNearestRailroad,
    BankDividend,
    GetOutOfJailFree,
    GoBackThreeSpaces,
    GoToJail,
    GeneralRepairs,
    TakeATripToReadingRailroad,
    PayPoorTax,
    TakeAWalkOnBoardwalk,
    ElectedChairman,
    BuildingLoanMatures
}


class CardTypes {
    <<Enumeration>>
    ChanceCard,
    CommunityChest
    }

class Utility {
    +int id ~get; private set;~
    +string Name ~get; private set;~
    +decimal Price ~get; private set;~
    +decimal Rent ~get; private set;~
    +decimal MortgageValue ~get; private set;~
    +int Position ~get; private set;~
    +IPlayer Owner ~get; set;~
    +Utility(string name, decimal price, decimal rent)
    +Buy(IPlayer player) bool
    +PayRent(IPlayer player) bool
}

class Station {
    +int id ~get; private set;~
    +string Name ~get; private set;~
    +decimal Price ~get; private set;~
    +decimal Rent ~get; private set;~
    +decimal MortgageValue ~get; private set;~
    +int Position ~get; private set;~
    +IPlayer Owner ~get; set;~
    +Station(string name, decimal price, decimal rent)
    +Buy(IPlayer player) bool
    +PayRent(IPlayer player) bool
}

class IDice {
    +int NumOfSides ~get;~
    +Roll() int
}

class Dice {
    +int NumOfSides ~get; private set;~
    +Dice(int numOfSides)
    +Roll() int
}

class ISpace {
    <<interface>>
    +int id ~get;~
    +string Name ~get;~
    +int Position ~get;~
    
}

class SpecialSpace {
    +int id ~get; private set;~
    +string Name ~get; private set;~
    +int Position ~get; private set;~
    +ApplyEffect(IPlayer player)
}

class GoSpace {
    +string Name ~get; private set;~
    +int Position ~get; private set;~
    +ApplyEffect(IPlayer player)
}

class GoToJailSpace {
    +string Name ~get; private set;~
    +int Position ~get; private set;~
    +ApplyEffect(IPlayer player)
}

class FreeParkingSpace {
    +string Name ~get; private set;~
    +int Position ~get; private set;~
    +ApplyEffect(IPlayer player)
}

class CardSpace {
    +string Name ~get; private set;~
    +int Position ~get; private set;~
    +ApplyEffect(IPlayer player)
}

class LuxuryTax {
    +string Name ~get; private set;~
    +int Position ~get; private set;~
    +ApplyEffect(IPlayer player)
}

class IncomeTax {
    +string Name ~get; private set;~
    +int Position ~get; private set;~
    +ApplyEffect(IPlayer player)
}

class IBoard {
    <<interface>>
    +int NumOfSpaces ~get;~
    +List~ISpace~ Spaces;~
}


class Position {
    <<struct>>
    +int x ~get; private set;~
    +int y ~get; private set;~
    +Position (int x int y)
}

class Board {
    +int NumOfSpaces ~get; private set;~
    +List~ISpace~ Spaces ~get; private set;~
    +Board(int NumOfSpaces, int maxFields = 40)

}

class Bank {
    +decimal TotalBalance ~get; private set;~
    +Bank(decimal balance)
    +UpdateMoney(IPlayer player, int amount) bool
    +TransferMoney(IPlayer player, decimal amount) bool
    +TakeMoney(IPlayer player, decimal amount) bool
}

class GameStatus {
    <<enumeration>>
    NotStarted,
    Play,
    Finish
}

class GameController {
    +int maxPlayer : readonly
    -int _numOfPlayers
    -IDice _dice
    -GameStatus _gameStatus 
    -IBoard _board
    -List~IPlayer~ _turnOrder 
    -Bank _bank
    -Dictionary~IPlayer, PlayerData~ _players

    %% Action
    -Action~IPlayer, ISpace~ PlayerMove
    -Action~IPlayer, ISpace~ BuyProperty
    -Action~IPlayer, Property~ AuctionProperty
    -Action~IPlayer, Property~ PayRent
    -Action~IPlayer, ICard~ DrawCard
    -Action~IPlayer~ GoToJail
    -Action~IPlayer~ GetOutOfJail
    -Action~IPlayer~ PassGo
    -Action~IPlayer~ DeclareBankruptcy
    -Action~IPlayer, PlayerData~ PayTax

    %% Constructor
    +GameController(int maxPlayer = 8, IDice dice, GameStatus status, Bank bank)

    %% Game Contoller
    +StartGame() bool
    +StopGame() bool
    +GetGameStatus() GameStatus
    +SetGameStatus(GameStatus status) 
    +SetNumOfPlayers(int num) bool
    +AddPlayer(IPlayer player) bool
    +SetBoard(IPlayer player, IBoard board)
    +CreateTurnOrder() List~IPlayer~ 
    +GetPlayer(int index) IPlayer

    %% Player Contoller
    +StartTurn() bool
    +EndTurn() bool
    +RollDice() int
    +MovePlayer(IPlayer player, int steps) bool 
    +ChangeCurrentTurn() bool
    +CheckCurrentTurn() IPlayer
    +CheckWinner() IPlayer

    %% State
    +HandleSpaceEffect(IPlayer player, ISpace space) 
    +HandleThreeTimeArrowDice(IPlayer player, IDice dice)
    +HandleJail(IPlayer player) bool
    +DrawCard(IPlayer player)
    +BuyHouse(IPlayer player, Property property) bool
    +BuyHotel(IPlayer player, Property property) bool
    +MortgageProperty(IPlayer player, Property property) bool
    +TransferMoney(IPlayer fromPlayer, IPlayer toPlayer, decimal amount) bool
    +Trade(IPlayer trader, IProperty property, IPlayer buyer, IProperty property) bool
    +PayTax(IPlayer player, decimal amount) bool
    +PayFee(IPlayer player, decimal amount) bool
}