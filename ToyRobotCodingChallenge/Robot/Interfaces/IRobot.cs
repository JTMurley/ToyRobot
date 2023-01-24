namespace ToyRobotCodingChallenge.Robot.Interfaces
{
    /// <summary>
    ///
    /// </summary>
    public interface IRobot
    {
        /// <summary>
        /// Places the robot anywhere on the board as long as a valid position is provided
        /// </summary>
        /// <param name="position"></param>
        /// <param name="direction"></param>
        void Place(string[] values);

        /// <summary>
        /// Moves the robot forward by 1 space in relation to where it is facing
        /// </summary>
        void Move();

        /// <summary>
        /// Reports the location of the robot
        /// </summary>
        /// <returns></returns>
        string ReportLocation();

        /// <summary>
        ///
        /// </summary>
        /// <param name="direction"></param>
        void Rotate(Rotation direction);
    }
}