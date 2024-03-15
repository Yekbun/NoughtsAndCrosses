using NoughtsAndCrosses.Core;

namespace NoughtsAndCrosses.Tests.TestMocks
{
    public class GameMock
    {
        public Game MakeMoves(params string[] moves)
        {
            Game game = new Game();
            foreach (var move in moves)
            {
                var player = move.Substring(0, 1);
                var square = move.Substring(1);
                Assert.AreEqual(player, game.CurrentPlayer);
                game.MakeMove(square);
            }

            return game;
        }

        public Game CreateRandomGame()
        {
            var game = new Game();
            var random = new Random();
            var numberOfMoves = random.Next(1, 5);

            for (var i = 0; i < numberOfMoves; i++)
            {
                var moveIndex = random.Next(0, game.AvailableMoves.Length);
                var move = game.AvailableMoves[moveIndex];
                game.MakeMove(move);
            }

            return game;
        }
    }
}
