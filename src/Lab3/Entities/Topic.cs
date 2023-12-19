using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Topic
{
    private readonly IAddressee _addressee;

    public Topic(string name, IAddressee addressee)
    {
        Name = name;
        _addressee = addressee;
    }

    public string Name { get; }

    public void SendMessage(Message message)
    {
        _addressee.ReceiveMessage(message);
    }
}