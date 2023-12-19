using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles.StandardSpaceObstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceEnvironments;

public class StandardSpace : SpaceEnvironmentBase
{
    public StandardSpace(int length, IReadOnlyCollection<StandardSpaceObstacleBase> obstacles)
        : base(length, obstacles)
    {
    }

    public override FlightReport VisitShip(Ship ship)
    {
        if (ship is null)
            throw new ArgumentNullException(nameof(ship));

        return ship.GoThrowSpaceEnvironment(this);
    }
}