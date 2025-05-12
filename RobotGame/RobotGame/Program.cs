// See https://aka.ms/new-console-template for more information
using RobotGame.Controllers;
using RobotGame.Models;
using RobotGame.UI;

//Initialize the user interface and start the game
var userInterface = new ConsoleUI();
userInterface.DisplayWelcome();

//Get game setup from user
RoomGrid room = userInterface.GetRoomDimensions();
Robot robot = userInterface.GetRobotPlacement(room);

GameController gameController = new GameController(room, robot);

// Display inital game state
GridRenderer grindRenderer = new GridRenderer(room, robot);
grindRenderer.DrawGrid();

var continuePlaying = true;

//Main game loop - continute until the robot leaves the room
while (continuePlaying)
{
    //Get movement commands from the user
    string inputCommands = userInterface.GetMovementCommands();

    //Execute the commands and get the result
    var commandResult = gameController.ExecuteCommands(inputCommands);
    
    //Update the game state based on whether the robot is still inside the room
    continuePlaying = commandResult.IsRobotInside;
    
    userInterface.DisplayResult(commandResult);

}

//Game is over
userInterface.DisplayGameOver();
Environment.Exit(1);