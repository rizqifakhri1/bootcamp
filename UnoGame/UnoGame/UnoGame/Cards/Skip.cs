using UnoGame.Enum;

namespace UnoGame.Cards;

public class Skip : Card
{
    public Skip(int id, ColorVariants color, CardVariants type) : base(id, color, type)
    {
        ID = id;
        Type = type;
        Color = color;
    }
    public override CardVariants ExecuteCardEffect(GameController gameController)
    {
        gameController.Divider.Invoke();
        gameController.GameInfo.Invoke($"Skip {gameController.NextPlayer.Name}!\n");
        gameController.NextTurn();
        return CardVariants.Skip;
    }
}
