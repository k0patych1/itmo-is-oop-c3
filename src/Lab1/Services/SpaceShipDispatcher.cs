using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceEnvironments;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public static class SpaceShipDispatcher
{
    public static FlightReport SimulationOfShipPassing(
        IReadOnlyCollection<SpaceEnvironmentBase> spaceEnvironments,
        Ship ship)
    {
        double finalFuelConsumption = 0;
        double finalTime = 0;

        if (spaceEnvironments is null)
            throw new ArgumentNullException(nameof(spaceEnvironments));

        if (ship is null)
            throw new ArgumentNullException(nameof(ship));

        SpaceEnvironmentBase? problemEnvironment = spaceEnvironments
            .FirstOrDefault(spaceEnvironment => spaceEnvironment.VisitShip(ship).PassingResult
                is not PassingResult.SuccessPassing);

        if (problemEnvironment is not null)
        {
            return problemEnvironment.VisitShip(ship);
        }

        finalTime = spaceEnvironments
            .Sum(spaceEnvironment => spaceEnvironment.VisitShip(ship).Time);
        finalFuelConsumption = spaceEnvironments
            .Sum(spaceEnvironment => spaceEnvironment.VisitShip(ship).FlightFuelConsumption);

        return new FlightReport()
        {
            PassingResult = PassingResult.SuccessPassing,
            FlightFuelConsumption = finalFuelConsumption,
            Time = finalTime,
        };
    }

    public static Ship? ChooseBestShip(
        IReadOnlyCollection<SpaceEnvironmentBase> spaceEnvironments,
        IReadOnlyCollection<Ship> ships)
    {
        if (ships is null)
        {
            throw new ArgumentNullException(nameof(ships));
        }

        Ship? bestShip = null;
        FlightReport? bestFlightReport = null;

        foreach (Ship ship in ships)
        {
            FlightReport flightReport = SimulationOfShipPassing(spaceEnvironments, ship);

            if (flightReport.PassingResult is PassingResult.SuccessPassing)
            {
                if (bestFlightReport is null || ExpendedResources(flightReport) < ExpendedResources(bestFlightReport))
                {
                    bestFlightReport = flightReport;
                    bestShip = ship;
                }
            }
        }

        if (bestShip is not null)
            Console.WriteLine(bestShip.Name);

        return bestShip;
    }

    private static double? ExpendedResources(FlightReport flightReport)
    {
        if (flightReport is null)
            throw new ArgumentNullException(nameof(flightReport));

        return flightReport.FlightFuelConsumption + flightReport.Time;
    }
}