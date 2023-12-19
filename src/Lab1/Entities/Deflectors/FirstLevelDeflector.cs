namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class FirstLevelDeflector : DeflectorBase
{
    public FirstLevelDeflector()
        : base(CFirstLevelDeflectorHitPoints)
    {
    }

    private static int CFirstLevelDeflectorHitPoints => 10;
}