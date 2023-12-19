namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles.StandardSpaceObstacles;

public class SmallMeteorite : StandardSpaceObstacleBase
{
    public SmallMeteorite()
        : base(CDamageOfSmallMeteorite)
    {
    }

    private static int CDamageOfSmallMeteorite => 3;
}