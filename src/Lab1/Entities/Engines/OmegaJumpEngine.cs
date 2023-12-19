namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class OmegaJumpEngine : JumpEngineBase
{
    public OmegaJumpEngine()
        : base(COmegaJumpEngineRange, COmegaJumpEngineFuelConsumption)
    {
    }

    private static int COmegaJumpEngineRange => 1_000_000;

    private static int COmegaJumpEngineFuelConsumption => 7000;
}