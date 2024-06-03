using System.Drawing;
using UnoGame.Enum;
using UnoGame.Interface;


namespace UnoGame.Cards;

public class Card : ICard
{

    public int ID{get; protected set;}
    public CardVariants Type{get; protected set;}
    public ColorVariants Color {get; set;}
    
    public Card (int id , ColorVariants color, CardVariants type)
    {
        ID = id;
        color = Color;
        type = Type;
    }

    public virtual CardVariants ExecuteCardEffect(GameController gameController)
    {
        return new CardVariants();
    }

    

}
