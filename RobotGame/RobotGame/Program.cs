// See https://aka.ms/new-console-template for more information
using RobotGame.Enums;
using RobotGame.Models;

Console.WriteLine("╔══════════════════════════════════════╗");
Console.WriteLine("║             ROBOT GAME               ║");
Console.WriteLine("╚══════════════════════════════════════╝");
Console.WriteLine("\nWelcome to Robot Game! Navigate your robot within a grid room.\n");

Console.WriteLine("ROOM SETUP");
Console.ResetColor();
Console.WriteLine("Please enter the room's dimension in format: Width Height");
Console.WriteLine("Example: 5 5 for a 5x5 grid");


var inputDimensions = Console.ReadLine();
if (inputDimensions == null || inputDimensions.Length < 3)
{
    throw new ArgumentException("Invalid input, please enter two numbers, like this: 5 5");
}

var dimensions = inputDimensions.Split(' ');

int width = int.Parse(dimensions[0]);
int height = int.Parse(dimensions[1]);

var room = new RoomGrid(width, height);


Console.WriteLine($"Thank you! Room size: {room.Width}x{room.Height} \n");

Console.WriteLine("\nROBOT PLACEMENT");
Console.WriteLine("Please place the robot in the room using format: X Y Direction");
Console.WriteLine("Example: 1 2 N (position X=1, Y=2, facing North)");
Console.WriteLine("Valid directions: N (North), E (East), S (South), W (West)");

var inputPlace = Console.ReadLine();

if (inputPlace == null || inputPlace.Length < 4)
{
    throw new ArgumentException("Invalid input, please enter two number and a Direction, like this: 5 5 N");
}

var startPosition = inputPlace.Split(' ');

int startX = int.Parse(startPosition[0]);
int startY = int.Parse(startPosition[1]);

var position = new Position(startX, startY);

char directionChar = startPosition[2][0];

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
        throw new ArgumentException($"Invalid direction: {directionChar}. Use N, E, S, or W");
}

var robot = new Robot(position, direction);

Console.WriteLine($"\nRobot placed at position ({robot.Position.X},{robot.Position.Y}) facing {robot.Orientation}");

var isPlaying = true;

while (isPlaying)
{
    Console.WriteLine("\nNAVIGATION");
    Console.WriteLine("Enter movement commands (no spaces):");
    Console.WriteLine("L = Turn Left, R = Turn Right, F = Move Forward");
    Console.WriteLine("Example: LFRFF (Left, Forward, Right, Forward, Forward)");

    var inputMoves = Console.ReadLine();

    if (string.IsNullOrEmpty(inputMoves))
    {
        throw new ArgumentException("No moves provided");
    }

    foreach (char move in inputMoves.ToUpper())
    {

        if (move != 'L' && move != 'R' && move != 'F')
        {
            throw new ArgumentException($"Invalid move: {move}. Use only L, R, or F");
        }

        if (move == 'L')
        {
            Direction dir = robot.Orientation switch
            {
                Direction.North => Direction.West,
                Direction.West => Direction.South,
                Direction.South => Direction.East,
                Direction.East => Direction.North,
                _ => throw new InvalidOperationException($"Unknown direction: {robot.Orientation}")
            };

            robot.Orientation = dir;

        }
        if (move == 'R')
        {
            Direction dir = robot.Orientation switch
            {
                Direction.North => Direction.East,
                Direction.East => Direction.South,
                Direction.South => Direction.West,
                Direction.West => Direction.North,
                _ => throw new InvalidOperationException($"Unknown direction: {robot.Orientation}")
            };

            robot.Orientation = dir;

        }
        if (move == 'F')
        {

            Position newPosition = robot.Orientation switch
            {
                Direction.North => new Position(robot.Position.X, robot.Position.Y + 1),
                Direction.East => new Position(robot.Position.X + 1, robot.Position.Y),
                Direction.South => new Position(robot.Position.X, robot.Position.Y - 1),
                Direction.West => new Position(robot.Position.X - 1, robot.Position.Y),
                _ => throw new InvalidOperationException($"Unknown direction: {robot.Orientation}")
            };

            robot.Position = newPosition;

            if (newPosition.X < 0 || newPosition.X >= room.Width || newPosition.Y < 0 || newPosition.Y >= room.Height)
            {
                isPlaying = false;
            }

        }
    }

    Console.WriteLine($"Report: {robot.Position.X} {robot.Position.Y} {(char)robot.Orientation} \n");

}

Console.WriteLine("\n╔══════════════════════════════════════╗");
Console.WriteLine("║            GAME OVER!                ║");
Console.WriteLine("╚══════════════════════════════════════╝");

Console.WriteLine("\nOh no! Your robot tried to leave the room and crashed!");
