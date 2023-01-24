using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ToyRobotCodingChallenge.Common;
using ToyRobotCodingChallenge.Robot;

namespace ToyRobotCodingChallenge.InputParser
{
    public class InputParser : IInputParser
    {
        public IEnumerable<CommandAndValue> GetInputs(string rawTxtFile)
        {
            var culture = new CultureInfo("en-US", false);

            var commands = rawTxtFile.Split(" ").ToList();

            if (!commands.Contains(InputWord.Place))
            {
                return Enumerable.Empty<CommandAndValue>();
            }

            var numberOfPlaceCommands = commands.FindAll(x => x == InputWord.Place);

            if (!DoesValidPlaceCommandExist(commands, numberOfPlaceCommands))
            {
                return Enumerable.Empty<CommandAndValue>();
            }

            var startIndex = commands.IndexOf(InputWord.Place) + 1;

            var commandActions = new List<CommandAndValue>();

            foreach (var command in commands.Skip(startIndex))
            {
                if (command == InputWord.Place)
                {
                    continue;
                }

                if (command.Contains(','))
                {
                    commandActions.Add(new CommandAndValue()
                    {
                        Command = Command.Place,
                        Value = command
                    });
                    continue;
                }

                HandleNonPlaceCommands(culture, commandActions, command);
            }

            return commandActions;
        }

        private static void HandleNonPlaceCommands(CultureInfo culture, List<CommandAndValue> commandActions, string command)
        {
            var convertedEnum = (Command)Enum.Parse(typeof(Command), culture.TextInfo.ToTitleCase(command.ToLower()));

            commandActions.Add(new CommandAndValue()
            {
                Command = convertedEnum
            });
        }

        private static bool DoesValidPlaceCommandExist(List<string> commands, List<string> numberOfPlaceCommands)
        {
            foreach (var placeCommand in numberOfPlaceCommands)
            {
                var placeIndex = commands.IndexOf(InputWord.Place);

                var placeIndexValues = commands[placeIndex + 1];

                if (ValidatePlaceIndexValues(placeIndexValues))
                {
                    return true;
                }
                commands.RemoveAt(placeIndex);
            }

            return false;
        }

        private static bool ValidatePlaceIndexValues(string placeIndexValues)
        {
            var values = placeIndexValues.Split(',');

            var placementPosition = new Position()
            {
                X = int.Parse(values[0]),
                Y = int.Parse(values[1])
            };

            return MovementValidator.IsNextMoveValid(placementPosition);
        }
    }
}