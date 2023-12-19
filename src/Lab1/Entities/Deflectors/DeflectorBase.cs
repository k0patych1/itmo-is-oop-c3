using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public abstract class DeflectorBase
{
    protected DeflectorBase(int hitPoints)
    {
        if (hitPoints < 0)
            throw new NegativeArgumentException(nameof(hitPoints));

        HitPoints = hitPoints;
    }

    public bool IsAlive => HitPoints > 0;

    public int HitPoints { get; private set; }

    public virtual void TakeDamage(ObstacleBase obstacle)
    {
        if (obstacle is null)
            throw new ArgumentNullException(nameof(obstacle));

        HitPoints -= obstacle.Damage;
    }
}