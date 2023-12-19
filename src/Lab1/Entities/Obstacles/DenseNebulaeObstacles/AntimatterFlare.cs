using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles.DenseNebulaeObstacles;

public class AntimatterFlare : DenseNebulaeObstacleBase
{
    public AntimatterFlare()
        : base(CPhotonDeflectorDamageOfAntimatter)
    {
    }

    private static int CPhotonDeflectorDamageOfAntimatter => 1;

    public override PassingResult VisitShip(Ship ship)
    {
        if (ship is null)
            throw new ArgumentNullException(nameof(ship));

        return ship.TakeDamage(this);
    }
}