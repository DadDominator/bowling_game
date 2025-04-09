namespace BowlingGame.Interfaces;

public interface IFrame
{
    void StartNewFrame(int frameNumber);
    int GetScore();
    Dictionary<int, IRoll> GetRolls();
}