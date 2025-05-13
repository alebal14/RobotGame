using FluentAssertions;
using RobotGame.Enums;
using RobotGame.Models;

namespace RobotGame.Tests
{
    public class CommandResultTests
    {
        [Fact]
        public void CommandResult_ShouldInitialize_WithCorrectValues()
        {

            var robot = new Robot(new Position(3, 4), Direction.North);

            var result = new CommandResult
            {
                IsRobotInside = true,
                Robot = robot
            };

            result.IsRobotInside.Should().BeTrue();
            result.Robot.Should().Be(robot);
        }

        [Fact]
        public void CommandResult_ShouldTrackRobotOutsideStatus_Correctly()
        {

            var robot = new Robot(new Position(3, 4), Direction.North);
            var result = new CommandResult
            {
                IsRobotInside = true,
                Robot = robot
            };

            result.IsRobotInside = false;

            result.IsRobotInside.Should().BeFalse();
        }
    }
}