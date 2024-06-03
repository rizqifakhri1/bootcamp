using UnoGame.Enum;

namespace UnoGame.Interface;

public interface ICard
{
    public int ID {get;}
    public CardVariants Type{get;}
    public ColorVariants Color{get; set;}
    public CardVariants ExecuteCardEffect(GameController gameController) => new();
}

