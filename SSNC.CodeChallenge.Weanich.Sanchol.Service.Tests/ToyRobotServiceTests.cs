using SSNC.CodeChallenge.Weanich.Sanchol.Domains;
using SSNC.CodeChallenge.Weanich.Sanchol.Services;
using System.ComponentModel;

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

        [TestMethod]
        public void Place_WhenDirectionInValid_IgnoreChange()
        {
            // Arrange
            var toy = new Toy();
            var board = new Board(5, 5);

            var service = new ToyRobotService();

            // Act
            service.Place(toy, board, 0, 0, "BELOW");

            // Assert
            Assert.IsNull(toy.PositionX);
            Assert.IsNull(toy.PositionY);
            Assert.IsNull(toy.Direction);
        }

        [TestMethod]
        [DataRow(0, 0 , "NORTH", "0,0,NORTH")]
        [DataRow(0, 0, "SOUTH", "0,0,SOUTH")]
        [DataRow(0, 0, "EAST", "0,0,EAST")]
        [DataRow(0, 0, "WEST", "0,0,WEST")]
        [DataRow(0, 1, "NORTH", "0,1,NORTH")]
        [DataRow(1, 0, "NORTH", "1,0,NORTH")]
        public void Report_WhenValidPosition_ReportToyPositionAndDirection
            (int x, int y, string direction, string expected)
        {
            // Arrange
            var toy = new Toy();
            var board = new Board(5, 5);

            var service = new ToyRobotService();
            service.Place(toy, board, x, y, direction);

            // Act
            var actual = service.Report(toy);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Report_WhenInValidPosition_ReturnNull()
        {
            // Arrange
            var toy = new Toy();
            var board = new Board(5, 5);

            var service = new ToyRobotService();
            service.Place(toy, board, -1, -1, "NORTH");

            // Act
            var actual = service.Report(toy);

            // Assert
            Assert.IsNull(actual);
        }
    }
}