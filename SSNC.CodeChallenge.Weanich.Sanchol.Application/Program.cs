// See https://aka.ms/new-console-template for more information

using SSNC.CodeChallenge.Weanich.Sanchol.Domains;
using SSNC.CodeChallenge.Weanich.Sanchol.Services;

var isPlace = false;
var toyRobotService = new ToyRobotService();
var toy = new Toy();
var board = new Board(5, 5);
while (true)
{
    var command = Console.ReadLine();

    if (command.StartsWith("PLACE"))
    {
        var placeCommandArguments = command.Split(" ")[1];
        var x = int.Parse(placeCommandArguments.Split(",")[0]);
        var y = int.Parse(placeCommandArguments.Split(",")[1]);
        var f = placeCommandArguments.Split(",")[2];
        toyRobotService.Place(toy, board, x, y, f);
        isPlace = true;
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