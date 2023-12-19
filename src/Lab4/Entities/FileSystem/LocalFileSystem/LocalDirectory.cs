using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem.LocalFileSystem;

public class LocalDirectory : IDirectory
{
    public LocalDirectory(string path)
    {
        if (path is null) throw new ArgumentNullException(nameof(path));

        var directoryInfo = new DirectoryInfo(path);
        Name = directoryInfo.Name;

        ChildDirectories = directoryInfo.GetDirectories()
            .Select(directory => new LocalDirectory(directory.FullName))
            .ToList<IDirectory>();

        ChildFiles = directoryInfo.GetFiles()
            .Select(file => new LocalFile(file.FullName))
            .ToList<IFile>();
    }

    public string Name { get; }

    public IList<IDirectory> ChildDirectories { get; }

    public IList<IFile> ChildFiles { get; }
}