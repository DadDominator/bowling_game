using BowlingGame.Interfaces;

namespace BowlingGame;

public class Frame : IFrame
{
    private const int RollLimit = 2;
    public readonly Dictionary<int, IRoll> Rolls = new Dictionary<int, IRoll>();

    public void StartNewFrame(int frameNumber)
    {
        var rollLimit = RollLimit;
        for (var i = 1; i <= rollLimit; i++)
        {
            Console.WriteLine($"Please, enter a value for roll {i} of frame {frameNumber}");
            var rollValue = Console.ReadLine();
            if (int.TryParse(rollValue, out var roll) && roll is >= 1 and <= 10)
            {
                Rolls.Add(i, new Roll(roll));
            }
            else
            {
                Console.WriteLine($"Invalid roll: {roll}. Value must be a number between 1 and 10.");
                i--;
                continue;
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