namespace RobotGame.Models
{
    class CommandResult
    {
        public bool IsRobotInside { get; set; }
        public required Robot Robot { get; set; }
    }
}
