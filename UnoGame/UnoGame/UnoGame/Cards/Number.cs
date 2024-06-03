using System.Reflection.Metadata.Ecma335;
using UnoGame.Enum;

namespace UnoGame.Cards;

public class Number : Card
{
    public Number(int id, ColorVariants color, CardVariants type) : base (id, color, type)
    {
        ID = id;
        Type = type;
        Color = color;
    }
    public override CardVariants ExecuteCardEffect(GameController gameController)
    {
        return CardVariants.Zero;
    }
}
