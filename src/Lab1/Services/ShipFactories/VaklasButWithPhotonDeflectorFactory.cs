using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.ShipFactories;

public class VaklasButWithPhotonDeflectorFactory : VaklasFactory
{
    public override DeflectorBase ConstructDeflector()
    {
        var baseDeflector = new FirstLevelDeflector();

        return new PhotonDeflector(baseDeflector);
    }
}