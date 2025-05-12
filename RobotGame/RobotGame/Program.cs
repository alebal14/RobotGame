// See https://aka.ms/new-console-template for more information
using RobotGame.Controllers;
using RobotGame.Models;
using RobotGame.UI;

var userInterface = new ConsoleUI();
userInterface.DisplayWelcome();

RoomGrid room = userInterface.GetRoomDimensions();
Robot robot = userInterface.GetRobotPlacement(room);

GameController gameController = new GameController(room, robot);


var continuePlaying = true;

while (continuePlaying)
{

    string inputCommands = userInterface.GetMovementCommands();
    var commandResult = gameController.ExecuteCommands(inputCommands);
    continuePlaying = commandResult.IsRobotInside;

    userInterface.DisplayResult(commandResult);

}

userInterface.DisplayGameOver();
