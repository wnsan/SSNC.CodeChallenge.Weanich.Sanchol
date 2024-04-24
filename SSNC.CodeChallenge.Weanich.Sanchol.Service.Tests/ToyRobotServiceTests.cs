using SSNC.CodeChallenge.Weanich.Sanchol.Domains;
using SSNC.CodeChallenge.Weanich.Sanchol.Services;

namespace SSNC.CodeChallenge.Weanich.Sanchol.Service.Tests
{
    [TestClass]
    public class ToyRobotServiceTests
    {
        [TestMethod]
        public void Place_WhenPositionValid_PlaceValidToyToBoard()
        {
            // Arrange
            var toy = new Toy();
            var board = new Board(5, 5);

            var service = new ToyRobotService();

            // Act
            service.Place(toy, board, 0, 0, "NORTH");

            // Assert
            Assert.AreEqual(0, toy.PositionX);
            Assert.AreEqual(0, toy.PositionY);
            Assert.AreEqual("NORTH", toy.Direction);
        }
    }
}