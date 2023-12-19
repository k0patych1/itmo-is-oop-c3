using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;

public interface IDirectory
{
    public string Name { get; }

    public IList<IDirectory> ChildDirectories { get; }

    public IList<IFile> ChildFiles { get; }
}