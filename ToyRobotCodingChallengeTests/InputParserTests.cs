using System.Linq;
using ToyRobotCodingChallenge.InputParser;
using Xunit;

namespace ToyRobotCodingChallengeTests
{
    public class InputParserTests
    {
        private readonly IInputParser _inputParser;

        public InputParserTests()
        {
            _inputParser = new InputParser();
        }

        [Fact]
        public void StandardPlaceInputsTest()
        {
            //Arrange
            var rawTxtInputs = "PLACE 0,0,NORTH MOVE REPORT";
            //Act
            var inputs = _inputParser.GetInputs(rawTxtInputs);

            //Assert
            Assert.NotNull(inputs);
            Assert.True(inputs.Count() == 3);
        }

        [Fact]
        public void NoPlaceCommandTest()
        {
            //Arrange
            var rawTxtInputs = "MOVE REPORT";
            //Act
            var inputs = _inputParser.GetInputs(rawTxtInputs);

            //Assert
            Assert.True(!inputs.Any());
        }

        [Fact]
        public void InvalidAndValidPlaceInputsTest()
        {
            //Arrange
            var rawTxtInputs = "PLACE 5,5,NORTH MOVE MOVE REPORT PLACE 1,1,NORTH REPORT MOVE MOVE MOVE MOVE MOVE MOVE MOVE REPORT";
            //Act
            var inputs = _inputParser.GetInputs(rawTxtInputs);

            //Assert
            Assert.NotNull(inputs);
            Assert.True(inputs.Count() == 10);
        }

        [Fact]
        public void OnlyInvalidPlaceInputsTest()
        {
            //Arrange
            var rawTxtInputs = "PLACE 5,5,NORTH MOVE MOVE REPORT PLACE -1,-1,NORTH REPORT MOVE MOVE MOVE MOVE MOVE MOVE MOVE REPORT";
            //Act
            var inputs = _inputParser.GetInputs(rawTxtInputs);

            //Assert
            Assert.True(!inputs.Any());
        }
    }
}