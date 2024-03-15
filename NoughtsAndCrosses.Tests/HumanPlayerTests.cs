using NoughtsAndCrosses.Core;
using NoughtsAndCrosses.Tests.TestMocks;


namespace NoughtsAndCrosses.Tests
{
    [TestClass]
    public class HumanPlayerTests
    {
        private GameMock _gameMock;        
        private StubTextReader _input;
        private StringWriter _output;        

        [TestInitialize]
        public void Init()
        {
            _gameMock = new GameMock();          
            _input = new StubTextReader();
            _output = new StringWriter();            
        }

        [TestMethod]
        public async Task GetNextMove_ShouldHaveAllOptions()
        {
            //Arrange                        
            _input.WriteLine("1");
            var game = _gameMock.MakeMoves("X2");
            var player = new HumanPlayer(game, _input, _output);

            //Act
            player.GetNextMove();

            //Assert
            Assert.AreEqual(_output.ToString().Contains("| 1 | X | 3 |\r\n| 4 | 5 | 6 |\r\n| 7 | 8 | 9 |\r\n"), true);
        }

        [TestMethod]
        public async Task GetNextMove_ShouldShowAllPreviousMoves()
        {
            //Arrange
            _input.WriteLine("9");
            var game = _gameMock.MakeMoves( "X1", "O2", "X3", "O4", "X5", "O6");
            var player = new HumanPlayer(game, _input, _output);
            
            //Act            
            player.GetNextMove();

            //Assert
            Assert.AreEqual(_output.ToString().Contains("| X | O | X |\r\n| O | X | O |\r\n| 7 | 8 | 9 |"), true);
        }

        [TestMethod]
        public async Task GetNextMove_ShouldShowSelectYourMovePrompt()
        {
            //Arrange
            _input.WriteLine("1");
            var game = _gameMock.MakeMoves( "X3");
            var player = new HumanPlayer(game, _input, _output);

            //Act            
            player.GetNextMove();          

            //Assert
            Assert.AreEqual(_output.ToString().Contains("Select your move (1, 2, 4, 5, 6, 7, 8, 9): "), true);
        }

        [TestMethod]
        public async Task GetNextMove_ShouldShowOnlyAvailableMoves()
        {
            //Arrange
            _input.WriteLine("9");
            var game = _gameMock.MakeMoves( "X1", "O2", "X3", "O4", "X5", "O7");
            var player = new HumanPlayer(game, _input, _output);

            //Act            
            player.GetNextMove();

            //Assert
            Assert.AreEqual(_output.ToString().Contains("\r\nSelect your move (6, 8, 9):"), true);
        }

        [TestMethod]
        public async Task GetNextMove_ShouldReturnValueFromInput()
        {
            //Arrange 
            string inputValue = "8";
            _input.WriteLine(inputValue);
            var game = _gameMock.MakeMoves( "X4","O9");
            var player = new HumanPlayer(game, _input, _output);

            //Act 
            var result = player.GetNextMove();

            //Assert
            Assert.AreEqual(result, inputValue);
        }       
    }
}
