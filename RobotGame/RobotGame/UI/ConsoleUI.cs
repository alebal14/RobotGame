using RobotGame.Enums;
using RobotGame.Models;

namespace RobotGame.UI
{
    class ConsoleUI
    {
        public void DisplayWelcome()
        {
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║             ROBOT GAME               ║");
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.WriteLine("\nWelcome to Robot Game! Navigate your robot within a grid room.\n");
        }

        //Gets room dimenstion from user
        public RoomGrid GetRoomDimensions()
        {
            RoomGrid? room = null;

            //Loop until valid input received
            while (room == null)
            {

                Console.WriteLine("ROOM SETUP");
                Console.WriteLine("Please enter the room's dimension in format: Width Height");
                Console.WriteLine("Example: 5 5 for a 5x5 grid");

                var inputDimensions = Console.ReadLine();

                //validate input is not empty or too short
                if (inputDimensions == null || inputDimensions.Length < 3)
                {
                    Console.WriteLine("Invalid input, please enter two numbers, like this: 5 5\n");
                    continue;
                }

                string[] dimensions = inputDimensions.Split(' ');

                //Parse room's width and height as integers
                if (!int.TryParse(dimensions[0], out int width) || !int.TryParse(dimensions[1], out int height))
                {
                    Console.WriteLine("Invalid input, please enter two numbers, like this: 5 5\n");
                    continue;
                }

                //Ensures height and width are positive
                if (width <= 0 || height <= 0)
                {
                    Console.WriteLine("Room dimensions must be positive values.\n");
                    continue;
                }

                room = new RoomGrid(width, height);

                Console.WriteLine($"Thank you! Room size: {room.Width}x{room.Height} \n");

            }

            return room;
        }

        //Gets initial robot position from user
        public Robot GetRobotPlacement(RoomGrid room)
        {
            Robot? robot = null;

            while (robot == null)
            {

                Console.WriteLine("\nROBOT PLACEMENT");
                Console.WriteLine("Please place the robot in the room using format: X Y Direction");
                Console.WriteLine("Example: 1 2 N (position X=1, Y=2, facing North)");
                Console.WriteLine("Valid directions: N (North), E (East), S (South), W (West)");

                var inputPlace = Console.ReadLine();

                // Validate input is not empty or too short
                if (inputPlace == null || inputPlace.Length < 4)
                {
                    Console.WriteLine("Invalid input, please enter two number and a Direction, like this: 5 5 N \n");
                    continue;
                }

                var startPosition = inputPlace.Split(' ');

                // Parse X and Y coordinates as integers
                if (!int.TryParse(startPosition[0], out int startX) || !int.TryParse(startPosition[1], out int startY))
                {
                    Console.WriteLine("Invalid position. Both X and Y must be integers. \n");
                    continue;
                }

                // Check if input position is within room boundaries
                if (startX < 0 || startX >= room.Width || startY < 0 || startY >= room.Height)
                {
                    Console.WriteLine($"Position ({startX},{startY}) is outside the room bounds. Valid positions are from (0,0) to ({room.Width - 1},{room.Height - 1}). \n");
                    continue;
                }

                var position = new Position(startX, startY);

                char directionChar = startPosition[2][0];

                //Parse robot's direction
                Direction direction;
                switch (directionChar)
                {
                    case 'N':
                        direction = Direction.North;
                        break;
                    case 'E':
                        direction = Direction.East;
                        break;
                    case 'S':
                        direction = Direction.South;
                        break;
                    case 'W':
                        direction = Direction.West;
                        break;
                    default:
                        Console.Write($"Invalid direction: {directionChar}. Use N, E, S, or W \n");
                        continue;
                }

                robot = new Robot(position, direction);

                Console.WriteLine($"\nRobot placed at position ({robot.Position.X},{robot.Position.Y}) facing {robot.Orientation}");

            }

            return robot;
        }

        //Gets movement commands from user 
        public string GetMovementCommands()
        {
            string? inputCommands = null;

            while (string.IsNullOrEmpty(inputCommands))
            {

                Console.WriteLine("\nNAVIGATION");
                Console.WriteLine("Enter movement commands (no spaces):");
                Console.WriteLine("L = Turn Left, R = Turn Right, F = Move Forward");
                Console.WriteLine("Example: LFRFF (Left, Forward, Right, Forward, Forward)");

                inputCommands = Console.ReadLine();

                // Validate input is not empty
                if (string.IsNullOrEmpty(inputCommands))
                {
                    Console.WriteLine("No moves provided\n");
                    continue;
                }

                // Validate each input character is a valid command
                bool invalidCommandFound = false;
                foreach (char command in inputCommands.ToUpper())
                {
                    if (command != 'L' && command != 'R' && command != 'F')
                    {
                        Console.WriteLine($"Invalid move: {command}. Use only L, R, or F\n");
                        inputCommands = null;
                        invalidCommandFound = true;
                        break;
                    }
                }

                if (invalidCommandFound)
                {
                    continue;
                }

            }

            return inputCommands.ToUpper();
        }

        public void DisplayResult(CommandResult result)
        {

            Console.WriteLine($"Report: {result.Robot.Position.X} {result.Robot.Position.Y} {(char)result.Robot.Orientation}");

        }


        public void DisplayGameOver()
        {
            Console.WriteLine("\n╔══════════════════════════════════════╗");
            Console.WriteLine("║            GAME OVER!                ║");
            Console.WriteLine("╚══════════════════════════════════════╝");

            Console.WriteLine("\nOh no! Your robot tried to leave the room and crashed!");

        }
    }
}
