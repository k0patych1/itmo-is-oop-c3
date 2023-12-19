using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem.LocalFileSystem;

public class LocalFile : IFile
{
    public LocalFile(string name, string data)
    {
        Name = name;
        Data = data;
    }

    public LocalFile(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException("The specified file does not exist : ", path);

        Name = Path.GetFileName(path);
        Data = File.ReadAllText(path);
    }

    public string Name { get; set; }

    public string Data { get; }
}