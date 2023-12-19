using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ShipHulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.ShipFactories;

public class VaklasFactory : ShipFactoryBase
{
    public override string ConstructName()
    {
        return "Vaklas";
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
        return new GammaJumpEngine();
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