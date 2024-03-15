namespace NoughtsAndCrosses.Core
{
    public class ComputerPlayer : IPlayer
    {
        private readonly Game _game;

        public ComputerPlayer(Game game)
        {
            _game = game;
        }

        public string GetNextMove()
        {
            var random = new Random();
            var moveIndex = random.Next(0, _game.AvailableMoves.Length);
            return _game.AvailableMoves[moveIndex];
        }
    }
}