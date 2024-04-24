// See https://aka.ms/new-console-template for more information

using SSNC.CodeChallenge.Weanich.Sanchol.Domains;
using SSNC.CodeChallenge.Weanich.Sanchol.Services;

int defaultWidth = 5;
int defaultHeight = 5;
var isPlace = false;
var toyRobotService = new ToyRobotService();
var toy = new Toy();
var board = new Board(defaultWidth, defaultHeight);
while (true)
{
    var command = Console.ReadLine();
    command = command?.ToUpper();
    if (command.StartsWith("PLACE"))
    {
        var placeCommandArguments = command.Split(" ")[1];
        var xIsNumber = int.TryParse(placeCommandArguments.Split(",")[0], out int x);
        var yIsNumber = int.TryParse(placeCommandArguments.Split(",")[1], out int y);

        var f = placeCommandArguments.Split(",")[2];
        
        if (xIsNumber && yIsNumber && DirectionIsValid(toyRobotService, f))
        {
            toyRobotService.Place(toy, board, x, y, f);
            isPlace = true;
        }
    }
    else if (command == "LEFT" && isPlace)
    {
        toyRobotService.TurnLeft(toy);
    }
    else if (command == "RIGHT" && isPlace)
    {
        toyRobotService.TurnRight(toy);
    }
    else if (command == "MOVE" && isPlace)
    {
        toyRobotService.Move(toy, board);
    }
    else if (command == "REPORT" && isPlace)
    {
        Console.WriteLine($"Output: {toyRobotService.Report(toy)}");
    }else if(command == "EXIT")
    {
        break;
    }
}

static bool DirectionIsValid(ToyRobotService toyRobotService, string f)
{
    return toyRobotService.Directions.Any(direction => direction?.ToLower() == f?.ToLower());
}