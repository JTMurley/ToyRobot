using System.Collections.Generic;

namespace ToyRobotCodingChallenge.InputParser
{
    /// <summary>
    /// Handles parsing inputs via the TXT file provided
    /// </summary>
    public interface IInputParser
    {
        /// <summary>
        /// Based on the raw TXT, translates it into 
        /// </summary>
        /// <returns>A list of commands and values that can be used by the game engine</returns>
        IEnumerable<CommandAndValue> GetInputs(string rawTxtFile);
    }
}