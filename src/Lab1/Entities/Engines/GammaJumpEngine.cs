namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class GammaJumpEngine : JumpEngineBase
{
    public GammaJumpEngine()
        : base(CGammaJumpEngineRange, CGammaJumpEngineFuelConsumption)
    {
    }

    private static long CGammaJumpEngineRange => 10_000_000_000L;

    private static int CGammaJumpEngineFuelConsumption => 1_000_000;
}