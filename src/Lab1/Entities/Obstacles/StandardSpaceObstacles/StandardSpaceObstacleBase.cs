using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles.StandardSpaceObstacles;

public abstract class StandardSpaceObstacleBase : ObstacleBase
{
    protected StandardSpaceObstacleBase(int damage)
        : base(damage)
    {
    }

    public override PassingResult VisitShip(Ship ship)
    {
        if (ship is null)
            throw new ArgumentNullException(nameof(ship));

        return ship.TakeDamage(this);
    }
}