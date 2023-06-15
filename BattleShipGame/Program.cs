using BattleShipGame.Services;
using System.Text.RegularExpressions;
using static BattleShipGame.Commons.Enums;

var boardService = new BoardService();
var board = boardService.CreateNew(10,5,4,4);

while (board.Fleet.Any(s => s.Status != StatusType.Destroyed))
{
    Console.WriteLine("Please enter coordinates:");
    bool legalInput = TryTranslateInput(Console.ReadLine(), out int x, out int y);
    if (legalInput)
        Console.WriteLine(boardService.GetHit(board, x, y) ? 
            "Nice, it's a Hit!" : 
            "You missed, try again.");
    boardService.PrintBoard(board);
}
Console.WriteLine("Game ended, all ships are destroyed.");
Console.ReadKey();

static bool TryTranslateInput(string input, out int x, out int y)
{
    x = -1;
    y = -1;

    var regex = new Regex(@"^([A-J])([1-9]|10)$");
    if (!regex.IsMatch(input))
    {
        Console.WriteLine("Invalid input format. Please provide a capital letter A to J followed by a number from 1 to 10.");
        return false;
    }

    Match match = regex.Match(input);
    x = match.Groups[1].Value[0] - 'A';
    y = int.Parse(match.Groups[2].Value) - 1;
    return true;
}