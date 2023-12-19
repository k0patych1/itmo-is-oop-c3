using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.OutputFileSystemManagers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem.InMemoryFileSystem;

public class InMemoryFileSystem : FileSystemBase
{
    public InMemoryFileSystem(IDirectory root, string absolutePathOfRoot)
    {
        Root = root;
        WorkingDirectory = root;
        AbsolutePathOfRoot = absolutePathOfRoot;
    }

    public sealed override IDirectory Root { get; set; }

    public sealed override IDirectory WorkingDirectory { get; set; }

    public sealed override IOutputFileSystemManager? OutputFileSystemManager { get; set; }

    protected override string AbsolutePathOfRoot { get; }

    public override void ChangeCurrentDirectory(string newDirectory)
    {
        WorkingDirectory = new InMemoryDirectory(newDirectory);
    }

    public override void MoveFile(string sourcePath, string destinationPath)
    {
        CopyFile(sourcePath, destinationPath);
        DeleteFile(sourcePath);
    }

    public override void CopyFile(string sourcePath, string destinationPath)
    {
        IFile fileToCopy = FindFileByPath(sourcePath);
        IDirectory destinationDirectory = FindDirectoryByPath(destinationPath);
        destinationDirectory.ChildFiles.Add(fileToCopy);
    }

    public override void DeleteFile(string path)
    {
        string parentDirectoryPath = Path.GetDirectoryName(path) ??
                                     throw new CommandExecuteException("Invalid path argument" + path);
        IDirectory parentDirectory = FindDirectoryByPath(parentDirectoryPath);

        IFile fileToRemove = parentDirectory.ChildFiles
                                 .FirstOrDefault(file => file.Name == Path.GetFileName(path)) ??
                             throw new CommandExecuteException("Invalid path argument" + path);
        parentDirectory.ChildFiles.Remove(fileToRemove);
    }

    public override void RenameFile(string path, string newName)
    {
        IFile file = FindFileByPath(path);
        file.Name = newName;
    }
}