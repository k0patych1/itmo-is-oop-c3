using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.TreeCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem.InMemoryFileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers.CommandParsers.ConnectionCommandsParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers.CommandParsers.FileCommandsParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers.CommandParsers.TreeCommandsParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers.FlagParsers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class FileSystemManagerTest
{
    [Fact]
    public void ParseCommandTest()
    {
        string[] args = new[] { "tree", "goto", "file" };

        var parser = new TreeListCommandParser(null);

        parser.SetNextCommandParser(new TreeGoToCommandParser(null));

        CommandBase ans = parser.ParseCommand(args);

        Assert.IsType<TreeGoToCommand>(ans);
    }

    [Fact]
    public void ParseCommandWithFlagTest()
    {
        string[] args = new[] { "file", "show", "file", "--mode", "local" };

        var parser = new TreeListCommandParser(null);

        parser.SetNextCommandParser(new TreeGoToCommandParser(null));

        parser.SetNextCommandParser(new FileShowCommandParser(new FileOutputModeParser()));

        CommandBase ans = parser.ParseCommand(args);

        Assert.IsType<FileShowCommand>(ans);
    }

    [Fact]
    public void ParseCommandWithFlagIncorrectTest()
    {
        string[] args = new[] { "file", "show", "file", "--mode", "local", "abracadabra" };

        var parser = new TreeListCommandParser(null);

        parser.SetNextCommandParser(new TreeGoToCommandParser(null));

        parser.SetNextCommandParser(new FileShowCommandParser(new FileOutputModeParser()));

        Assert.Throws<CommandParseException>(() => parser.ParseCommand(args));
    }

    [Fact]
    public void InMemoryFileSystemTest()
    {
        var parser1 = new FileShowCommandParser(new FileOutputModeParser());
        var parser2 = new ConnectCommandParser(new FileSystemModeParser());
        var parser3 = new TreeListCommandParser(new SamplingDepthParser());
        var parser4 = new DisconnectCommandParser(null);
        var parser5 = new TreeGoToCommandParser(null);
        var parser6 = new FileCopyCommandParser(null);
        var parser7 = new FileDeleteCommandParser(null);
        var parser8 = new FileRenameCommandParser(null);
        var parser9 = new FileMoveCommandParser(null);

        parser1.SetNextCommandParser(parser2);
        parser2.SetNextCommandParser(parser3);
        parser3.SetNextCommandParser(parser4);
        parser4.SetNextCommandParser(parser5);
        parser5.SetNextCommandParser(parser6);
        parser6.SetNextCommandParser(parser7);
        parser7.SetNextCommandParser(parser8);
        parser8.SetNextCommandParser(parser9);

        var dir1 = new InMemoryDirectory("dir1");
        var dir2 = new InMemoryDirectory(
            "dir2",
            new List<IDirectory>(),
            new List<IFile>() { new InMemoryFile("file1", "Hello, world!") });

        var root = new InMemoryDirectory(
            "root",
            new List<IDirectory>() { dir1, dir2 },
            new List<IFile>() { new InMemoryFile("file2", "Goodbye, world!") });

        FileSystemBase? fileSystem = new InMemoryFileSystem(root, "/");

        string[] args1 = new[]
        {
            "file", "show", "/root/file2", "-m", "console",
        };

        string[] args2 = new[]
        {
            "file", "show", "/root/dir2/file1", "-m", "console",
        };

        string[] args3 = new[]
        {
            "tree", "list",
        };

        string[] args4 = new[]
        {
            "file", "move", "root/file2", "root/dir2",
        };

        using var writer = new StringWriter();
        Console.SetOut(writer);

        parser1.ParseCommand(args1).Execute(ref fileSystem);
        parser1.ParseCommand(args2).Execute(ref fileSystem);
        parser1.ParseCommand(args3).Execute(ref fileSystem);
        parser1.ParseCommand(args4).Execute(ref fileSystem);
        parser1.ParseCommand(args3).Execute(ref fileSystem);

        string consoleOutput = writer.ToString().Trim();

        string expected = new StringBuilder()
            .Append("Goodbye, world!\n")
            .Append("Hello, world!\n")
            .Append("📁 root\n")
            .Append("    📄 file2\n")
            .Append("    📁 dir1\n")
            .Append("    📁 dir2\n")
            .Append("        📄 file1\n")
            .Append("📁 root\n")
            .Append("    📁 dir1\n")
            .Append("    📁 dir2\n")
            .Append("        📄 file1\n")
            .Append("        📄 file2")
            .ToString();

        Assert.Equal(expected, consoleOutput);
    }
}