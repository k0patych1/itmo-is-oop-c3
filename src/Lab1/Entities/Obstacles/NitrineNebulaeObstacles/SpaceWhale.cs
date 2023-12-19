using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles.NitrineNebulaeObstacles;

public class SpaceWhale : NitrineNebulaeObstacleBase
{
    public SpaceWhale()
        : base(CDamageOfSpaceWhale)
    {
    }

    private static int CDamageOfSpaceWhale => 100;

    public override PassingResult VisitShip(Ship ship)
    {
        if (ship is null)
            throw new ArgumentNullException(nameof(ship));

        return ship.TakeDamage(this);
    }
}