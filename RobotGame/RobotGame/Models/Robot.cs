using RobotGame.Enums;

namespace RobotGame.Models
{
    class Robot
    {
        public Position Position { get; set; }
        public Direction Orientation { get; set; }

        public Robot(Position position, Direction orientation)
        {
            Position = position;
            Orientation = orientation;
        }
    }
}
