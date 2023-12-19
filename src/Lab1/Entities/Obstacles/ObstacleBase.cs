using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public abstract class ObstacleBase
{
    protected ObstacleBase(int damage)
    {
        if (damage < 0)
            throw new NegativeArgumentException(nameof(damage));

        Damage = damage;
    }

    public int Damage { get; }

    public abstract PassingResult VisitShip(Ship ship);
}