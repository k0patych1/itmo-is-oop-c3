using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Repositories;

public interface IPcComponentRepository<T>
    where T : PcComponentBase
{
    IEnumerable<T> GetAllPcComponents();
    T GetPcComponent(string name);
    void Create(string name, T pcComponentBase);
    void Update(string name, T pcComponentBase);
    void Delete(string name);
}