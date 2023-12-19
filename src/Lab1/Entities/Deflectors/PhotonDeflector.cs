using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles.DenseNebulaeObstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class PhotonDeflector : DeflectorDecoratorBase
{
    public PhotonDeflector(DeflectorBase deflector)
        : base(deflector)
    {
    }

    public bool IsAlivePhotonModification => PhotonDeflectorHitPoints > 0;

    private int PhotonDeflectorHitPoints { get; set; } = 3;

    public override void TakeDamage(ObstacleBase obstacle)
    {
        if (obstacle is AntimatterFlare && IsAlivePhotonModification)
            --PhotonDeflectorHitPoints;
        else
            Deflector.TakeDamage(obstacle);
    }
}