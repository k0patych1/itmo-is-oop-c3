using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceEnvironments;

public abstract class SpaceEnvironmentBase
{
    protected SpaceEnvironmentBase(int length, IReadOnlyCollection<ObstacleBase> obstacles)
    {
        if (length < 0)
            throw new NegativeArgumentException(nameof(length));

        Length = length;
        Obstacles = obstacles;
    }

    public int Length { get; }

    public IReadOnlyCollection<ObstacleBase> Obstacles { get; }

    public abstract FlightReport VisitShip(Ship ship);
}