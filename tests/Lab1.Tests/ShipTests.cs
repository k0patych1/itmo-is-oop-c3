using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles.DenseNebulaeObstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles.NitrineNebulaeObstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles.StandardSpaceObstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceEnvironments;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Services.ShipFactories;
using Xunit;
using Ship = Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class ShipTests
{
    [Theory]
    [InlineData(1_000_000)]
    public void PleasureShuttleAndAugurInDenseNebulae(int length)
    {
        var augur = new Ship(new AugurFactory());
        var pleasureShuttle = new Ship(new PleasureShuttleFactory());

        IReadOnlyCollection<DenseNebulaeObstacleBase> obstacles = new List<DenseNebulaeObstacleBase>();

        var environment = new DenseNebulae(length, obstacles);
        IReadOnlyCollection<SpaceEnvironmentBase> environments = new List<SpaceEnvironmentBase>() { environment };

        FlightReport receivedFlightReportOfAugur = SpaceShipDispatcher.SimulationOfShipPassing(environments, augur);
        FlightReport receivedFlightReportOfPleasureShuttle =
            SpaceShipDispatcher.SimulationOfShipPassing(environments, pleasureShuttle);

        Assert.Equal(PassingResult.LossOfShip, receivedFlightReportOfAugur.PassingResult);
        Assert.Equal(PassingResult.LossOfShip, receivedFlightReportOfPleasureShuttle.PassingResult);
    }

    [Theory]
    [InlineData(1_000_000)]
    public void VaklasAndPhotonVaklasInDenseNebulae(int length)
    {
        var vaklas = new Ship(new VaklasFactory());
        var photonVaklas = new Ship(new VaklasButWithPhotonDeflectorFactory());

        var antimatterFlare = new AntimatterFlare();
        IReadOnlyCollection<DenseNebulaeObstacleBase> obstacles = new List<DenseNebulaeObstacleBase>()
            { antimatterFlare };

        var environment = new DenseNebulae(length, obstacles);
        IReadOnlyCollection<SpaceEnvironmentBase> environments = new List<SpaceEnvironmentBase>() { environment };

        FlightReport receivedFlightReport1 = SpaceShipDispatcher.SimulationOfShipPassing(environments, vaklas);
        FlightReport receivedFlightReport2 = SpaceShipDispatcher.SimulationOfShipPassing(environments, photonVaklas);

        Assert.Equal(PassingResult.DeathOfCrew, receivedFlightReport1.PassingResult);
        Assert.Equal(PassingResult.SuccessPassing, receivedFlightReport2.PassingResult);
    }

    [Theory]
    [InlineData(1_000_000)]
    public void VaklasAugurMeridianInNitrineNebulae(int length)
    {
        var vaklas = new Ship(new VaklasFactory());
        var augur = new Ship(new AugurFactory());
        var meridian = new Ship(new MeridianFactory());

        var spaceWhale = new SpaceWhale();
        IReadOnlyCollection<NitrineNebulaeObstacleBase> obstacles = new List<NitrineNebulaeObstacleBase>()
            { spaceWhale };

        var environment = new NitrineNebulae(length, obstacles);
        IReadOnlyCollection<SpaceEnvironmentBase> environments = new List<SpaceEnvironmentBase>() { environment };

        FlightReport receivedFlightReportOfVaklas = SpaceShipDispatcher.SimulationOfShipPassing(environments, vaklas);
        FlightReport receivedFlightReportOfAugur = SpaceShipDispatcher.SimulationOfShipPassing(environments, augur);
        SpaceShipDispatcher.SimulationOfShipPassing(environments, meridian);

        Assert.Equal(PassingResult.DestructionOfShip, receivedFlightReportOfVaklas.PassingResult);

        Assert.Equal(PassingResult.SuccessPassing, receivedFlightReportOfAugur.PassingResult);
        Assert.False(augur.Deflector.IsAlive);

        Assert.Equal(35, meridian.Deflector.HitPoints);
        Assert.Equal(30, meridian.ShipHull.HitPoints);
    }

    [Theory]
    [InlineData(1000)]
    public void PleasureShuttleAndVaklasInStandardSpace(int length)
    {
        var pleasureShuttle = new Ship(new PleasureShuttleFactory());
        var vaklas = new Ship(new VaklasFactory());

        IReadOnlyCollection<Ship> ships = new List<Ship>()
            { pleasureShuttle, vaklas };

        IReadOnlyCollection<StandardSpaceObstacleBase> obstacles = new List<StandardSpaceObstacleBase>()
            { new SmallMeteorite(), new SmallMeteorite() };

        var environment = new StandardSpace(length, obstacles);
        IReadOnlyCollection<SpaceEnvironmentBase> environments = new List<SpaceEnvironmentBase>() { environment };

        Ship? bestShip = SpaceShipDispatcher.ChooseBestShip(environments, ships);

        Assert.Equal(pleasureShuttle, bestShip);
    }

    [Theory]
    [InlineData(500_000)]
    public void AugurAndStellaInDenseNebulae(int length)
    {
        var augur = new Ship(new AugurFactory());
        var stella = new Ship(new StellaFactory());

        IReadOnlyCollection<Ship> ships = new List<Ship>()
            { augur, stella };

        IReadOnlyCollection<DenseNebulaeObstacleBase> obstacles = new List<DenseNebulaeObstacleBase>() { };

        var environment = new DenseNebulae(length, obstacles);
        IReadOnlyCollection<SpaceEnvironmentBase> environments = new List<SpaceEnvironmentBase>() { environment };

        Ship? bestShip = SpaceShipDispatcher.ChooseBestShip(environments, ships);

        Assert.Equal(stella, bestShip);
    }

    [Fact]
    public void PleasureShuttleAndVaklasInNitrineNebulae()
    {
        var pleasureShuttle = new Ship(new PleasureShuttleFactory());
        var vaklas = new Ship(new VaklasFactory());

        IReadOnlyCollection<Ship> ships = new List<Ship>()
            { pleasureShuttle, vaklas };

        IReadOnlyCollection<DenseNebulaeObstacleBase> obstacles = new List<DenseNebulaeObstacleBase>() { };

        int randomLength = 1;
        var environment = new DenseNebulae(randomLength, obstacles);
        IReadOnlyCollection<SpaceEnvironmentBase> environments = new List<SpaceEnvironmentBase>() { environment };

        Ship? bestShip = SpaceShipDispatcher.ChooseBestShip(environments, ships);

        Assert.Equal(vaklas, bestShip);
    }

    [Theory]
    [InlineData(500_000, 100_000)]
    public void MeridianAugurAndVaklasInStandartSpaceAndNitrineNebulae(
        int lengthStandardSpace,
        int lengthNitrineNebulae)
    {
        var vaklas = new Ship(new VaklasFactory());
        var meridian = new Ship(new MeridianFactory());
        var augur = new Ship(new AugurFactory());

        IReadOnlyCollection<Ship> ships = new List<Ship>()
            { meridian, vaklas, augur };

        IReadOnlyCollection<StandardSpaceObstacleBase> standardSpaceObstacles = new List<StandardSpaceObstacleBase>()
        {
            new AverageMeteorite(), new AverageMeteorite(), new AverageMeteorite(), new SmallMeteorite(),
        };

        var standardSpace = new StandardSpace(lengthStandardSpace, standardSpaceObstacles);

        IReadOnlyCollection<NitrineNebulaeObstacleBase> nitrineNebulaeObstacles = new List<NitrineNebulaeObstacleBase>()
        {
            new SpaceWhale(), new SpaceWhale(), new SpaceWhale(),
        };

        var nitrineNebulae = new NitrineNebulae(lengthNitrineNebulae, nitrineNebulaeObstacles);

        IReadOnlyCollection<SpaceEnvironmentBase> environments = new List<SpaceEnvironmentBase>()
            { standardSpace, nitrineNebulae };

        Ship? bestShip = SpaceShipDispatcher.ChooseBestShip(environments, ships);

        Assert.Equal(meridian, bestShip);
    }
}