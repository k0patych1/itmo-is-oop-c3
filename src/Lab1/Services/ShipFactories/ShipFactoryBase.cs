using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ShipHulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.ShipFactories;

public abstract class ShipFactoryBase
{
    public abstract string ConstructName();

    public abstract ShipHullBase ConstructShipHull();

    public abstract PulseEngineBase ConstructPulseEngine();

    public abstract JumpEngineBase ConstructJumpEngine();

    public abstract DeflectorBase ConstructDeflector();

    public abstract bool ConstructAntiNitrineEmitter();
}