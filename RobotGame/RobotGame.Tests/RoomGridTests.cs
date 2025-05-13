using FluentAssertions;
using RobotGame.Models;

namespace RobotGame.Tests
{
    public class RoomGridTests
    {
        [Fact]
        public void RoomGrid_ShouldInitialize_WithCorrectDimensions()
        {
            var room = new RoomGrid(5, 8);

            room.Width.Should().Be(5);
            room.Height.Should().Be(8);
        }
    }
}
