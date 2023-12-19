using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Repositories;

public class PcComponentRepository<T> : IPcComponentRepository<T>
    where T : PcComponentBase
{
    private readonly Dictionary<string, T> _dictionary;

    public PcComponentRepository()
    {
        _dictionary = new Dictionary<string, T>();
    }

    public PcComponentRepository(Dictionary<string, T> dictionary)
    {
        _dictionary = dictionary;
    }

    public IEnumerable<T> GetAllPcComponents()
    {
        return _dictionary.Values;
    }

    public T GetPcComponent(string name)
    {
        if (!_dictionary.ContainsKey(name)) throw new NoSuchComponentInRepositoryException(nameof(name));

        return _dictionary[name];
    }

    public void Create(string name, T pcComponentBase)
    {
        _dictionary.Add(name, pcComponentBase);
    }

    public void Update(string name, T pcComponentBase)
    {
        if (!_dictionary.ContainsKey(name)) throw new NoSuchComponentInRepositoryException(nameof(name));

        _dictionary[name] = pcComponentBase;
    }

    public void Delete(string name)
    {
        if (!_dictionary.ContainsKey(name)) throw new NoSuchComponentInRepositoryException(nameof(name));

        _dictionary.Remove(name);
    }
}