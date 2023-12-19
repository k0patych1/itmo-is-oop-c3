namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem.InMemoryFileSystem;

public class InMemoryFile : IFile
{
    public InMemoryFile(string name, string data)
    {
        Name = name;
        Data = data;
    }

    public string Name { get; set; }
    public string Data { get; }
}