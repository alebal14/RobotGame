using FluentAssertions;
using RobotGame.Enums;
using RobotGame.Models;

namespace RobotGame.Tests
{
    public class RobotTests
    {
        [Fact]
        public void Robot_ShouldInitialize_WithCorrectValues()
        {

            var position = new Position(3, 4);
            var direction = Direction.North;

            var robot = new Robot(position, direction);

            robot.Position.Should().Be(position);
            robot.Orientation.Should().Be(direction);
        }
    }
}
