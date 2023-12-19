namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles.StandardSpaceObstacles;

public class AverageMeteorite : StandardSpaceObstacleBase
{
    public AverageMeteorite()
        : base(CDamageOfAverageMeteorite)
    {
    }

    private static int CDamageOfAverageMeteorite => 9;
}