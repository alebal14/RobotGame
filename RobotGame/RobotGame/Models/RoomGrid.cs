namespace RobotGame.Models
{
    public class RoomGrid
    {
        public int Width { get; }
        public int Height { get; }

        public RoomGrid(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
