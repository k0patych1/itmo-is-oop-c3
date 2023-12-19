using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.OutputFileSystemManagers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem.LocalFileSystem;

public class LocalFileSystem : FileSystemBase
{
    public LocalFileSystem(string path)
    {
        Root = new LocalDirectory(path);
        WorkingDirectory = Root;
        AbsolutePathOfRoot = path;
    }

    public sealed override IDirectory Root { get; set; }

    public sealed override IDirectory WorkingDirectory { get; set; }

    public override IOutputFileSystemManager? OutputFileSystemManager { get; set; }

    protected override string AbsolutePathOfRoot { get; }

    public override void ChangeCurrentDirectory(string newDirectory)
    {
        WorkingDirectory = new LocalDirectory(newDirectory);
    }

    public override void MoveFile(string sourcePath, string destinationPath)
    {
        CopyFile(sourcePath, destinationPath);
        DeleteFile(sourcePath);

        File.Move(
            NormalizePath(sourcePath),
            Path.Combine(NormalizePath(destinationPath), Path.GetFileName(sourcePath)));
    }

    public override void CopyFile(string sourcePath, string destinationPath)
    {
        IFile fileToCopy = FindFileByPath(sourcePath);
        IDirectory destinationDirectory = FindDirectoryByPath(destinationPath);
        destinationDirectory.ChildFiles.Add(fileToCopy);
        File.Copy(
            NormalizePath(sourcePath),
            Path.Combine(NormalizePath(destinationPath), Path.GetFileName(sourcePath)));
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
        File.Delete(NormalizePath(path));
    }

    public override void RenameFile(string path, string newName)
    {
        IFile file = FindFileByPath(path);
        file.Name = newName;

        File.Move(NormalizePath(path), Path.Combine(Path.GetDirectoryName(path) ?? string.Empty, newName));
    }
}