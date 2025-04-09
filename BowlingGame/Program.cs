using Microsoft.Extensions.DependencyInjection;
using BowlingGame.Interfaces;

namespace BowlingGame;

class Program
{
    private static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IRoll, Roll>()
            .AddSingleton<IFrame, Frame>()
            .AddSingleton<IGame, Game>()
            .BuildServiceProvider();
        
        var game = serviceProvider.GetService<IGame>();
        game.StartNewGame();
        Console.WriteLine($"Total Score: {game.GetScore()}");
        
        //TODO Praise
    }
}
