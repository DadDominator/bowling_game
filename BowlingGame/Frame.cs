using BowlingGame.Interfaces;

namespace BowlingGame;

public class Frame : IFrame
{
    private const int RollLimit = 2;
    public readonly Dictionary<int, IRoll> Rolls = new();

    public void StartNewFrame(int frameNumber)
    {
        var rollLimit = RollLimit;
        for (var i = 1; i <= rollLimit; i++)
        {
            Console.WriteLine($"Please, enter a value for roll {i} of frame {frameNumber}");
            var rollValue = Console.ReadLine();
            if (int.TryParse(rollValue, out var roll) && roll is >= 0 and <= 10)
            {
                if (i == 2 && (Convert.ToInt32(rollValue) + Rolls[i - 1].Value) is < 0 or > 10)
                {
                    Console.WriteLine($"Invalid roll: {roll}. Total Frame score must be between 0 and 10.");
                    i--;
                    continue;
                }
                else
                {
                    Rolls.Add(i, new Roll(roll));
                }
            }
            else
            {
                Console.WriteLine($"Invalid roll: {roll}. Value must be a number between 0 and 10.");
                i--;
                continue;
            }

            if (i == 1 && GetScore() == 10)
            {
                rollLimit = 1;
                Rolls.Add(2, new Roll(0));
            }

            if (frameNumber == 10 && (IsStrike(i) || IsSpare(i)))
            {
                rollLimit = 3;
            }
        }
    }

    public int GetScore()
    {
        return Rolls.Sum(roll => roll.Value.Value);
    }

    public Dictionary<int, IRoll> GetRolls()
    {
        return Rolls;
    }

    private bool IsStrike(int roll)
    {
        return Rolls[roll].Value == 10;
    }

    private bool IsSpare(int roll)
    {
        if (roll != 2) return false;
        
        return Rolls[roll].Value + Rolls[roll - 1].Value == 10;
    }
}