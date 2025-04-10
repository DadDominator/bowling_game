using BowlingGame.Interfaces;

namespace BowlingGame;

public class Game : IGame
{
    private const int FrameLimit = 10;
    public readonly Dictionary<int, IFrame> Frames = new();

    public void StartNewGame()
    {
        for (var i = 1; i <= FrameLimit; i++)
        {
            Frames.Add(i, new Frame());
            Frames[i].StartNewFrame(i);

            var praise = GetPraise(i);
            if (praise != string.Empty)
            {
                Console.WriteLine();
                Console.WriteLine(praise);
                Console.WriteLine();
            }
        }
    }

    public int GetScore()
    {
        var totalScore = 0;
        for (var i = 1; i <= FrameLimit; i++)
        {
            var frameScore = Frames[i].GetScore();
            totalScore += frameScore;

            if (IsSpare(i))
            {
                totalScore += Frames[i + 1].GetRolls()[1].Value;
            }

            if (IsStrike(i))
            {
                var nextFrame = Frames[i + 1].GetRolls();

                if (nextFrame.Count >= 2 && nextFrame[2].Value != 0)
                {
                    totalScore += nextFrame[1].Value + nextFrame[2].Value;
                }
                else
                {
                    totalScore += Frames[i + 1].GetScore() + Frames[i + 2].GetRolls()[1].Value;
                }
            }
        }

        return totalScore;
    }

    private bool IsStrike(int frame)
    {
        return Frames[frame].GetScore() == 10 && Frames[frame].GetRolls().Count == 1;
    }

    private bool IsSpare(int frame)
    {
        return Frames[frame].GetScore() == 10 && Frames[frame].GetRolls().Count > 1;
    }

    private string GetPraise(int frame)
    {
        if (Frames.Count == 10 && GetScore() == 300)
        {
            return "Congrats!! You bowled a perfect game.";
        }
        
        if (Frames.Count >= 9)
        {
            if (Frames[frame].GetRolls()[1].Value + 
                Frames[frame - 1].GetRolls()[1].Value +
                Frames[frame - 2].GetRolls()[1].Value +
                Frames[frame - 3].GetRolls()[1].Value +
                Frames[frame - 4].GetRolls()[1].Value +
                Frames[frame - 5].GetRolls()[1].Value +
                Frames[frame - 6].GetRolls()[1].Value +
                Frames[frame - 7].GetRolls()[1].Value +
                Frames[frame - 8].GetRolls()[1].Value == 90)
            {
                return "Congrats!! You bowled a golden turkey.";
            }
        }
        
        if (Frames.Count >= 6)
        {
            if (Frames[frame].GetRolls()[1].Value + 
                Frames[frame - 1].GetRolls()[1].Value +
                Frames[frame - 2].GetRolls()[1].Value +
                Frames[frame - 3].GetRolls()[1].Value +
                Frames[frame - 4].GetRolls()[1].Value == 60)
            {
                return "Congrats!! You bowled a wild turkey.";
            }
        }
        
        if (Frames.Count >= 5)
        {
            if (Frames[frame].GetRolls()[1].Value + 
                Frames[frame - 1].GetRolls()[1].Value +
                Frames[frame - 2].GetRolls()[1].Value +
                Frames[frame - 3].GetRolls()[1].Value +
                Frames[frame - 4].GetRolls()[1].Value == 50)
            {
                return "Congrats!! You bowled a yahtzee.";
            }
        }
        
        if (Frames.Count >= 4)
        {
            if (Frames[frame].GetRolls()[1].Value + 
                Frames[frame - 1].GetRolls()[1].Value +
                Frames[frame - 2].GetRolls()[1].Value +
                Frames[frame - 3].GetRolls()[1].Value == 40)
            {
                return "Congrats!! You bowled a four-bagger.";
            }
        }
        
        if (Frames.Count >= 3)
        {
            if (Frames[frame].GetRolls()[1].Value + 
                Frames[frame - 1].GetRolls()[1].Value +
                Frames[frame - 2].GetRolls()[1].Value == 30)
            {
                return "Congrats!! You bowled a turkey.";
            }
        }
        
        return string.Empty;
    }
}