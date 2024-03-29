﻿
namespace NoughtsAndCrosses.Core
{
    public class HumanPlayer : IPlayer
    {
        private readonly Game _game;
        private readonly TextReader _input;
        private readonly TextWriter _output;

        public HumanPlayer(Game game, TextReader input, TextWriter output)
        {
            _game = game;
            _input = input;
            _output = output;
        }

        public string GetNextMove()
        {
            _output.WriteLine(GetCurrentBoard());
            return GetMove();
        }

        private string GetCurrentBoard()
        {
            var board = @"
| 1 | 2 | 3 |
| 4 | 5 | 6 |
| 7 | 8 | 9 |".Trim();
            board = _game.MovesFor("X").Aggregate(board, (current, move) => current.Replace(move, "X"));
            board = _game.MovesFor("O").Aggregate(board, (current, move) => current.Replace(move, "O"));
            return board;
        }

        private string GetMove()
        {
            string result;
            do
            {
                _output.Write(MovePrompt());
                result = _input.ReadLine();
                _output.WriteLine();
            } while (!_game.IsAllowedMove(result));
            return result;
        }

        private string MovePrompt()
        {
            return string.Format("Select your move ({0}): ", string.Join(", ", _game.AvailableMoves));
        }
    }
}
