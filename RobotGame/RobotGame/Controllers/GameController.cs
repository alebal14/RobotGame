﻿using RobotGame.Enums;
using RobotGame.Models;

namespace RobotGame.Controllers
{
    public class GameController
    {
        private readonly RoomGrid _room;
        private readonly Robot _robot;
        private bool _isRobotInside = true;

        public GameController(RoomGrid room, Robot robot)
        {
            _room = room;
            _robot = robot;
        }

        //Execute the robot movement commands
        public CommandResult ExecuteCommands(string commands)
        {

            foreach (char command in commands)
            {

                switch (command)
                {
                    case 'L':
                        TurnLeft();
                        break;
                    case 'R':
                        TurnRight();
                        break;
                    case 'F':
                        MoveForward();
                        break;
                }
            }

            var commanResult = new CommandResult
            {
                IsRobotInside = _isRobotInside,
                Robot = _robot
            };

            return commanResult;

        }

        private void TurnLeft()
        {
            _robot.Orientation = _robot.Orientation switch
            {
                Direction.North => Direction.West,
                Direction.West => Direction.South,
                Direction.South => Direction.East,
                Direction.East => Direction.North,
                _ => _robot.Orientation
            };
        }

        private void TurnRight()
        {
            _robot.Orientation = _robot.Orientation switch
            {
                Direction.North => Direction.East,
                Direction.East => Direction.South,
                Direction.South => Direction.West,
                Direction.West => Direction.North,
                _ => _robot.Orientation
            };
        }

        //Moves the robot one step forward
        //Checks if the robot is still inside the room
        private void MoveForward()
        {
            Position newPosition = _robot.Orientation switch
            {
                Direction.North => new Position(_robot.Position.X, _robot.Position.Y + 1),
                Direction.East => new Position(_robot.Position.X + 1, _robot.Position.Y),
                Direction.South => new Position(_robot.Position.X, _robot.Position.Y - 1),
                Direction.West => new Position(_robot.Position.X - 1, _robot.Position.Y),
                _ => _robot.Position
            };

            _robot.Position = newPosition;

            // Checks if robot remains inside the room
            _isRobotInside = IsPositionInside(newPosition);
        }

        private bool IsPositionInside(Position position)
        {
            return position.X >= 0 && position.X < _room.Width && position.Y >= 0 && position.Y < _room.Height;
        }
    }
}
