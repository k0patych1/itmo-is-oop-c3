using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles.DenseNebulaeObstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles.NitrineNebulaeObstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ShipHulls;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceEnvironments;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Services.ShipFactories;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Ship
{
    public Ship(ShipFactoryBase shipFactory)
    {
        if (shipFactory is null)
            throw new ArgumentNullException(nameof(shipFactory));

        Name = shipFactory.ConstructName();
        Deflector = shipFactory.ConstructDeflector();
        ShipHull = shipFactory.ConstructShipHull();
        PulseEngine = shipFactory.ConstructPulseEngine();
        JumpEngine = shipFactory.ConstructJumpEngine();
        IsHasAntiNitrineEmitter = shipFactory.ConstructAntiNitrineEmitter();
    }

    public string Name { get; }

    public DeflectorBase Deflector { get; }
    public ShipHullBase ShipHull { get; }
    private PulseEngineBase PulseEngine { get; }
    private JumpEngineBase JumpEngine { get; }

    private bool IsHasAntiNitrineEmitter { get; }

    public FlightReport GoThrowSpaceEnvironment(SpaceEnvironmentBase spaceEnvironment)
    {
        if (spaceEnvironment is null)
            throw new ArgumentNullException(nameof(spaceEnvironment));

        ObstacleBase? problemObstacle = spaceEnvironment.Obstacles
            .FirstOrDefault(obstacle => obstacle.VisitShip(this)
                is not PassingResult.SuccessPassing);

        if (problemObstacle is not null)
        {
            return new FlightReport()
            {
                PassingResult = problemObstacle.VisitShip(this),
                Time = 0,
                FlightFuelConsumption = 0,
            };
        }

        double fuelConsumption;
        double time;

        if (spaceEnvironment is DenseNebulae)
        {
            time = 0;
            fuelConsumption = JumpEngine.FuelConsumption;
        }
        else
        {
            time = PulseEngine.CountTime(spaceEnvironment.Length);
            fuelConsumption = PulseEngine.CountFullFuelConsumption(time);
        }

        return new FlightReport()
        {
            PassingResult = PassingResult.SuccessPassing,
            FlightFuelConsumption = fuelConsumption,
            Time = time,
        };
    }

    public FlightReport GoThrowSpaceEnvironment(DenseNebulae denseNebulae)
    {
        if (JumpEngine is NullJumpEngine)
        {
            return new FlightReport()
            {
                PassingResult = PassingResult.LossOfShip,
                FlightFuelConsumption = 0,
                Time = 0,
            };
        }

        if (denseNebulae is null)
            throw new ArgumentNullException(nameof(denseNebulae));

        if (JumpEngine.JumpRange < denseNebulae.Length)
        {
            return new FlightReport()
            {
                PassingResult = PassingResult.LossOfShip,
                FlightFuelConsumption = 0,
                Time = 0,
            };
        }

        return GoThrowSpaceEnvironment(denseNebulae as SpaceEnvironmentBase);
    }

    public FlightReport GoThrowSpaceEnvironment(NitrineNebulae nitrineNebulae)
    {
        if (PulseEngine is not ExponentialPulseEngine)
        {
            return new FlightReport()
            {
                PassingResult = PassingResult.LossOfShip,
                FlightFuelConsumption = 0,
                Time = 0,
            };
        }

        return GoThrowSpaceEnvironment(nitrineNebulae as SpaceEnvironmentBase);
    }

    public PassingResult TakeDamage(ObstacleBase obstacle)
    {
        Deflector.TakeDamage(obstacle);

        if (Deflector.IsAlive)
            return PassingResult.SuccessPassing;

        ShipHull.TakeDamage(obstacle);

        return ShipHull.IsAlive ? PassingResult.SuccessPassing
            : PassingResult.DestructionOfShip;
    }

    public PassingResult TakeDamage(AntimatterFlare antimatterFlare)
    {
        if (Deflector is not PhotonDeflector { IsAlivePhotonModification: true } photonDeflector)
            return PassingResult.DeathOfCrew;

        photonDeflector.TakeDamage(antimatterFlare);

        return PassingResult.SuccessPassing;
    }

    public PassingResult TakeDamage(SpaceWhale spaceWhale)
    {
        return IsHasAntiNitrineEmitter
            ? PassingResult.SuccessPassing : TakeDamage(spaceWhale as ObstacleBase);
    }
}