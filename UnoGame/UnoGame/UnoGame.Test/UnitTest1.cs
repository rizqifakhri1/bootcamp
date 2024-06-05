namespace UnoGame.Test;
using UnoGame;
using UnoGame.Enum;

// [TestFixture]
public class GameControllerTests
{
    [Test]
    public void ChangeRotation_ShouldChangeToCounterClockwise()
    {
        // Arrange
        var gameController = new GameController();
        gameController.SetRotation(GameRotation.Clockwise);

        // Act
        gameController.ChangeRotation();

        // Assert
        Assert.AreEqual(GameRotation.CounterClockwise, gameController.Rotation);
    }

    [Test]
    public void ChangeRotation_ShouldChangeToClockwise()
    {
        // Arrange
        var gameController = new GameController();
        gameController.SetRotation(GameRotation.CounterClockwise);

        // Act
        gameController.ChangeRotation();

        // Assert
        Assert.AreEqual(GameRotation.Clockwise, gameController.Rotation);
    }
}
