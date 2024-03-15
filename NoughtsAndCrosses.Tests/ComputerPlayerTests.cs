using NoughtsAndCrosses.Core;
using NoughtsAndCrosses.Tests.TestMocks;

namespace NoughtsAndCrosses.Tests
{
    [TestClass]
    public class ComputerPlayerTests
    {        
        private GameMock _gameMock;

        [TestInitialize]
        public void Init()
        {
            _gameMock = new GameMock();     
        }

        [TestMethod]
        public async Task GetNextMove_ShouldDoSuccessMove()
        {
            //Arrange                                    
            var game = _gameMock.CreateRandomGame();
            var allowedMoves = game.AvailableMoves;
            var player = new ComputerPlayer(game);

            //Act
            player.GetNextMove();            

            //Assert
            Assert.IsNotNull(allowedMoves);

        }

        [TestMethod]
        public async Task GetNextMove_ShouldGetAvailableMoves()
        {           
            //Arrange                                    
            var game = _gameMock.MakeMoves("X3", "O5", "X1");
            var allowedMoves = game.AvailableMoves;
            var player = new ComputerPlayer(game);

            //Act
            var move = player.GetNextMove();
            var result = allowedMoves.Contains(move);

            //Assert
            Assert.AreEqual(true, result);

        }
    }
}
