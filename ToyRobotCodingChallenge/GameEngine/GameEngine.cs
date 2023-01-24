using System;
using ToyRobotCodingChallenge.Common;
using ToyRobotCodingChallenge.InputParser;
using ToyRobotCodingChallenge.Robot;
using ToyRobotCodingChallenge.Robot.Interfaces;

namespace ToyRobotCodingChallenge.GameEngine
{
    public class GameEngine : IGameEngine
    {
        public IRobot Robot { get; private set; }

        public GameEngine(IRobot robot)
        {
            Robot = robot;
        }

        public void ProcessCommand(CommandAndValue commandAndValue)
        {
            switch (commandAndValue.Command)
            {
                case Command.Place:
                    var values = commandAndValue.Value.Split(',');
                    Robot.Place(values);
                    break;

                case Command.Move:
                    Robot.Move();
                    break;

                case Command.Left:
                    Robot.Rotate(Rotation.Left);
                    break;

                case Command.Right:
                    Robot.Rotate(Rotation.Right);
                    break;

                case Command.Report:
                    var location = Robot.ReportLocation();
                    Console.WriteLine(location);
                    break;
            }
        }
    }
}