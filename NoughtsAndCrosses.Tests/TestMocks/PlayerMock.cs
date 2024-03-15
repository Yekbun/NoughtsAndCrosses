using NoughtsAndCrosses.Core;

namespace NoughtsAndCrosses.Tests.TestMocks
{
    public class PlayerMock : IPlayer
    {
        private int _index;
        private readonly string[] _moves;

        public PlayerMock()
        {
            _index = 0;
            _moves = null;
        }
        public PlayerMock FromMoves(params string[] moves)
        {
            return new PlayerMock(moves);
        }

        private PlayerMock(string[] moves)
        {
            _moves = moves;
        }

        public string GetNextMove()
        {
            var result = _moves[_index];
            _index += 1;
            return result;
        }
    
    }
}
