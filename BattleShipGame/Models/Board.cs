namespace BattleShipGame.Models;

public class Board
{
    public int[,] Cells { get; set; }
    public List<Ship> Fleet { get; set; }

    public Board(int dimention) 
    {
        Cells = new int[dimention,dimention];
        Fleet = new List<Ship>();
    }
}
