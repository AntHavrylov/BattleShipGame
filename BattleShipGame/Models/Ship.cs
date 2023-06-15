using static BattleShipGame.Commons.Enums;

namespace BattleShipGame.Models;

public class Ship
{
    public Compartment[] Compartments { get; }    
    public StatusType Status { get; set; }

    public Ship(List<(int,int)> coordinates) => 
        Compartments = coordinates.Select(c => new Compartment((c.Item1,c.Item2))).ToArray();

    

}
