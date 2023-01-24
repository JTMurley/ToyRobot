using ToyRobotCodingChallenge.Common;

namespace ToyRobotCodingChallenge.Robot
{
    public static class MovementValidator
    {
        public static bool IsNextMoveValid(Position nextLocation)
        {
            if (nextLocation.X < 5 && nextLocation.X >= 0)
            {
                if (nextLocation.Y < 5 && nextLocation.Y >= 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}