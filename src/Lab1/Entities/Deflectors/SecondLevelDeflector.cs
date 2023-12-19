namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class SecondLevelDeflector : DeflectorBase
{
    public SecondLevelDeflector()
        : base(CSecondLevelDeflectorHitPoints)
    {
    }

    private static int CSecondLevelDeflectorHitPoints => 35;
}