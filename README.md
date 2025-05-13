# RobotGame

A C# console application that simulates a robot navigating within a grid-based room. The robot can move forward and turn left or right based on user commands.

## Description

The Robot Game application allows users to:
- Define a room's dimensions
- Place a robot at a specific position and orientation
- Issue movement commands to the robot
- Track the robot's position and orientation
- Detect when the robot attempts to leave the room boundaries

## Requirements

- .NET 8.0 SDK
- IDE that supports C# (Visual Studio 2022, VS Code with C# extension, etc.)

## How to Run the Application

1. Clone the repository
2. Navigate to the project directory
```
cd RobotGame
```
3. Build the application
```
dotnet build
```
4. Run the application
```
dotnet run --project RobotGame
```

## How to Run the Tests

The project includes unit tests using xUnit and FluentAssertions. To run the tests:

```
dotnet test
```

## Project Structure

```
RobotGame/
├── RobotGame/            
│   ├── Controllers/      
│   ├── Enums/            
│   ├── Models/           
│   └── UI/               
│
└── RobotGame.Tests/           
             
```

### Models
- `RoomGrid`: Defines the dimensions of the room
- `Robot`: Represents the robot with its position and orientation
- `Position`: Represents a coordinate (X, Y) on the grid
- `CommandResult`: Contains the result of executing commands (robot position and status)

### Enums
- `Direction`: Represents cardinal directions (North, East, South, West)

### Controllers
- `GameController`: Handles the robot's movement logic and tracks its position

### UI
- `ConsoleUI`: Manages user input and output
- `GridRenderer`: Renders the room grid with the robot's position in ASCII

## Features

- Interactive console interface
- Visual representation of the robot's position using ASCII characters
- Validation of user inputs
- Detection when robot leaves room boundaries
- Detailed error messages

## Game Instructions

1. Set up the room by entering its width and height (e.g., `5 5`)
2. Place the robot by providing its X position, Y position, and direction (e.g., `1 2 N`)
3. Control the robot with the following commands:
   - `L`: Turn left
   - `R`: Turn right
   - `F`: Move forward
4. Enter a sequence of commands without spaces (e.g., `LFRFRFLF`)
5. The game continues until the robot tries to move outside the room boundaries

## Example Input/Output

```
Input:
5 5
1 2 N
RFRFFRFRF

Output:
Report: 1 3 N
```

```
Input:
5 5
0 0 E
RFLFFLRF

Output:
Report: 3 1 E
```