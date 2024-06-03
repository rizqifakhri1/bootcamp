using UnoGame.Enum;
namespace UnoGame.Cards;

public class Reverse : Card
{
    public Reverse(int id, ColorVariants color, CardVariants type) : base(id, color, type)
    {
        ID = id;
        Type = type;
        Color = color;
    }
    public override CardVariants ExecuteCardEffect(GameController gameController)
    {
        gameController.Divider.Invoke();
        gameController.GameInfo.Invoke("Reverse!\n");
        gameController.ChangeRotation();
        if (gameController.PlayerHand.Count == 2) gameController.NextTurn();
        return CardVariants.Reverse;
    }
}
