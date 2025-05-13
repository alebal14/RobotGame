using FluentAssertions;
using RobotGame.Controllers;
using RobotGame.Enums;
using RobotGame.Models;

namespace RobotGame.Tests
{
    public class GameControllerTests
    {
        [Fact]
        public void TurnLeft_ShouldChangeOrientation_Correctly()
        {

            var room = new RoomGrid(5, 5);
            var startPosition = new Position(2, 2);

            // Test from North
            var robot = new Robot(startPosition, Direction.North);
            var controller = new GameController(room, robot);

            
            var result = controller.ExecuteCommands("L");

            
            result.Robot.Orientation.Should().Be(Direction.West);

            // Test from West
            robot = new Robot(startPosition, Direction.West);
            controller = new GameController(room, robot);
            result = controller.ExecuteCommands("L");
            result.Robot.Orientation.Should().Be(Direction.South);

            // Test from South
            robot = new Robot(startPosition, Direction.South);
            controller = new GameController(room, robot);
            result = controller.ExecuteCommands("L");
            result.Robot.Orientation.Should().Be(Direction.East);

            // Test from East
            robot = new Robot(startPosition, Direction.East);
            controller = new GameController(room, robot);
            result = controller.ExecuteCommands("L");
            result.Robot.Orientation.Should().Be(Direction.North);
        }

        [Fact]
        public void ExecuteCommands_ShouldDetectWhenRobotLeavesRoom()
        {
            
            var room = new RoomGrid(5, 5);
            var robot = new Robot(new Position(0, 0), Direction.West);
            var controller = new GameController(room, robot);

            
            var result = controller.ExecuteCommands("F");

            
            result.IsRobotInside.Should().BeFalse();
            result.Robot.Position.X.Should().Be(-1);
            result.Robot.Position.Y.Should().Be(0);
        }
    }
}
