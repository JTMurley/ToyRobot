using System;
using System.Globalization;
using ToyRobotCodingChallenge.Common;
using ToyRobotCodingChallenge.Robot.Interfaces;
using ToyRobotCodingChallenge.Robot.Models;

namespace ToyRobotCodingChallenge.Robot
{
    public class Robot : IRobot
    {
        public Direction Direction { get; private set; }
        public Position Position { get; private set; }

        /// <summary>
        /// Updates the toy robotos location as well as direction
        /// </summary>
        /// <param name="position"></param>
        /// <param name="direction"></param>
        public void Place(string[] values)
        {
            var textInfo = new CultureInfo("en-US", false).TextInfo;

            var position = new Position()
            {
                X = int.Parse(values[0]),
                Y = int.Parse(values[1])
            };

            if (!MovementValidator.IsNextMoveValid(position))
            {
                return;
            }

            var direction = (Direction)Enum.Parse(typeof(Direction), textInfo.ToTitleCase(values[2].ToLower()));

            Direction = direction;
            Position = position;
        }

        public void Move()
        {
            var newPosition = GetNextLocation();

            if (newPosition == null)
            {
                return;
            }

            if (MovementValidator.IsNextMoveValid(newPosition))
            {
                Position = newPosition;
            }
        }

        public string ReportLocation()
        {
            if (Position == null || Position.X == null || Position.Y == null || Direction == null)
            {
                return "Robot Is not on the board";
            }

            return $"{Position.X}, {Position.Y}, {Direction}";
        }

        public void Rotate(Rotation direction)
        {
            switch (direction)
            {
                case Rotation.Left:
                    RotateLeft();
                    break;

                case Rotation.Right:
                    RotateRight();
                    break;
            }
        }

        private Position GetNextLocation()
        {
            if (Position == null || Position.X == null || Position.Y == null)
            {
                return null;
            }

            var nextLocation = new Position()
            {
                X = Position.X,
                Y = Position.Y,
            };

            switch (Direction)
            {
                case Direction.North:
                    nextLocation.Y++;
                    break;

                case Direction.East:
                    nextLocation.X++;
                    break;

                case Direction.South:
                    nextLocation.Y--;
                    break;

                case Direction.West:
                    nextLocation.Y++;
                    break;
            }

            return nextLocation;
        }

        private void RotateLeft()
        {
            switch (Direction)
            {
                case Direction.North:
                    Direction = Direction.West;
                    break;

                case Direction.East:
                    Direction = Direction.North;
                    break;

                case Direction.South:
                    Direction = Direction.East;
                    break;

                case Direction.West:
                    Direction = Direction.South;
                    break;
            }
        }

        private void RotateRight()
        {
            switch (Direction)
            {
                case Direction.North:
                    Direction = Direction.East;
                    break;

                case Direction.East:
                    Direction = Direction.South;
                    break;

                case Direction.South:
                    Direction = Direction.West;
                    break;

                case Direction.West:
                    Direction = Direction.North;
                    break;
            }
        }
    }
}