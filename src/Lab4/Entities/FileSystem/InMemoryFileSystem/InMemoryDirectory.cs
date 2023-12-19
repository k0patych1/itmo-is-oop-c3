using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem.InMemoryFileSystem;

public class InMemoryDirectory : IDirectory
{
    public InMemoryDirectory(string name, IList<IDirectory> childDirectories, IList<IFile> childFiles)
    {
        Name = name;
        ChildDirectories = childDirectories;
        ChildFiles = childFiles;
    }

    public InMemoryDirectory(string newDirectory)
    {
        Name = newDirectory;
        ChildDirectories = new List<IDirectory>();
        ChildFiles = new List<IFile>();
    }

    public string Name { get; }
    public IList<IDirectory> ChildDirectories { get; }
    public IList<IFile> ChildFiles { get; }
}