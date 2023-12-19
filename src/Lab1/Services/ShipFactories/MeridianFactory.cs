using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ShipHulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.ShipFactories;

public class MeridianFactory : ShipFactoryBase
{
    public override string ConstructName()
    {
        return "Meridian";
    }

    public override ShipHullBase ConstructShipHull()
    {
        return new SecondLevelShipHull();
    }

    public override PulseEngineBase ConstructPulseEngine()
    {
        return new ExponentialPulseEngine();
    }

    public override JumpEngineBase ConstructJumpEngine()
    {
        return new NullJumpEngine();
    }

    public override DeflectorBase ConstructDeflector()
    {
        return new SecondLevelDeflector();
    }

    public override bool ConstructAntiNitrineEmitter()
    {
        return true;
    }
}