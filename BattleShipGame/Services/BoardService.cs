using BattleShipGame.Models;
using static BattleShipGame.Commons.Enums;

namespace BattleShipGame.Services;

public class BoardService
{
    private readonly Random _random;
    private int _dimention;

    public BoardService()
    {
        _random = new Random();
    }

    public Board CreateNew(int dimention, params int[] ships)
    {
        _dimention = dimention;
        var board = new Board(dimention);
        DefineFleet(board, ships);
        PrintBoard(board);
        return board;
    }

    public void PrintBoard(Board board)
    {
        for (int i = 0; i < board.Cells.GetLength(0); i++)
        {
            for (int j = 0; j < board.Cells.GetLength(1); j++)
            {
                if (board.Cells[i, j] != 0)
                    Console.ForegroundColor = board.Cells[i, j] == -1 ? ConsoleColor.Red : ConsoleColor.Green;
                Console.Write($"{board.Cells[i, j]} ");
                Console.ResetColor();
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public bool GetHit(Board board, int x, int y) 
    {
        if (board.Cells[x, y] > 0) 
        {               
            var sC = board.Fleet.SelectMany(ship => ship.Compartments, (ship, compartment) => new { ship, compartment })
                .FirstOrDefault(item => item.compartment.X == x && item.compartment.Y == y);

            if (sC != null) 
            {
                sC.compartment.Status = StatusType.Damaged;
                sC.ship.Status = sC.ship.Compartments.Any(c => c.Status == StatusType.Undamaged) ?
                    StatusType.Damaged : StatusType.Destroyed;
                board.Cells[x, y] *= -1;
                return true;
            }
        }
        else if(board.Cells[x, y] > -1)
            board.Cells[x, y] = -1;
        return false;
    }

    private void DefineFleet(Board board, int[] ships)
    {
        foreach (int ship in ships)
            SetShip(board, ship);
    }

    private void SetShip(Board board, int shipLengh)
    {
        var coordinates = GetNewShipCoordinates(board, shipLengh);
        board.Fleet.Add(new Ship(coordinates));
        coordinates.ForEach(c => board.Cells[c.Item1, c.Item2] = shipLengh);
    }

    private List<(int, int)> GetNewShipCoordinates(Board board, int shipLength)
    {
        var coordinates = new List<(int, int)>();
        bool isHorisontal = new Random().Next(0, 2) == 0;
        bool ableToSet = false;
        while (!ableToSet)
        {
            int x = _random.Next(0, _dimention - (isHorisontal ? shipLength : 0));
            int y = _random.Next(0, _dimention - (!isHorisontal ? shipLength : 0));

            coordinates = isHorisontal ?
                Enumerable.Range(x, shipLength).Select(i => (i, y)).ToList() :
                Enumerable.Range(y, shipLength).Select(i => (x, i)).ToList();
            ableToSet = coordinates.All(c => board.Cells[c.Item1, c.Item2] == 0);
        }
        return coordinates;
    }
}
