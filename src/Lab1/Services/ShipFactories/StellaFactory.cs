using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ShipHulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.ShipFactories;

public class StellaFactory : ShipFactoryBase
{
    public override string ConstructName()
    {
        return "Stella";
    }

    public override ShipHullBase ConstructShipHull()
    {
        return new FirstLevelShipHull();
    }

    public override PulseEngineBase ConstructPulseEngine()
    {
        return new StandardPulseEngine();
    }

    public override JumpEngineBase ConstructJumpEngine()
    {
        return new OmegaJumpEngine();
    }

    public override DeflectorBase ConstructDeflector()
    {
        return new FirstLevelDeflector();
    }

    public override bool ConstructAntiNitrineEmitter()
    {
        return false;
    }
}