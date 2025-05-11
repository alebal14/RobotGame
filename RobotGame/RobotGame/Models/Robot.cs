using RobotGame.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotGame.Models
{
    class Robot
    {
        public Position Position { get; set; }
        public Direction Orientation { get; set; }

        public Robot(Position initialPosition, Direction initialOrientation)
        {
            Position = initialPosition;
            Orientation = initialOrientation;
        }
    }
}
