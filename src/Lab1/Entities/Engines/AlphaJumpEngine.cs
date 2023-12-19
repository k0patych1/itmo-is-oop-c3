namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class AlphaJumpEngine : JumpEngineBase
{
    public AlphaJumpEngine()
        : base(CAlphaJumpEngineRange, CAlphaJumpEngineFuelConsumption)
    {
    }

    private static int CAlphaJumpEngineRange => 100_000;

    private static int CAlphaJumpEngineFuelConsumption => 1000;
}