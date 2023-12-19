using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.OutputFileSystemManagers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;

public abstract class FileSystemBase
{
    public abstract IDirectory Root { get; set; }

    public abstract IDirectory WorkingDirectory { get; set; }

    public abstract IOutputFileSystemManager? OutputFileSystemManager { get; set; }

    protected abstract string AbsolutePathOfRoot { get; }

    public abstract void ChangeCurrentDirectory(string newDirectory);

    public abstract void MoveFile(string sourcePath, string destinationPath);

    public abstract void CopyFile(string sourcePath, string destinationPath);

    public abstract void DeleteFile(string path);

    public abstract void RenameFile(string path, string newName);

    public void ShowFile(string path)
    {
        if (OutputFileSystemManager is null)
            throw new CommandExecuteException("Can't show file without setting output");

        IFile file = FindFileByPath(path);

        OutputFileSystemManager.ShowFile(file);
    }

    public void ShowTree(int samplingDepth)
    {
        if (OutputFileSystemManager is null)
            throw new CommandExecuteException("Can't show file without setting output");

        OutputFileSystemManager.ShowFileSystemTree(WorkingDirectory, samplingDepth);
    }

    public void ShowTree()
    {
        if (OutputFileSystemManager is null)
            throw new CommandExecuteException("Can't show file without setting output");

        OutputFileSystemManager.ShowFileSystemTree(WorkingDirectory);
    }

    protected string NormalizePath(string path)
    {
        if (Path.IsPathRooted(path)) return path;

        if (WorkingDirectory == null)
            throw new CommandExecuteException("Invalid path argument" + path);

        return Path.Combine(AbsolutePathOfRoot, path);
    }

    protected IDirectory FindDirectoryByPath(string path)
    {
        if (path is null) throw new ArgumentNullException(nameof(path));

        IDirectory? target;
        string[] pathArray = path.Split(Path.DirectorySeparatorChar);
        int start = 0;

        if (Path.IsPathRooted(path))
        {
            start = Array.IndexOf(pathArray, Root.Name);
            target = Root;
        }
        else
        {
            target = WorkingDirectory;
        }

        if (start == -1)
            throw new CommandExecuteException("Invalid path argument" + path);

        target = FindInTree(pathArray, target, start);

        if (target is null)
            throw new CommandExecuteException("Invalid path argument" + path);

        return target;
    }

    protected IFile FindFileByPath(string path)
    {
        string absolutePath = NormalizePath(path);

        string parentDirectoryPath = Path.GetDirectoryName(absolutePath) ??
                                     throw new CommandExecuteException("Invalid path argument" + path);
        IDirectory parentDirectory = FindDirectoryByPath(parentDirectoryPath);

        IFile file = parentDirectory.ChildFiles
                         .FirstOrDefault(file => file.Name == Path.GetFileName(path)) ??
                     throw new CommandExecuteException("Invalid path argument" + path);

        return file;
    }

    private IDirectory? FindInTree(IList<string> pathArray, IDirectory target, int start)
    {
        if (pathArray is null) throw new ArgumentNullException(nameof(pathArray));
        if (target is null) throw new ArgumentNullException(nameof(target));

        for (int i = start + 1; i < pathArray.Count; ++i)
        {
            IDirectory? temp = target.ChildDirectories
                .FirstOrDefault(obj => obj?.Name == pathArray[i], null);
            if (temp == null) return null;
            target = temp;
        }

        return target;
    }
}