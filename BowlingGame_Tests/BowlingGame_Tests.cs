using BowlingGame;
using BowlingGame.Interfaces;

namespace BowlingGame_Tests;

public class BowlingGame_Tests
{
    [Fact]
    public void StandardGame_ReturnsProvidedScore()
    {
        //Arrange
        var game = SetupProvidedGame();

        //Action
        var score = game.GetScore();
        
        //Assert
        Assert.Equal<int>(110, score);
    }
    
    [Fact]
    public void PerfectGame_ReturnsCorrectScore()
    {
        //Arrange
        var game = SetupPerfectGame();

        //Action
        var score = game.GetScore();
        
        //Assert
        Assert.Equal<int>(300, score);
    }

    private IGame SetupProvidedGame()
    {
        var game = new Game();
        
        var frame1 = new Frame();
        frame1.Rolls.Add(1, new Roll(4));
        frame1.Rolls.Add(2, new Roll(3));
        game.Frames.Add(1, frame1);
        
        var frame2 = new Frame();
        frame2.Rolls.Add(1, new Roll(7));
        frame2.Rolls.Add(2, new Roll(3));
        game.Frames.Add(2, frame2);
        
        var frame3 = new Frame();
        frame3.Rolls.Add(1, new Roll(5));
        frame3.Rolls.Add(2, new Roll(2));
        game.Frames.Add(3, frame3);
        
        var frame4 = new Frame();
        frame4.Rolls.Add(1, new Roll(8));
        frame4.Rolls.Add(2, new Roll(1));
        game.Frames.Add(4, frame4);
        
        var frame5 = new Frame();
        frame5.Rolls.Add(1, new Roll(4));
        frame5.Rolls.Add(2, new Roll(6));
        game.Frames.Add(5, frame5);
        
        var frame6 = new Frame();
        frame6.Rolls.Add(1, new Roll(2));
        frame6.Rolls.Add(2, new Roll(4));
        game.Frames.Add(6, frame6);
        
        var frame7 = new Frame();
        frame7.Rolls.Add(1, new Roll(8));
        frame7.Rolls.Add(2, new Roll(0));
        game.Frames.Add(7, frame7);
        
        var frame8 = new Frame();
        frame8.Rolls.Add(1, new Roll(8));
        frame8.Rolls.Add(2, new Roll(0));
        game.Frames.Add(8, frame8);
        
        var frame9 = new Frame();
        frame9.Rolls.Add(1, new Roll(8));
        frame9.Rolls.Add(2, new Roll(2));
        game.Frames.Add(9, frame9);
        
        var frame10 = new Frame();
        frame10.Rolls.Add(1, new Roll(10));
        frame10.Rolls.Add(2, new Roll(1));
        frame10.Rolls.Add(3, new Roll(7));
        game.Frames.Add(10, frame10);
        
        return game;
    }

    private IGame SetupPerfectGame()
    {
        var game = new Game();
        
        var frame1 = new Frame();
        frame1.Rolls.Add(1, new Roll(10));
        game.Frames.Add(1, frame1);
        
        var frame2 = new Frame();
        frame2.Rolls.Add(1, new Roll(10));
        game.Frames.Add(2, frame2);
        
        var frame3 = new Frame();
        frame3.Rolls.Add(1, new Roll(10));
        game.Frames.Add(3, frame3);
        
        var frame4 = new Frame();
        frame4.Rolls.Add(1, new Roll(10));
        game.Frames.Add(4, frame4);
        
        var frame5 = new Frame();
        frame5.Rolls.Add(1, new Roll(10));
        game.Frames.Add(5, frame5);
        
        var frame6 = new Frame();
        frame6.Rolls.Add(1, new Roll(10));
        game.Frames.Add(6, frame6);
        
        var frame7 = new Frame();
        frame7.Rolls.Add(1, new Roll(10));
        game.Frames.Add(7, frame7);
        
        var frame8 = new Frame();
        frame8.Rolls.Add(1, new Roll(10));
        game.Frames.Add(8, frame8);
        
        var frame9 = new Frame();
        frame9.Rolls.Add(1, new Roll(10));
        game.Frames.Add(9, frame9);
        
        var frame10 = new Frame();
        frame10.Rolls.Add(1, new Roll(10));
        frame10.Rolls.Add(2, new Roll(10));
        frame10.Rolls.Add(3, new Roll(10));
        game.Frames.Add(10, frame10);
        
        return game;
    }
}