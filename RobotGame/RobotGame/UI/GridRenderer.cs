using RobotGame.Enums;
using RobotGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotGame.UI
{
    class GridRenderer
    {
        private readonly RoomGrid _room;
        private readonly Robot _robot;
        private readonly char[,] _grid;

        // Characters for display
        private const char EMPTY_CELL = '.';

        private const char ROBOT_NORTH_ASCII = '^';
        private const char ROBOT_EAST_ASCII = '>';
        private const char ROBOT_SOUTH_ASCII = 'v';
        private const char ROBOT_WEST_ASCII = '<';

        public GridRenderer(RoomGrid room, Robot robot)
        {
            _room = room;
            _robot = robot;
            _grid = new char[room.Height, room.Width];
        }

        public void DrawGrid()
        {
            DrawEmptyCells();
            PlaceRobot();            

            Console.WriteLine(new string('-', _room.Width * 2 + 3));

            for (int y = _room.Width - 1; y >= 0; y--)
            {
                Console.Write($"{y}|");
                for (int x = 0; x < _room.Height; x++)
                {
                    Console.Write($"{_grid[x, y]} ");
                }
                Console.WriteLine("|");
            }

            Console.WriteLine(new string('-', _room.Height * 2 + 3));
            Console.Write(" ");
            for (int x = 0; x < _room.Height; x++)
            {
                Console.Write($" {x}");
            }
            Console.WriteLine();
        }

        private void DrawEmptyCells()
        {
            for (int y = 0; y < _room.Height; y++)
            {
                for (int x = 0; x < _room.Width; x++)
                {
                    _grid[x, y] = EMPTY_CELL;
                }
            }
        }

        private void PlaceRobot()
        {
            char robotChar = GetAsciiRobotChar(_robot.Orientation);

            _grid[_robot.Position.X, _robot.Position.Y] = robotChar;
        }

        private char GetAsciiRobotChar(Direction direction)
        {
            return direction switch
            {
                Direction.North => ROBOT_NORTH_ASCII,
                Direction.East => ROBOT_EAST_ASCII,
                Direction.South => ROBOT_SOUTH_ASCII,
                Direction.West => ROBOT_WEST_ASCII,
                _ => '?'
            };
        }

    }
}
