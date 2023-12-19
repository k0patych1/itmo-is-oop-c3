using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

public class Message
{
    public Message(string title, string body, ImportanceLevel importanceLevel)
    {
        Title = title;
        Body = body;
        ImportanceLevel = importanceLevel;
    }

    protected Message(Message message)
    {
        if (message is null) throw new ArgumentNullException(nameof(message));

        Title = message.Title;
        Body = message.Body;
        ImportanceLevel = message.ImportanceLevel;
    }

    public string Title { get; }

    public string Body { get; }

    public ImportanceLevel ImportanceLevel { get; }
}