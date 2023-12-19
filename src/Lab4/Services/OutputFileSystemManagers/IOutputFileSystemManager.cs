using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.OutputFileSystemManagers;

public interface IOutputFileSystemManager
{
    public void ShowFile(IFile? file);

    public void ShowFileSystemTree(IDirectory? path, int samplingDepth);

    public void ShowFileSystemTree(IDirectory? path);
}