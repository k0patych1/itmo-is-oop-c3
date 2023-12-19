using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ShipHulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.ShipFactories;

public class PleasureShuttleFactory : ShipFactoryBase
{
    public override string ConstructName()
    {
        return "PleasureShuttle";
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
        return new NullJumpEngine();
    }

    public override DeflectorBase ConstructDeflector()
    {
        return new NullDeflector();
    }

    public override bool ConstructAntiNitrineEmitter()
    {
        return false;
    }
}