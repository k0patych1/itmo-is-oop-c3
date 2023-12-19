namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.ShipHulls;

public class SecondLevelShipHull : ShipHullBase
{
    public SecondLevelShipHull()
        : base(CSecondLevelShipHullHitPoints)
    {
    }

    private static int CSecondLevelShipHullHitPoints => 30;
}