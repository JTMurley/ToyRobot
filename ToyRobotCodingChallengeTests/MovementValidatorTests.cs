using ToyRobotCodingChallenge.Common;
using ToyRobotCodingChallenge.Robot;
using Xunit;

namespace ToyRobotCodingChallengeTests
{
    public class MovementValidatorTests
    {
        [Fact]
        public void ValidMovementTest()
        {
            //Arrange
            var movement = new Position()
            {
                X = 0,
                Y = 0
            };

            //Act
            var isValidMovement = MovementValidator.IsNextMoveValid(movement);
            
            //Assert
            Assert.True(isValidMovement);
        }

        [Fact]
        public void InvalidMovementTest()
        {
            //Arrange
            var movement = new Position()
            {
                X = 5,
                Y = 5
            };

            //Act
            var isValidMovement = MovementValidator.IsNextMoveValid(movement);

            //Assert
            Assert.False(isValidMovement);
        }
    }
}