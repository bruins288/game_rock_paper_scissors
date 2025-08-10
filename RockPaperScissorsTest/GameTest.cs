using RockPaperScissorslib;

namespace RockPaperScissorsTest;

public class GameTest
{
    [Fact]
    public void PlayTestWhenEqual()
    {
        //Arrange
        Player player1 = new(isComputer: false, name: "Player1") { Choice = RockPaperScissorsEnum.Rock };
        Player player2 = new(isComputer: false, name: "Player2") { Choice = RockPaperScissorsEnum.Rock };
        //Act
        string actual = Game.Play(player1, player2);
        Assert.Equal("Ничья!", actual);
    }
    [Fact]
    public void GetComputerChoiceTest()
    {
        //Arrange 
        //Act
        RockPaperScissorsEnum actual = Game.GetComputerChoice();
        Assert.IsType<RockPaperScissorsEnum>(actual);
    }
}
