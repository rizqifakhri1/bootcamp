using UnoGame.Enum;
namespace UnoGame.Cards;

public class DrawTwo : Card
{
    public DrawTwo(int id, ColorVariants color, CardVariants type) : base(id, color, type)
    {
        ID = id;
        Type = type;
        Color = color;
    }
    public override CardVariants ExecuteCardEffect(GameController gameController)
    {
        gameController.Divider.Invoke();
        gameController.GameInfo.Invoke($"{gameController.NextPlayer.Name} draw two cards \n");
        for (int i = 0; i<2; i++)
        {
            gameController.PlayerDrawCard(gameController.NextPlayer);
        }

        gameController.NextTurn();
        gameController.Divider.Invoke();
        return CardVariants.DrawTwo;
    }
}
