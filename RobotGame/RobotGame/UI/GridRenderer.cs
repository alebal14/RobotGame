using RobotGame.Enums;
using RobotGame.Models;

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

        //Renders the grid with the robot's position to the console
        public void DrawGrid()
        {
            //Prepare the grid with empty cells and robot 
            DrawEmptyCells();
            PlaceRobot();

            //Draw top border
            Console.WriteLine(new string('-', _room.Width * 2 + 3));

            //Draw each row from top to bottom
            for (int y = _room.Width - 1; y >= 0; y--)
            {
                //Draw row numbers and left border
                Console.Write($"{y}|");

                // Draw cells in the row
                for (int x = 0; x < _room.Height; x++)
                {
                    Console.Write($"{_grid[x, y]} ");
                }

                // Draw right border
                Console.WriteLine("|");
            }

            // Draw bottom border
            Console.WriteLine(new string('-', _room.Height * 2 + 3));

            Console.Write(" ");

            // Draw x-axis labels
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
            // Get the ASCII character based on robot orientation
            char robotChar = GetAsciiRobotChar(_robot.Orientation);

            // Place the robot character at its position
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