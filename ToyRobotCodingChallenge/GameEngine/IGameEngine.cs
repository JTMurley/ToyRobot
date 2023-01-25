using ToyRobotCodingChallenge.InputParser;

namespace ToyRobotCodingChallenge.GameEngine
{
    /// <summary>
    /// The game engine handles the calling of all operations in relation to the game
    /// </summary>
    public interface IGameEngine
    {
        /// <summary>
        /// Based on the command passed in, executes that command
        /// </summary>
        /// <param name="command"></param>
        public void ProcessCommand(CommandAndValue commandAndValue);
    }
}