using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ShipHulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.ShipFactories;

public class AugurFactory : ShipFactoryBase
{
    public override string ConstructName()
    {
        return "Augur";
    }

    public override ShipHullBase ConstructShipHull()
    {
        return new ThirdLevelShipHull();
    }

    public override PulseEngineBase ConstructPulseEngine()
    {
        return new ExponentialPulseEngine();
    }

    public override JumpEngineBase ConstructJumpEngine()
    {
        return new AlphaJumpEngine();
    }

    public override DeflectorBase ConstructDeflector()
    {
        return new ThirdLevelDeflector();
    }

    public override bool ConstructAntiNitrineEmitter()
    {
        return false;
    }
}