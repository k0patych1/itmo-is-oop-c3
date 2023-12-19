using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles.DenseNebulaeObstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceEnvironments;

public class DenseNebulae : SpaceEnvironmentBase
{
    public DenseNebulae(int length, IReadOnlyCollection<DenseNebulaeObstacleBase> obstacles)
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