using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public abstract class DeflectorDecoratorBase : DeflectorBase
{
    protected DeflectorDecoratorBase(DeflectorBase deflector)
        : base(ConvertToHitPoints(deflector))
    {
        Deflector = deflector;
    }

    protected DeflectorBase Deflector { get; }

    private static int ConvertToHitPoints(DeflectorBase deflector)
    {
        if (deflector is null)
            throw new ArgumentNullException(nameof(deflector));

        return deflector.HitPoints;
    }
}