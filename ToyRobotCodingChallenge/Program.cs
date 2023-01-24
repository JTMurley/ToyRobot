using System;
using System.IO;
using System.Linq;
using ToyRobotCodingChallenge.GameEngine;
using ToyRobotCodingChallenge.InputParser;
using ToyRobotCodingChallenge.Robot.Interfaces;

namespace ToyRobotCodingChallenge
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Toy Robot Simulator");

            IInputParser inputParser = new InputParser.InputParser();
            IRobot robot = new Robot.Robot();
            IGameEngine gameEngine = new GameEngine.GameEngine(robot);

            var filePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            var rawTxtFile = File.ReadAllText($"{filePath}\\Commands.txt");

            var commands = inputParser.GetInputs(rawTxtFile);

            if (!commands.Any())
            {
                Console.WriteLine("No valid commands were found");
            }

            foreach (var command in commands)
            {
                gameEngine.ProcessCommand(command);
            }
        }
    }
}