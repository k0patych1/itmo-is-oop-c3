namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.ShipHulls;

public class ThirdLevelShipHull : ShipHullBase
{
    public ThirdLevelShipHull()
        : base(CThirdLevelShipHullHitPoints)
    {
    }

    private static int CThirdLevelShipHullHitPoints => 110;
}