namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.ShipHulls;

public class FirstLevelShipHull : ShipHullBase
{
    public FirstLevelShipHull()
        : base(CFirstLevelShipHullHitPoints)
    {
    }

    private static int CFirstLevelShipHullHitPoints => 10;
}