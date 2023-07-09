using BattleShipGame.Models;
using BattleShipGame.Services;
using static BattleShipGame.Commons.Enums;


var boardDimention = 10;
var fleet = new int[] { 5, 4, 4 };

IInputService inputService = new InputService();
IBoardService boardService = new BoardService();
Board board = boardService.CreateNew(boardDimention, fleet);

while (board.Fleet.Any(s => s.Status != StatusType.Destroyed))
{
    Console.WriteLine("Please enter coordinates:");
    bool legalInput = inputService.ValidateInput(Console.ReadLine(), out int x, out int y);
    if (legalInput)
        Console.WriteLine(boardService.GetHit(board, x, y) ?
            "Nice, it's a Hit!" :
            "You missed, try again.");
    boardService.PrintBoard(board);
}

Console.WriteLine("Game ended, all ships are destroyed.");
Console.ReadKey();