using NoughtsAndCrosses.Core;
using NoughtsAndCrosses.Tests.TestMocks;

namespace NoughtsAndCrosses.Tests
{
    [TestClass]
    public class PlayGameTests
    {        
        private StubTextReader _input;
        private StringWriter _output;
        private PlayGame _playGame;
        private GameMock _gameMock;

        [TestInitialize]
        public void Init()
        {
            _gameMock = new GameMock();
            _input = new StubTextReader();
            _output = new StringWriter();     
            _playGame= new PlayGame(_input, _output);  
        }

        [TestMethod]
        public async Task PlayGame_ShouldShowSelectedPlayer()
        {
            _input.WriteLine("X");

            _playGame.SelectPlayers(null);

            Assert.AreEqual(_output.ToString().StartsWith("Select player (X or O): "), true);
        }

        [TestMethod]
        public async Task PlayGame_ShouldSupportCaseSensetive()
        {
            _input.WriteLine("x");

            _playGame.SelectPlayers(null);

            Assert.AreEqual(_output.ToString().StartsWith("Select player (X or O): "), true);
        }

        [TestMethod]
        public async Task PlayGame_ShouldContinuePromptingForPlayerUntilValidInput()
        {
            _input.WriteLine("A0!");
            _input.WriteLine("X");

            _playGame.SelectPlayers(null);

            var prompt = "Select player (X or O): " + Environment.NewLine;
            Assert.AreEqual(_output.ToString().StartsWith(prompt + prompt),true);
        }

        [TestMethod]
        public async Task PlayGame_ShouldSetOToComputerPlayerIfSelectedPlayerIsX()
        {
            //Arrange      
            _input.WriteLine("X");
            _playGame.SelectPlayers(null);
            var result=  _playGame.Player("X");            
            Assert.AreSame(result.GetType(), new HumanPlayer(null, null, null).GetType());

            //Act
            result = _playGame.Player("O");

            //Assert
            Assert.AreSame(result.GetType(), new ComputerPlayer(null).GetType());
        }

        [TestMethod]
        public async Task PlayGame_ShouldSetXToComputerPlayerIfSelectedPlayerIsO()
        {
            //Arrange      
            _input.WriteLine("O");
            _playGame.SelectPlayers(null);
            var result = _playGame.Player("O");
            Assert.AreSame(result.GetType(), new HumanPlayer(null, null, null).GetType());

            //Act
            result = _playGame.Player("X");

            //Assert
            Assert.AreSame(result.GetType(), new ComputerPlayer(null).GetType());
        }

        [TestMethod]
        public async Task PlayGame_ShouldShowForDrawResult()
        {
            //Arrange
            var game = _gameMock.MakeMoves("X1", "O2", "X3", "O4", "X5", "O7", "X6", "O9", "X8");

            //Act
            _playGame.PrintResult(game);

            //Assert
            Assert.AreEqual(_output.ToString(),("Draw!" + Environment.NewLine));
        }

        [TestMethod]
        public async Task PlayGame_ShouldShowWinnerResult()
        {
            //Arrange
            var game = _gameMock.MakeMoves("X1", "O3", "X2", "O5", "X9", "O7");

            //Act
            _playGame.PrintResult(game);

            //Assert
            Assert.AreEqual(_output.ToString() ,("Player O Wins!" + Environment.NewLine));
        }
    }
}
