namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class ThirdLevelDeflector : DeflectorBase
{
    public ThirdLevelDeflector()
        : base(CThirdLevelDeflectorHitPoints)
    {
    }

    private static int CThirdLevelDeflectorHitPoints => 99;
}