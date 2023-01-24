using ToyRobotCodingChallenge.Robot;
using ToyRobotCodingChallenge.Robot.Interfaces;
using Xunit;

namespace ToyRobotCodingChallengeTests
{
    public class RobotTests
    {
        private readonly IRobot _robot;

        public RobotTests()
        {
            _robot = new Robot();
        }

        [Fact]
        public void RotateRightTest()
        {
            //Arrange
            var positionValues = new[] { "0", "0", "NORTH" };

            //Act
            _robot.Place(positionValues);
            _robot.Rotate(Rotation.Right);
            var result = _robot.ReportLocation();

            //Assert
            Assert.Equal("0, 0, East", result);
        }

        [Fact]
        public void RotateLeftTest()
        {
            //Arrange
            var positionValues = new[] { "0", "0", "NORTH" };

            //Act
            _robot.Place(positionValues);
            _robot.Rotate(Rotation.Left);
            var result = _robot.ReportLocation();

            //Assert
            Assert.Equal("0, 0, West", result);
        }

        [Fact]
        public void MoveFacingNorth()
        {
            //Arrange
            var positionValues = new[] { "0", "0", "NORTH" };

            //Act
            _robot.Place(positionValues);
            _robot.Move();
            var result = _robot.ReportLocation();

            //Assert
            Assert.Equal("0, 1, North", result);
        }

        [Fact]
        public void ReportLocationNotOnBoardTest()
        {
            //Arrange

            //Act
            _robot.Move();
            var result = _robot.ReportLocation();

            //Assert
            Assert.Equal("Robot Is not on the board", result);
        }
    }
}