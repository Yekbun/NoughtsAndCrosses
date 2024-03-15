
using NoughtsAndCrosses.Core;

namespace NoughtsAndCrosses.Tests
{
    [TestClass]
    public class StubTextReaderTests
    {
        [TestMethod]
        public async Task ReadLine_ShouldReturnEmptyStringIfNothingWritten()
        {
            //Arrange   
            var reader = new StubTextReader();

            //Act
            var result = reader.ReadLine();

            //Assert
            Assert.AreEqual(result, "");
        }

        [TestMethod]
        public async Task ReadLine_ShouldReadFirstLineOfText()
        {
            //Arrange                          
            var reader = new StubTextReader();
            reader.WriteLine("First Line");
            reader.WriteLine("Second Line");

            //Act
            var result = reader.ReadLine();

            //Assert
            Assert.AreEqual(result, "First Line");
        }

        [TestMethod]
        public async Task ReadLine_ShouldReadSeconLineOfTextIfreadTwoTimes()
        {
            //Arrange   
            var reader = new StubTextReader();
            reader.WriteLine("First Line");
            reader.WriteLine("Second Line");
            reader.ReadLine();

            //Act
            var result = reader.ReadLine();


            //Assert
            Assert.AreEqual(result, "Second Line");
        }
    }
}
