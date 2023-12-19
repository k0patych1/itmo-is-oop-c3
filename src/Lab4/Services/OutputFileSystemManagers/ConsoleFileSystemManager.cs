using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.OutputFileSystemManagers;

public class ConsoleFileSystemManager : IOutputFileSystemManager
{
    private string FileSymbol => "📄";
    private string FolderSymbol => "📁";
    private string IndentSymbol => "    ";

    public void ShowFile(IFile? file)
    {
        if (file is null) throw new ArgumentNullException(nameof(file));

        Console.WriteLine(file.Data);
    }

    public void ShowFileSystemTree(IDirectory? path, int samplingDepth)
    {
        ShowDirectory(path, 0, samplingDepth);
    }

    public void ShowFileSystemTree(IDirectory? path)
    {
        ShowDirectory(path, 0, int.MaxValue);
    }

    private void ShowDirectory(IDirectory? directory, int depth, int samplingDepth)
    {
        if (directory == null)
            return;

        Console.WriteLine($"{GetIndent(depth)}{FolderSymbol} {directory.Name}");

        if (depth >= samplingDepth)
            return;

        foreach (IFile file in directory.ChildFiles)
        {
            Console.WriteLine($"{GetIndent(depth + 1)}{FileSymbol} {file.Name}");
        }

        foreach (IDirectory subDirectory in directory.ChildDirectories)
        {
            ShowDirectory(subDirectory, depth + 1, samplingDepth);
        }
    }

    private string GetIndent(int depth)
    {
        return string.Concat(Enumerable.Repeat(IndentSymbol, depth));
    }
}