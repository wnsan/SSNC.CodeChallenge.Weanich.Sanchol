using SSNC.CodeChallenge.Weanich.Sanchol.Domains;
using SSNC.CodeChallenge.Weanich.Sanchol.Services;
using System.ComponentModel;
using System.Runtime.Intrinsics.X86;

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

        [TestMethod]
        [DataRow(0, 0, "NORTH", 0, 1, "NORTH")]
        [DataRow(0, 0, "EAST", 1, 0, "EAST")]
        public void Move_WhenNextPositionValid_MoveToyToNextPosition
            (int atX, int atY, string atDirection,
             int expectedX, int expectedY, string expectedPosition)
        {
            // Arrange
            var toy = new Toy();
            var board = new Board(5, 5);
            var service = new ToyRobotService();
            service.Place(toy, board, atX, atY, atDirection);

            // Act
            service.Move(toy, board);

            // Assert
            Assert.AreEqual(expectedX, toy.PositionX);
            Assert.AreEqual(expectedY, toy.PositionY);
            Assert.AreEqual(expectedPosition, toy.Direction);
        }

        [TestMethod]
        [DataRow(0, 0, "SOUTH", 0, 0, "SOUTH")]
        [DataRow(0, 0, "WEST", 0, 0, "WEST")]
        [DataRow(4, 0, "EAST", 4, 0, "EAST")]
        [DataRow(4, 0, "SOUTH", 4, 0, "SOUTH")]
        [DataRow(0, 4, "NORTH", 0, 4, "NORTH")]
        [DataRow(0, 4, "WEST", 0, 4, "WEST")]
        [DataRow(4, 4, "NORTH", 4, 4, "NORTH")]
        [DataRow(4, 4, "EAST", 4, 4, "EAST")]
        public void Move_WhenNextPositionInValid_IgnoreMove
            (int atX, int atY, string atDirection,
             int expectedX, int expectedY, string expectedPosition)
        {
            // Arrange
            var toy = new Toy();
            var board = new Board(5, 5);
            var service = new ToyRobotService();
            service.Place(toy, board, atX, atY, atDirection);

            // Act
            service.Move(toy, board);

            // Assert
            Assert.AreEqual(expectedX, toy.PositionX);
            Assert.AreEqual(expectedY, toy.PositionY);
            Assert.AreEqual(expectedPosition, toy.Direction);
        }

        [TestMethod]
        [DataRow("NORTH", "WEST")]
        [DataRow("WEST", "SOUTH")]
        [DataRow("SOUTH", "EAST")]
        [DataRow("EAST", "NORTH")]
        public void TurnLeft_WhenToyIsValid_TurnDirectionToLeft(string atDirection, string expected)
        {
            // Arrange
            var toy = new Toy();
            var board = new Board(5, 5);
            var service = new ToyRobotService();
            service.Place(toy, board, 0, 0, atDirection);

            // Act
            service.TurnLeft(toy);

            // Assert
            Assert.AreEqual(expected, toy.Direction);
        }

        [TestMethod]
        [DataRow("NORTH", "EAST")]
        [DataRow("EAST", "SOUTH")]
        [DataRow("SOUTH", "WEST")]
        [DataRow("WEST", "NORTH")]
        public void TurnRight_WhenToyIsValid_TurnDirectionToLeft(string atDirection, string expected)
        {
            // Arrange
            var toy = new Toy();
            var board = new Board(5, 5);
            var service = new ToyRobotService();
            service.Place(toy, board, 0, 0, atDirection);

            // Act
            service.TurnRight(toy);

            // Assert
            Assert.AreEqual(expected, toy.Direction);
        }
    }
}