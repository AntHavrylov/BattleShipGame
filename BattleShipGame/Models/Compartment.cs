using static BattleShipGame.Commons.Enums;

namespace BattleShipGame.Models;

public class Compartment
{
    public int X { get; set; }
    public int Y { get; set; }
    public StatusType Status { get; set; }

    public Compartment((int,int) coordinate)
    {
        X = coordinate.Item1;
        Y = coordinate.Item2;
    }
}


