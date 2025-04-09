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

                if (nextFrame.Count >= 2)
                {
                    totalScore += Frames[i + 1].GetRolls()[1].Value + Frames[i + 1].GetRolls()[2].Value;
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
        return Frames[frame].GetScore() == 10 && Frames[frame].GetRolls().Count == 2;
    }
}