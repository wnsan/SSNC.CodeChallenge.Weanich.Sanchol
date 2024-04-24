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

        [TestMethod]
        [DataRow(-1, 0)]
        [DataRow(0, -1)]
        [DataRow(5, 0)]
        [DataRow(0, 5)]
        [DataRow(6, 0)]
        [DataRow(0, 6)]
        public void Place_WhenPositionInValid_IgnoreChange(int x, int y)
        {
            // Arrange
            var toy = new Toy();
            var board = new Board(5, 5);

            var service = new ToyRobotService();

            // Act
            service.Place(toy, board, x, y, "NORTH");

            // Assert
            Assert.IsNull(toy.PositionX);
            Assert.IsNull(toy.PositionY);
            Assert.IsNull(toy.Direction);
        }
    }
}