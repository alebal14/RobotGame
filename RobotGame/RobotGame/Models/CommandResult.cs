namespace RobotGame.Models
{
    public class CommandResult
    {
        public bool IsRobotInside { get; set; }
        public required Robot Robot { get; set; }
    }
}
