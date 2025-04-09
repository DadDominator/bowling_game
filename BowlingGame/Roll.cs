using BowlingGame.Interfaces;

namespace BowlingGame;

public class Roll(int value) : IRoll
{
    public int Value { get; set; } = value;
}