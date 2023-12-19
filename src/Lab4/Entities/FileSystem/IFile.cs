namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;

public interface IFile
{
    public string Name { get; set; }

    public string Data { get; }
}